using OpenTK;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;

namespace OpenGLTutorial.GameCore {

	class GameObject {
		public Vector3 Position = Vector3.Zero;
		public Vector3 Scale { get; private set; } = Vector3.One;
		public Quaternion Orientation { get; private set; } = new Quaternion(0, 0, 0, 1);

		public void SetScale(float x, float y, float z) : (x, y, z) {
			SetScale(new Vector3(x, y, z));
		}
		public void SetScale(Vector3 scale) {
			if (scale.X > 0 && scale.Y > 0 && scale.Z > 0) {
				Scale = scale;
			} else {
				Scale = Vector3.One;
			}
		}

		public void AddRotation(float degrees, Axis axis) {
			Orientation *= Quaternion.FromAxisAngle(
				new Vector3(axis == Axis.X ? 1 : 0, axis == Axis.Y ? 1 : 0, axis == Axis.Z ? 1 : 0),
				MathHelper.DegreesToRadians(degrees)
			);
		}
	}
}
