using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKingScript : MonoBehaviour
{
    public string shurioName;
    public float power = 1000.0f;
    public int HP = 30;
    private float time = 0.0f;
    private bool attackFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("HP:" + HP);
        if (HP < 0) {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 100, 0));
            Destroy(this.gameObject, 3.0f);
        }
    }

    public void OnTriggerStay2D(Collider2D collider) {
        if (collider.tag == "Player" && !attackFlag) {
            Animator anime = this.gameObject.GetComponent<Animator>();
            anime.SetBool("Attack", true);
            GameObject shurio = GameObject.Find(shurioName);
            Vector3 shurioPosi = shurio.transform.position;
            Vector3 posi = this.gameObject.transform.position;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce((shurioPosi - posi) * power);
            attackFlag = true;
        } else if (collider.tag == "Player" && time >= 4.0f) {
            Animator anime = this.gameObject.GetComponent<Animator>();
            anime.SetBool("Attack", false);
            attackFlag = false;
            time = 0.0f;
        }
        time += 1 * Time.deltaTime;
    }

    public void OnTriggerExit2D(Collider2D collider) {
        if (collider.tag == "Player") {
            Animator anime = this.gameObject.GetComponent<Animator>();
            anime.SetBool("Attack", false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "item_fire" || collision.gameObject.tag == "item_greenLight" || collision.gameObject.tag == "item_lightning") {
            HP--;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce((this.gameObject.transform.position - collision.transform.position) * 5.0f);
        }
    }
}
