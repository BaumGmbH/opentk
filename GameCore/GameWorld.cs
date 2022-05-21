using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGLTutorial.GameCore {

	class GameWorld {
		public List<GameObject> GameObjects { get; private set; };
		public List<LightObject> LightObjects { get; private set; };

		public void AddGameObect(GameObject gameObject) {
			GameObjects.Add(gameObject);
		}
		public void AddLightObect(LightObject lightObject) {
			LightObjects.Add(lightObject);
		}

		public bool RemoveGameObject(GameObject gameObject) {
			return GameObjects.Remove(gameObject);
		}
		public bool RemoveLightObect(LightObject lightObject) {
			return LightObjects.Remove(lightObject);
		}
	}
}
