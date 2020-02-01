using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowScript : MonoBehaviour {
	public string shurio_name;
	private GameObject shurio;
	public float power = 10.0f;
	public float resistance = 5.0f;
	public float deathTime = 3.0f;
	private bool rotateFlg = false;
	private bool lightningFlg = false;
	private bool greenLightFlg = false;
	// Use this for initialization
	void Start () {
		if (shurio == null) {
			shurio = GameObject.Find(shurio_name);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (shurio != null) {
			Vector2 direction = new Vector2(shurio.transform.position.x - this.transform.position.x, shurio.transform.position.y - this.transform.position.y); 
			if (direction.x > 0) {
				if (rotateFlg) {
					this.transform.Rotate(new Vector3(0, 180, 0));
					rotateFlg = false;
				}
			} else {
				if (!rotateFlg) {
					this.transform.Rotate(new Vector3(0, 180, 0));
					rotateFlg = true;
				}
			}

			Vector2 minus_direction = new Vector2(direction.x, direction.y / 3);
			this.GetComponent<Rigidbody2D>().AddRelativeForce(direction.normalized * power - minus_direction.normalized * resistance);
		}

		if (lightningFlg) {
			Vector3 myscale =this.gameObject.transform.localScale;
			if (myscale.x > 0.1f) {
				this.gameObject.transform.localScale = new Vector3(myscale.x * 0.9f, myscale.y * 0.9f, myscale.z * 0.9f);
			}
		}

		if (greenLightFlg) {
			Vector3 myscale =this.gameObject.transform.localScale;
			if (myscale.x < 0.5f) {
				this.gameObject.transform.localScale = new Vector3(myscale.x * 1.1f, myscale.y * 1.1f, myscale.z * 1.1f);
			}
		}
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {
			Vector3 posi = this.transform.position;
			Vector3 player = collider.transform.position;
			Vector3 direction = posi - player;

			if (direction.y < 0) {
				this.GetComponent<Rigidbody2D>().gravityScale = 10;
				Destroy(this.gameObject, deathTime);
			}
		} else if (collider.tag == "Weapon") {
			Destroy(this.gameObject, deathTime);
		} else if (collider.tag == "item_lightning") {
			lightningFlg = true;
		} else if (collider.tag == "item_greenLight") {
			greenLightFlg = true;
		}
	}
}
