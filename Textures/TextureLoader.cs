using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

using OpenTK.Graphics.OpenGL4;

namespace OpenGLTutorial.Textures {

	public static class TextureLoader {

		public static int LoadTexture(string file) {
			Assembly assembly = Assembly.GetExecutingAssembly();
			Stream stream = assembly.GetManifestResourceStream(file);

			var bitmap = new Bitmap(stream);

			if (bitmap == null) return -1;

			BitmapData bitmapData = bitmap.LockBits(
				new Rectangle(0, 0, bitmap.Width, bitmap.Height), 
				ImageLockMode.ReadOnly,
				bitmap.PixelFormat
			);

			int textureID = GL.GenTexture();

			GL.BindTexture(TextureTarget.Texture2D, textureID);
			GL.TexImage2D(
				TextureTarget.Texture2D, 0, (bitmap.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb) ? PixelInternalFormat.Rgb8 : PixelInternalFormat.Rgba8, 
				bitmap.Width, bitmap.Height, 0,
				bitmap.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb) ? OpenTK.Graphics.OpenGL4.PixelFormat.Bgr : OpenTK.Graphics.OpenGL4.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0
			);

			GL.TexParameter(TextureTarget.Texture2D, (TextureParameterName) OpenTK.Graphics.OpenGL.ExtTextureFilterAnisotropic.TextureMaxAnisotropyExt, 8);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int) TextureMinFilter.LinearMipmapLinear);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int) TextureMagFilter.Linear);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int) TextureWrapMode.Repeat);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int) TextureWrapMode.Repeat);

			GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
			GL.BindTexture(TextureTarget.Texture2D, 0);

			bitmap.Dispose();
			stream.Dispose();

			return textureID;
		}
	}
}
