using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using ImageProcessor;
using log4net;

namespace STFU.Lib.Common
{
	public static class ThumbnailLoader
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(ThumbnailLoader));

		public static Image Load(string path)
		{
			Image result = new Bitmap(1, 1);
			((Bitmap)result).SetPixel(0, 0, Color.Transparent);

			Exception loadException = null;

			if (File.Exists(path))
			{
				LOGGER.Debug($"Trying to load thumbnail from path '{path}'");

				try
				{
					ImageFactory imageFactory = new ImageFactory().Load(path);
					result = imageFactory.Image;
				}
				catch (Exception ex)
				{
					LOGGER.Error("Could not load thumbnail", ex);
					loadException = ex;
				}
			}

			if (!File.Exists(path) || loadException != null)
			{
				LOGGER.Debug("Trying to load thumbnail replacement image");

				try
				{
					Assembly myAssembly = Assembly.GetExecutingAssembly();
					Stream myStream = myAssembly.GetManifestResourceStream("STFU.Lib.Common.Kein-Thumbnail.png");
					result = new Bitmap(myStream);
				}
				catch (Exception ex)
				{
					LOGGER.Error("Could not load thumbnail replacement image", ex);
				}
			}

			return result;
		}

		public static Image Load(string path, int width, int height)
		{
			return ResizeImage(Load(path), width, height);
		}

		public static string LoadAsBase64(string path, int width, int height)
		{
			LOGGER.Debug($"Trying to load thumbnail as base 64 from path '{path}'");
			string base64 = Convert.ToBase64String(ImageToByteArray(Load(path, width, height)));
			LOGGER.Debug($"Loaded base64 image string: '{base64}'");
			return base64;
		}

		private static Bitmap ResizeImage(Image image, int width, int height)
		{
			var destRect = new Rectangle(0, 0, width, height);
			var destImage = new Bitmap(width, height);

			destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

			using (var graphics = Graphics.FromImage(destImage))
			{
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

				using (var wrapMode = new ImageAttributes())
				{
					wrapMode.SetWrapMode(WrapMode.TileFlipXY);
					graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
				}
			}

			return destImage;
		}

		private static byte[] ImageToByteArray(Image image)
		{
			MemoryStream ms = new MemoryStream();
			//image.Save(ms, GetEncoder(ImageFormat.Jpeg), GetJpegQualityEncoderParams(99L));
			image.Save(ms, ImageFormat.Png);
			return ms.ToArray();
		}

		private static EncoderParameters GetJpegQualityEncoderParams(long qualityLevel)
		{
			Encoder myEncoder = Encoder.Quality;

			EncoderParameters myEncoderParameters = new EncoderParameters(1);
			EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, qualityLevel);

			return myEncoderParameters;
		}

		private static ImageCodecInfo GetEncoder(ImageFormat format)
		{
			ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
			foreach (ImageCodecInfo codec in codecs)
			{
				if (codec.FormatID == format.Guid)
				{
					return codec;
				}
			}
			return null;
		}
	}
}
