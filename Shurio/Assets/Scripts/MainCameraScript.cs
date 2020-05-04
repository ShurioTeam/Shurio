using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCameraScript : MonoBehaviour {
	// Use this for initialization
	public string shurioSceneName;
	public string shurioName;
	public bool inWater;
	public bool inSky;
	public float initX;
	public float initY;
	private GameObject shurio;
	void Start () {
		bool shurioFlag = false;
		for (int i = 0;i < SceneManager.sceneCount; i++) {
			Scene scene = SceneManager.GetSceneAt(i);
			if (scene.name == shurioSceneName) {
				shurioFlag = true;
			}
		}

		if (!shurioFlag) {
			SceneManager.LoadSceneAsync(shurioSceneName, LoadSceneMode.Additive);
  		}
	}
	
	// Update is called once per frame
	void Update () {
		if (shurio == null) {
			SetShurio();
		}


	}

	private void SetShurio() {
		Scene shurioScene = SceneManager.GetSceneByName(shurioSceneName);
		GameObject[] objs = shurioScene.GetRootGameObjects();
		foreach (GameObject obj in objs) {
			if (obj.name == shurioName) {
				shurio = obj;
				shurio.SendMessage("InWater", inWater);
				shurio.SendMessage("InSky", inSky);
				Vector3 initPosi = new Vector3(initX, initY, 0);
				shurio.SendMessage("InitPosition", initPosi);
			}
		}
	}

}
