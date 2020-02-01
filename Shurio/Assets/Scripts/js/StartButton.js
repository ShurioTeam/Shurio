#pragma strict

import UnityEngine.SceneManagement;

public var stage:String;
public var shurio:String;
public var posiX:float = 5.0f;
public var posiY:float = 10.0f;

function Start () {

}

function Update () {

}

function OnTriggerEnter2D(collider:Collider2D) {
	if (collider.tag == "Player") {
		ShurioRotate(collider);

		for (var i:int = 0;i < SceneManager.sceneCount; i++) {
			var activeScene:Scene = SceneManager.GetSceneAt(i);
			if (activeScene.name != shurio) {
				SceneManager.UnloadSceneAsync(activeScene.name);
			}
		}
		SceneManager.LoadScene(stage, LoadSceneMode.Additive);
	}
}

function ShurioRotate(collider:Collider2D) {
	collider.gameObject.transform.position = Vector2(posiX, posiY);
	var posi:Vector2 = this.gameObject.transform.position;
	var shurio_posi:Vector2 = collider.gameObject.transform.position;
	var shurio_muki:Quaternion = collider.gameObject.transform.rotation;
	if (shurio_posi.x - posi.x > 0 && (shurio_muki.y < 90 && shurio_muki.y > -90)) {
		// 右から当たった(反対方向を向いている)
		collider.gameObject.SendMessage("InitRotate", true);
	} else if (shurio_posi.x - posi.x < 0 && (shurio_muki.y > 90 || shurio_muki.y < -90)) {
		// 左から当たった(反対方向を向いている)
		collider.gameObject.SendMessage("InitRotate", true);
	} else {
		// 左から当たった(正方向を向いている)
		// 右から当たった(正方向を向いている)
		collider.gameObject.SendMessage("InitRotate", false);
	}
}
