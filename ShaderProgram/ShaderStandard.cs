using System.Reflection;
using System.IO;

using OpenTK.Graphics.OpenGL4;

namespace OpenGLTutorial.ShaderProgram {

	public static class ShaderStandard {
		public static int ShaderID { get; private set; } = -1;

		public static int MatrixUniformID { get; private set; } = -1;
		public static int TextureUniformID { get; private set; } = -1;

		private static int vertexShaderID = -1;
		private static int fragmentShaderID = -1;


		public static void Init() {
			ShaderID = GL.CreateProgram();

			var assembly = Assembly.GetExecutingAssembly();

			var vertexStream = assembly.GetManifestResourceStream("OpenGLTutorial.ShaderProgram.shaderStandard_vertex.glsl");
			var fragmentStream = assembly.GetManifestResourceStream("OpenGLTutorial.ShaderProgram.shaderStandard_fragment.glsl");
			var vertexStreamReader = new StreamReader(vertexStream);
			var fragmentStreamReader = new StreamReader(fragmentStream);

			string vertexCode = vertexStreamReader.ReadToEnd();
			string fragmentCode = fragmentStreamReader.ReadToEnd();

			vertexStreamReader.Dispose();
			fragmentStreamReader.Dispose();
			vertexStream.Dispose();
			fragmentStream.Dispose();

			vertexShaderID = GL.CreateShader(ShaderType.VertexShader);
			GL.ShaderSource(vertexShaderID, vertexCode);

			fragmentShaderID = GL.CreateShader(ShaderType.FragmentShader);
			GL.ShaderSource(fragmentShaderID, fragmentCode);

			GL.CompileShader(vertexShaderID);
			GL.AttachShader(ShaderID, vertexShaderID);
			
			GL.CompileShader(fragmentShaderID);
			GL.AttachShader(ShaderID, fragmentShaderID);

			GL.LinkProgram(ShaderID);

			MatrixUniformID = GL.GetUniformLocation(ShaderID, "uMatrix");
			TextureUniformID = GL.GetUniformLocation(ShaderID, "uTexture");
		}
	}
}
