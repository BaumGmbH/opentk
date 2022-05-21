using OpenTK.Graphics.OpenGL4;

namespace OpenGLTutorial.Primitives {

	public static class PrimitiveTriangle {

		public static readonly int PointCount = 3;

		public static int VertexArray { get; private set; } = -1;

		private static readonly float[] vertecies = new float[] {
			-0.5f, -0.5f, 0,
			 0.5f, -0.5f, 0,
			 0.0f,  0.5f, 0
		};
		private static readonly float[] uvs = new float[] {
			0.0f, 1.0f,
			0.0f, 0.0f,
			0.5f, 0.0f
		};

		public static void Init() {
			VertexArray = GL.GenVertexArray();
			GL.BindVertexArray(VertexArray);

			int vertexBuffer = GL.GenBuffer();
			GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBuffer);
			GL.BufferData(BufferTarget.ArrayBuffer, vertecies.Length * sizeof(float), vertecies, BufferUsageHint.StaticDraw);
			GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
			GL.EnableVertexAttribArray(0);
			GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

			int uvBuffer = GL.GenBuffer();
			GL.BindBuffer(BufferTarget.ArrayBuffer, uvBuffer);
			GL.BufferData(BufferTarget.ArrayBuffer, uvs.Length * sizeof(float), uvs, BufferUsageHint.StaticDraw);
			GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 0, 0);
			GL.EnableVertexAttribArray(1);
			GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

			GL.BindVertexArray(0);
		}
	}
}
