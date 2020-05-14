using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoalScript : MonoBehaviour
{
    public string nextStage;
    public string shurioScene;
    private bool hasKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
   			for (int i = 0; i < SceneManager.sceneCount; i++) {
				Scene activeScene = SceneManager.GetSceneAt (i);
				Debug.Log (activeScene.name);
				if (activeScene.name != shurioScene) {
					SceneManager.UnloadSceneAsync (activeScene.name);
				}
			}
			SceneManager.LoadScene (nextStage, LoadSceneMode.Additive);

        }
    }

    public void HasKey(bool hasKey) {
        this.hasKey = hasKey;
    }
}
