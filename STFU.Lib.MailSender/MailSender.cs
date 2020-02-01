using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using MimeKit;
using Newtonsoft.Json;
using STFU.Lib.Common;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Services;

namespace STFU.Lib.MailSender
{
	public static class MailSender
	{
		public static void Send(IYoutubeAccount from, string to, string title, string message)
		{
			var token = YoutubeAccountService.GetAccessToken(from.Access, ac => ac.HasSendMailPrivilegue);

			if (!string.IsNullOrWhiteSpace(token) && !string.IsNullOrWhiteSpace(to))
			{
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
				string result = null;
				SendResult sendResult = null;
				Exception exception = null;

				try
				{
					result = WebService.Communicate(request, Encoding.UTF8.GetBytes(rfcMail));
					sendResult = JsonConvert.DeserializeObject<SendResult>(result);
				}
				catch (Exception ex)
				{
					exception = ex;
				}

				if (sendResult == null || !sendResult.labelIds.Any(label => label.ToUpper() == "SENT"))
				{
					// Fehler
					string error = $"Die Mail konnte nicht ordnungsgemäß versandt werden.{Environment.NewLine}"
						+ $"Fehler: {result}";
					ErrorLogger.LogError("mail", error);
				}

				if (exception != null)
				{
					ErrorLogger.LogException(exception, "mail", null);
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

			return System.Convert.ToBase64String(bytes)
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
