using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour {
	public float xpower;
	public float ypower;
	public float jumpPower;
	public float floatingPower;
	public GameObject waterflow;
	private Animator anime;
	private bool rotateFlg;
	private float fire_time;
	private bool isGrounded;
	private bool isWater;
	private bool isSky;
	private float GROUND_MASS;
	public float WATER_MASS;
	private bool waterEnabled;
	private float damageTime;
	private const float damageLimit = 3.0f;
	private bool damage = false;
	// Use this for initialization
	void Start () {
		anime = this.GetComponentInChildren<Animator>();
		fire_time = 5.0f;
//		this.gameObject.SendMessage("InWater", true);
		isGrounded = false;
		GROUND_MASS = this.gameObject.GetComponent<Rigidbody2D>().mass;
		waterEnabled = false;
		rotateFlg = false;
		anime.SetBool("Rotate", rotateFlg);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isWater) {
			return;
		}

		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		if (inputX > 0) {
			if (rotateFlg) {
				this.gameObject.transform.Rotate(0, 180, 0);
				rotateFlg = false;
				anime.SetBool("Rotate", rotateFlg);
			}
		} else if (inputX < 0) {
			if (!rotateFlg) {
				this.gameObject.transform.Rotate(0, 180, 0);
				rotateFlg = true;
				anime.SetBool("Rotate", rotateFlg);
			}
		}

		if (!isGrounded && (inputY != 0 || inputX != 0))	 {
			anime.SetBool("Swim", true);
		} else {
			anime.SetBool("Swim", false);
		}

		if (waterEnabled && Input.GetAxis("Fire1") > 0) {
			Debug.Log("Fire" + waterEnabled);
			if (fire_time > 0.5f) {
				fire_time = 0.0f;
				GameObject _waterflow = (GameObject)GameObject.Instantiate(waterflow, this.transform.position, Quaternion.identity);
				if (rotateFlg) {
					_waterflow.GetComponent<Rigidbody2D>().AddTorque(90);
					_waterflow.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000, 0));
				} else {
					_waterflow.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000, 0));
				}
				Destroy(_waterflow, 5.0f);
			}
		}

		if (damage && damageTime > damageLimit) {
			anime.SetBool("Hit", false);
			damage = false;
		}

		fire_time += Time.deltaTime * 1.0f;
		damageTime += Time.deltaTime;
	}

	void FixedUpdate() {
		if (!isWater) {
			return;
		}
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1) * floatingPower);

		if (inputY > 0) {
			this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1 * ypower));
			if (isGrounded) {
				this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1 * jumpPower));
			}
		} else if (inputY < 0) {
			this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1 * ypower));
		}

		if (inputX > 0) {
			this.GetComponent<Rigidbody2D>().AddForce(new Vector2(1 * xpower, 0));
		} else if (inputX < 0) {
			this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1 * xpower, 0));
		}

		if (isGrounded) {
			this.gameObject.GetComponent<Rigidbody2D>().mass = GROUND_MASS;
		} else {
			this.gameObject.GetComponent<Rigidbody2D>().mass = WATER_MASS;
			this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.01f;
		}

	}

	public void OnTriggerStay2D(Collider2D collision) {
		if (collision.tag == "Floor") {
			this.gameObject.SendMessage("IsGrounded", true);
			isGrounded = true;
		}
	}

	public void OnTriggerExit2D(Collider2D collider) {
		if (collider.tag == "Floor") {
			this.gameObject.SendMessage("IsGrounded", false);
			isGrounded = false;
		}
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "item_water") {
			waterEnabled = true;
			Destroy(collider.gameObject, 1);
		} else if (collider.tag == "Enemy2") {
			Vector2 posi = this.gameObject.transform.position;
			Vector2 enemy_posi = collider.gameObject.transform.position;
			if (posi.y - enemy_posi.y > 0) {
				anime.SetBool("Hit", true);
				damageTime = 0.0f;
				damage = true;
			}
		}
	}

	public void InWater(bool isWater) {
		this.isWater = isWater;
		Debug.Log("isWater:" + isWater);
	}

	public void InSky(bool isSky) {
		this.isSky = isSky;
	}

	public void InitRotate(bool value) {
		this.rotateFlg |= value;
		if (isWater) {
			anime.SetBool("Rotate", this.rotateFlg);
		}
		Debug.Log("water rotage:" + this.rotateFlg);
	}
}
