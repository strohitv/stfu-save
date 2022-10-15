using System;
using System.Net;

namespace STFU.Lib.GUI.Tools
{
	public abstract class HttpServer
	{
		private static HttpListener Listener { get; set; }

		public static string ListenForRedirect(string[] prefixes)
		{
			if (!HttpListener.IsSupported)
			{
				Console.WriteLine("HttpListener is not supported");
				return null;
			}

			if (prefixes == null || prefixes.Length == 0)
			{
				throw new ArgumentException("prefixes must be given");
			}

			Listener = new HttpListener();

			foreach (string s in prefixes)
			{
				Listener.Prefixes.Add(s);
			}

			Listener.Start();
			Console.WriteLine("Listening...");

			try
			{
				HttpListenerContext context = Listener.GetContext();
				HttpListenerRequest request = context.Request;
				HttpListenerResponse response = context.Response;
				string responseString = "<HTML><BODY>Die Anmeldung wurde durchgef&uuml;hrt, du kannst diesen Browser-Tab nun schlie&szlig;en.</BODY></HTML>";
				byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
				response.ContentLength64 = buffer.Length;
				System.IO.Stream output = response.OutputStream;
				output.Write(buffer, 0, buffer.Length);
				output.Close();
				Listener.Stop();

				Console.WriteLine(request.QueryString);

				return request.QueryString["code"];
			}
			catch (HttpListenerException)
			{
				// listen canceled using StopListening() method
				return null;
			}
		}

		public static void StopListening()
		{
			if (Listener.IsListening)
			{
				Listener.Stop();
			}
		}
	}
}
