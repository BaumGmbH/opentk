using System;
using System.Collections.Generic;
using System.Text;

using OpenTK;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;

using OpenGLTutorial.Primitives;
using OpenGLTutorial.ShaderProgram;
using OpenGLTutorial.Textures;
using OpenGLTutorial.GameCore;

namespace OpenGLTutorial {

	class ApplicationWindow : GameWindow {

		private GameWorld currentWorld = new GameWorld();

		private Matrix4 projectionMatrix = Matrix4.Identity;
		private Matrix4 viewMatrix = Matrix4.Identity;

		private int textureExample = -1;

		public ApplicationWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
		: base(gameWindowSettings, nativeWindowSettings) { }

		protected override void OnLoad() {
			base.OnLoad();

			GL.ClearColor(Color4.Black);

			GL.Enable(EnableCap.DepthTest);
			GL.Enable(EnableCap.CullFace);

			GL.CullFace(CullFaceMode.Back);
			GL.FrontFace(FrontFaceDirection.Ccw);

			GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);

			PrimitiveTriangle.Init();
			PrimitiveQuad.Init();

			ShaderStandard.Init();

			viewMatrix = Matrix4.LookAt(
				0, 0, 1,
				0, 0, 0,
				0, 1, 0
			);

			textureExample = TextureLoader.LoadTexture("OpenGLTutorial.Textures.stone.jpg");

			var gameObject = new GameObject();
			gameObject.Position = new Vector3(100, -50, 0);
			gameObject.SetScale(300, 300, 1);

			currentWorld.AddGameObect(gameObject);
		}

		protected override void OnResize(ResizeEventArgs e) {
			base.OnResize(e);

			GL.Viewport(0, 0, Size.X, Size.Y);
			projectionMatrix = Matrix4.CreateOrthographic(Size.X, Size.Y, 0.1f, 1000f);
		}

		protected override void OnRenderFrame(FrameEventArgs args) {
			base.OnRenderFrame(args);

			var viewProjection = viewMatrix * projectionMatrix;

			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
			GL.UseProgram(ShaderStandard.ShaderID);
			
			foreach (var gameObject in currentWorld.GameObjects) {
				var modelMatrix = Matrix4.CreateScale(200);
				var mvp = modelMatrix * viewProjection;

				GL.UniformMatrix4(ShaderStandard.MatrixUniformID, false, ref mvp);

				GL.ActiveTexture(TextureUnit.Texture0);
				GL.BindTexture(TextureTarget.Texture2D, textureExample);
				GL.Uniform1(ShaderStandard.TextureUniformID, 0);

				GL.BindVertexArray(PrimitiveQuad.VertexArray);
				GL.DrawArrays(PrimitiveType.Triangles, 0, PrimitiveQuad.PointCount);
				GL.BindVertexArray(0);
				GL.BindTexture(TextureTarget.Texture2D, 0);
			}

				GL.UseProgram(0);
			SwapBuffers();
		}


		protected override void OnUpdateFrame(FrameEventArgs args) {
			base.OnUpdateFrame(args);
		}
	}
}
