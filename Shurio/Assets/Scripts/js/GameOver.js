#pragma strict
import UnityEngine.SceneManagement;

public var flagCount:int = 3;
private var getFlag:int = 0;
private var score:int = 0;
private final var LOAD_LEVEL_START = 0;
private final var LOAD_LEVEL_STAGE1_1 = 1;
private final var LOAD_LEVEL_STAGE1_2 = 2;
private final var LOAD_LEVEL_STAGE1_3 = 3;
private final var LOAD_LEVEL_STAGE2_1 = 4;
private var flag:boolean = false;
private var time:float = 0.0f;
private var limit:float = 5.0f;
public var shurio:String;
public var loadStage:String;
private var rotateFlg;
public var posiX:float = 5.0f;
public var posiY:float = 10.0f;
function Start () {

}

function Update () {
	if (flag) {
		if (time > limit) {
			flag = false;
		}
		time += Time.deltaTime * 1.0f;
	}
}

function OnTriggerEnter2D(collider:Collider2D) {
	if (collider.tag == "Player") {
		if (!flag) {
			flag = true;
			time = 0.0f;
			//SceneManager.SetActiveScene(scene);
			collider.gameObject.transform.position = Vector2(0, 10);
			collider.gameObject.SendMessage("InWater", false);
	//		SceneManager.MoveGameObjectToScene(shurio, scene);

			for (var i:int = 0;i < SceneManager.sceneCount; i++) {
				var scene:Scene = SceneManager.GetSceneAt(i);
				if (scene.name != shurio) {
					SceneManager.UnloadSceneAsync(scene.name);
				}
			}
			SceneManager.LoadScene(loadStage, LoadSceneMode.Additive);
	//		var thisScene:Scene = SceneManager.GetActiveScene();
	//		Application.Unload();
	//		Application.LoadLevelAdditive("Start");

	//		Application.LoadLevel("Start");
	//		Application.LoadLevel(Application.loadedLevel);
		}
	}

	if (collider.tag == "Flag") {
		getFlag++;
		score++;
		var camera:GameObject = GameObject.Find("Light");
		camera.SendMessage("GetPoint", score);
		var flag = GameObject.FindWithTag("Flag");
		flag.GetComponent.<AudioSource>().Play();
	}

	if (collider.tag == "Player" && flagCount <= getFlag) {
		ShurioRotate(collider);
		if (Application.loadedLevel == LOAD_LEVEL_START) {
			SceneManager.LoadScene("Start", LoadSceneMode.Single);
		} else if (Application.loadedLevel == LOAD_LEVEL_STAGE1_1) {
			SceneManager.LoadScene("Start", LoadSceneMode.Additive);
		} else if (Application.loadedLevel == LOAD_LEVEL_STAGE1_2) {
			SceneManager.LoadScene("Start", LoadSceneMode.Additive);
		} else if (Application.loadedLevel == LOAD_LEVEL_STAGE1_3) {
			SceneManager.LoadScene("Start", LoadSceneMode.Additive);
		} else if (Application.loadedLevel == LOAD_LEVEL_STAGE2_1) {
			SceneManager.LoadScene("Start", LoadSceneMode.Additive);
		} else {
			SceneManager.LoadScene("End");
		}
	}

	if (collider.tag == "Flag" && flagCount <= getFlag) {
			SceneManager.LoadScene("Win");
	}

	if (collider.tag != "Boss" && collider.tag != "Enemy" && collider.tag != "Player") {
		Destroy(collider.gameObject);
	}
}

function ShurioRotate(collider:Collider2D) {
	collider.gameObject.transform.position = Vector2(posiX, posiY);
	var posi:Vector2 = this.gameObject.transform.position;
	var shurio_posi:Vector2 = collider.gameObject.transform.position;
	var shurio_muki:Quaternion = collider.gameObject.transform.rotation;
	if (shurio_muki.y > 90 && shurio_muki.y < -90) {
		// 左に向いている
		collider.gameObject.SendMessage("InitRotate", true);
	} else {
		// 右に向いている
		collider.gameObject.SendMessage("InitRotate", false);
	}
}