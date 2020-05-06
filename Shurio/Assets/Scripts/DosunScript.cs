using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DosunScript : MonoBehaviour
{
    public GameObject shurio;
    public float power;
    public bool directVertical = true;
    public bool directHorizontal = false;
    public bool directionRight = true;
    public bool directionLeft = false;
    private Vector3 posi;
    private bool moveFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        posi = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!moveFlag) {
            Vector3 now_posi = this.gameObject.transform.position;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce((posi - now_posi)*power);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if (directVertical) {
            if (collider.tag == "Floor") {
                moveFlag = false;
                Animator anime = this.gameObject.GetComponent<Animator>();
                anime.SetBool("Drop", false);
                this.gameObject.GetComponent<Rigidbody2D>().gravityScale  = 0.0f;
            }
            if (collider.tag == "Player") {
                moveFlag = true;
                Animator anime = this.gameObject.GetComponent<Animator>();
                anime.SetBool("Drop", true);
                this.gameObject.GetComponent<Rigidbody2D>().gravityScale  = 10.0f;
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collider) {
        if (directHorizontal) {
            if (collider.tag == "Player") {
                moveFlag = true;
                Animator anime = this.gameObject.GetComponent<Animator>();
                anime.SetBool("Drop", true);
                this.gameObject.GetComponent<Rigidbody2D>().gravityScale  = 10.0f;
                if (directionRight) {
                    this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(100,0,0) * power);
                } else if (directionLeft) {
                    this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-100,0,0) * power);
                }
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collider){
        if (collider.tag == "Player") {
            Animator anime = this.gameObject.GetComponent<Animator>();
            anime.SetBool("Drop", false);
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale  = 0.0f;
            moveFlag = false;
        }
    }
}
