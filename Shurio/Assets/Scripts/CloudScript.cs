using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public string aorioName;
    public float power;
    public float floatPower;
    public float maxHight = 10.0f;
    private bool stayCloud = false;
    private Vector3 posi;
    // Start is called before the first frame update
    void Start()
    {
        posi = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Start") > 0.0f) {
            if (stayCloud) {
                stayCloud = false;
                this.gameObject.GetComponent<BoxCollider2D>().isTrigger=true;
            }
        } else {
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger=false;
        }

        if (stayCloud) {
            GameObject aorio = GameObject.Find(aorioName);
            Vector3 target_posi = this.gameObject.transform.position;
            if (maxHight < target_posi.y - posi.y) {
                this.gameObject.transform.position = new Vector3(target_posi.x, posi.y + maxHight, target_posi.z);
            }
            if (Input.GetAxis("Enter") > 0.0f) {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, -10.0f, 0));
            }
            aorio.transform.position = this.gameObject.transform.position + new Vector3(0, 0.8f, 0);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == aorioName) {
            stayCloud = true;
        }
    }

    public void OnCollisionStay2D(Collision2D collision) {
        if (stayCloud && collision.gameObject.name == aorioName) {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(x, y * floatPower, 0) * power);
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale= 0.0f;
            collision.gameObject.transform.position = this.gameObject.transform.position + new Vector3(0, 0.8f, 0);

            GameObject camera = GameObject.Find("Main Camera");
            camera.SendMessage("setStatus", new bool[]{true, false, false});
        }
    }

    public void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.name == aorioName) {
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        }
    }
}
