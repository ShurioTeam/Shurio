using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStageScript : MonoBehaviour
{
    public string currentStageId;
    public string stage1;
    public string stage2;
    public string stage3;
    public string stage4;
    public string stage5;
    public string stage6;
    public string nextStage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextStageClick() {
        Debug.Log("NextStageClick");
        switch (currentStageId) {
        case "1":
            SceneManager.LoadScene(nextStage, LoadSceneMode.Additive);
            nextStage = stage3;
            currentStageId = "2";
            break;
        case "2":
            SceneManager.LoadScene(nextStage, LoadSceneMode.Additive);
            nextStage = stage4;
            currentStageId = "3";
            break;
        case "3":
            SceneManager.LoadScene(nextStage, LoadSceneMode.Additive);
            nextStage = stage5;
            currentStageId = "4";
            break;
        case "4":
            SceneManager.LoadScene(nextStage, LoadSceneMode.Additive);
            nextStage = stage6;
            currentStageId = "5";
            break;
        case "5":
            SceneManager.LoadScene(nextStage, LoadSceneMode.Additive);
            currentStageId = "6";
            break;
        default:
            break;
        }
    }
}
