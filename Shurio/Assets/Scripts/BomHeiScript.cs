using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomHeiScript : MonoBehaviour
{
    private bool onFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collider) {
        if (onFlag) {
            if (collider.tag == "item_bom") {
                collider.gameObject.SendMessage("InvokeSwitchOn", 0.0f);
                Debug.Log("誘発爆破");
            }

            Vector3 target_posi = collider.gameObject.transform.position;
            Vector3 posi = this.gameObject.transform.position;
            Rigidbody2D rigidbody = collider.gameObject.GetComponent<Rigidbody2D>();
            if (rigidbody != null) {
                rigidbody.AddForce((target_posi - posi)*1000);
            }
            Animator anime = this.gameObject.GetComponent<Animator>();
            anime.SetBool("explode", true);
            Destroy(this.gameObject, 1.0f);
        }
    }

    public void InvokeSwitchOn(float time) {
        Invoke("SwitchOn", time);
    }
    void SwitchOn() {
        this.onFlag = true;
    }
}
