using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebirdScript : MonoBehaviour {
	public GameObject shurio;
	public GameObject fire;
	public float power = 0.005f;
	public float bulletPower = 25.0f;
	public float bulletInterval = 2.0f;
	public float bulletLive = 10.0f;
	public int HP = 40;
	private float time = 0.0f;
	private bool lightningFlg = false;
	private bool greenLightFlg = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > bulletInterval) {
			GameObject bullet = GameObject.Instantiate(fire, this.transform);
			bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1,0)*bulletPower);
			Destroy(bullet, bulletLive);
			time = 0.0f;
		}

		if (shurio != null) {
			Vector2 direction = new Vector2(0, shurio.transform.position.y - this.transform.position.y);
			this.GetComponent<Rigidbody2D>().AddForce(direction * power);
		}

		if (lightningFlg) {
			Vector3 myscale =this.gameObject.transform.localScale;
			if (myscale.x > 0.1f) {
				this.gameObject.transform.localScale = new Vector3(myscale.x * 0.95f, myscale.y * 0.95f, myscale.z * 0.95f);
			}
		}

		if (greenLightFlg) {
			Vector3 myscale =this.gameObject.transform.localScale;
			if (myscale.x > 1.25f) {
				this.gameObject.transform.localScale = new Vector3(myscale.x * 1.05f, myscale.y * 1.05f, myscale.z * 1.05f);
			}
		}

        Debug.Log("HP:" + HP);
        if (HP < 0) {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 100, 0));
            Destroy(this.gameObject, 3.0f);
        }

	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "item_lightning") {
			lightningFlg = true;
		} else if (collider.tag == "item_greenLight") {
			greenLightFlg = true;
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "item_fire" || collision.gameObject.tag == "item_greenLight" || collision.gameObject.tag == "item_lightning") {
            HP--;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce((this.gameObject.transform.position - collision.transform.position) * 5.0f);
        }
	}
}
