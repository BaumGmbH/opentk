using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using System;

namespace OpenGLTutorial {

	class Program {
		
		static void Main(string[] args) {
			var gameWindowSettings = new GameWindowSettings();
			gameWindowSettings.IsMultiThreaded = false;
			gameWindowSettings.RenderFrequency = 0;

			var nativeWindowSettings = new NativeWindowSettings();
			nativeWindowSettings.Flags = ContextFlags.Debug;
			nativeWindowSettings.IsFullscreen = false;
			nativeWindowSettings.NumberOfSamples = 0;
			nativeWindowSettings.Title = "Mein OpenGL-Projekt";
			nativeWindowSettings.WindowBorder = WindowBorder.Resizable;

			var window = new ApplicationWindow(gameWindowSettings, nativeWindowSettings);

			window.Run();
		}
	}
}
