using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public int flagCount = 3;
	public string shurioName;
	public string loadStage;
	public string nextStage;
	public float posiX = 5.0f;
	public float posiY = 10.0f;

	private int getFlag = 0;
	private int score = 0;
	private const int LOAD_LEVEL_START = 0;
	private const int LOAD_LEVEL_STAGE1_1 = 1;
	private const int LOAD_LEVEL_STAGE1_2 = 2;
	private const int LOAD_LEVEL_STAGE1_3 = 3;
	private const int LOAD_LEVEL_STAGE2_1 = 4;
	private bool flag = false;
	private float time = 0.0f;
	private float limit = 5.0f;
	private bool rotateFlg = false;

    // Start is called before the first frame update
    void Start()
    {
        getFlag = 0;
		GameObject board = GameObject.Find("BOARD");
		//board.SendMessage("SetClearFlagCount", flagCount);
    }

    // Update is called once per frame
    void Update()
    {
		if (flag) {
			if (time > limit) {
				flag = false;
			}
			time += Time.deltaTime * 1.0f;
		}
    }

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {
			if (!flag) {
				flag = true;
				time = 0.0f;
				//SceneManager.SetActiveScene(scene);
				collider.gameObject.transform.position = new Vector2(0, 10);
				collider.gameObject.SendMessage("InWater", false);
		//		SceneManager.MoveGameObjectToScene(shurio, scene);

				for (int i = 0;i < SceneManager.sceneCount; i++) {
					Scene scene = SceneManager.GetSceneAt(i);
					SceneManager.UnloadSceneAsync(scene.name);
				}
//				SceneManager.LoadScene(shurioName, LoadSceneMode.Single);
				SceneManager.LoadScene(loadStage, LoadSceneMode.Single);
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
			GameObject clearCondition = GameObject.Find("BOARD");
			clearCondition.SendMessage("SetFlagNum", getFlag);
			GameObject flag = GameObject.FindWithTag("Flag");
			flag.GetComponent<AudioSource>().Play();
		}

		if (collider.tag == "Player" && flagCount <= getFlag) {
			ShurioRotate(collider);
			if (Application.loadedLevel == LOAD_LEVEL_START) {
				SceneManager.LoadScene(loadStage, LoadSceneMode.Single);
			} else if (Application.loadedLevel == LOAD_LEVEL_STAGE1_1) {
				SceneManager.LoadScene(loadStage, LoadSceneMode.Single);
			} else if (Application.loadedLevel == LOAD_LEVEL_STAGE1_2) {
				SceneManager.LoadScene(loadStage, LoadSceneMode.Additive);
			} else if (Application.loadedLevel == LOAD_LEVEL_STAGE1_3) {
				SceneManager.LoadScene(loadStage, LoadSceneMode.Additive);
			} else if (Application.loadedLevel == LOAD_LEVEL_STAGE2_1) {
				SceneManager.LoadScene(loadStage, LoadSceneMode.Additive);
			} else {
				SceneManager.LoadScene(loadStage);
			}
		}

		if (collider.tag == "Flag" && flagCount <= getFlag) {
			GameObject keyBox = GameObject.Find("KeyBox");
			if (keyBox != null) {
				keyBox.SendMessage("ShowKeyBox", true);
			} else {
				SceneManager.LoadScene(nextStage, LoadSceneMode.Single);
			}
		}

		if (collider.tag != "Boss" && collider.tag != "Enemy" && collider.tag != "Player") {
			Destroy(collider.gameObject);
		}

	}
	
	void ShurioRotate(Collider2D collider) {
		collider.gameObject.transform.position = new Vector2(posiX, posiY);
	}
}
