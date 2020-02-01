using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RetryClick() {
        Debug.Log("Retry!, Load start scene.");
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }
}
