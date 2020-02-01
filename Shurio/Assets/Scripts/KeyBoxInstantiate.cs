using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoxInstantiate : MonoBehaviour
{
    // public GameObject keyBoxObj;
    public float posiX;
    public float posiY;
    private Vector3 posi;
    private bool showKeyBoxFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        posi = new Vector3(posiX, posiY, 0);
        this.gameObject.GetComponent<Rigidbody2D>().mass = 0;
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (showKeyBoxFlag) {
//            GameObject keyBox = GameObject.Instantiate(keyBoxObj, posi, Quaternion.identity);
            this.gameObject.GetComponent<Rigidbody2D>().mass = 1;
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            this.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    public void ShowKeyBox(bool flag) {
        this.showKeyBoxFlag = flag;
    }
}
