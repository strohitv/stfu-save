using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using log4net;
using MimeKit;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Services;

namespace STFU.Lib.MailSender
{
	public static class MailSender
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(MailSender));

		public static void Send(IYoutubeAccount from, string to, string title, string message)
		{
			LOGGER.Info($"Sending mail from youtube account {from.Title} to recipient {to} with title {title}");
			LOGGER.Debug($"Message content: {message}");

			var token = YoutubeAccountService.GetAccessToken(from.Access, ac => ac.HasSendMailPrivilegue);

			if (!string.IsNullOrWhiteSpace(token) && !string.IsNullOrWhiteSpace(to))
			{
				LOGGER.Debug($"Access token found. Sending mail");

				// Wir können senden!
				HttpWebRequest request = HttpWebRequestCreator.CreateWithAuthHeader(
					$"https://www.googleapis.com/gmail/v1/users/me/messages/send?key={from.Access.First(a => a.AccessToken == token).Client.Secret}",
					"POST",
					token
				);
				request.ContentType = "application/json";

				string content = GenerateMail(to, title, message, true);

				RawMail mail = new RawMail()
				{
					raw = Encode(content)
				};

				var rfcMail = JsonConvert.SerializeObject(mail);

				LOGGER.Debug($"rfc mail json: {rfcMail}");

				string result = null;
				SendResult sendResult = null;

				try
				{
					result = WebService.Communicate(request, Encoding.UTF8.GetBytes(rfcMail));
					LOGGER.Debug($"response from mail service: {result}");

					sendResult = JsonConvert.DeserializeObject<SendResult>(result);
				}
				catch (Exception ex)
				{
					LOGGER.Error($"Exception occured while sending the mail", ex);
				}

				if (sendResult == null || !sendResult.labelIds.Any(label => label.ToUpper() == "SENT"))
				{
					LOGGER.Error($"Could not send the mail. Result: {result}");
				}
				else
				{
					LOGGER.Error($"Mail was sent successfully");
				}
			}
		}

		private static string GenerateMail(string to, string subject, string body, bool isBodyHtml)
		{
			var mailMessage = new MailMessage();
			mailMessage.To.Add(to);
			mailMessage.Subject = subject;
			mailMessage.Body = body;
			mailMessage.IsBodyHtml = isBodyHtml;

			var mimeMessage = MimeMessage.CreateFromMailMessage(mailMessage);

			string message = mimeMessage.ToString();
			return message;
		}

		private static string Encode(string text)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(text);

			return Convert.ToBase64String(bytes)
				.Replace('+', '-')
				.Replace('/', '_')
				.Replace("=", "");
		}

		private class SendResult
		{
			public string id { get; set; } = string.Empty;
			public string threadId { get; set; } = string.Empty;
			public string[] labelIds { get; set; } = new string[0];
		}
	}

	internal class RawMail
	{
		public string raw { get; set; }
	}
}
