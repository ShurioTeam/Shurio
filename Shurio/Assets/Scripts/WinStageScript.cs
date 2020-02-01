using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStageScript : MonoBehaviour
{
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
        SceneManager.LoadScene(nextStage, LoadSceneMode.Additive);
    }
}
