using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
	public string stage;
	public string shurioScene;
	public string shurioName;
	public string aorioName;
	public float posiX = 5.0f;
	public float posiY = 10.0f;
	public bool needKeyBox = false;
	private bool hasKeyBox = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {
			if (needKeyBox) {
				if (!hasKeyBox) {
					return ;
				}
			}
			
			ShurioRotate (collider);

			for (int i = 0; i < SceneManager.sceneCount; i++) {
				Scene activeScene = SceneManager.GetSceneAt (i);
				Debug.Log (activeScene.name);
				if (activeScene.name != shurioScene) {
					SceneManager.UnloadSceneAsync (activeScene.name);
				}
			}
			SceneManager.LoadScene (stage, LoadSceneMode.Additive);
		}
	}

	void ShurioRotate(Collider2D collider) {
		collider.gameObject.transform.position = new Vector2 (posiX, posiY);
		if (collider.name == shurioName) {
			GameObject.Find(aorioName).transform.position = new Vector2(posiX,posiY);
		}
		if (collider.name == aorioName) {
			GameObject.Find(shurioName).transform.position = new Vector2(posiX,posiY);
		}
	}

	public void SetHasKeyBox(bool hasKeyBox) {
		this.hasKeyBox = hasKeyBox;
	}
}
