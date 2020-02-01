using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TogePukuScript : MonoBehaviour {

	public float SinWidth;
	public float SinSpeed;
	public float movePower;
	public float resistance;
	public string shurioName;
	public float deathTime;
	private GameObject shurio;
	private bool rotation;
	public TogePukuScript() {
		SinWidth = 10.0f;
		SinSpeed = 5.0f;
		movePower = 0.1f;
		resistance = 0.08f;
		deathTime = 3.0f;
	}

	// Use this for initialization
	void Start () {

		rotation = true;
	}

	public void SetShurio() {
		Scene shurioScene = SceneManager.GetSceneByName("Shurio");
		GameObject[] shurioObjs = shurioScene.GetRootGameObjects();
		foreach (GameObject shurioObj in shurioObjs) {
			if (shurioObj.name == shurioName) {
				shurio = shurioObj;
			}
		}
	}
	// Update is called once per frame
	void Update () {
		if (shurio == null) {
			SetShurio();
			if (shurio == null) {
				return;
			}
		}

		Vector2 posi = this.transform.position;
		this.gameObject.transform.position = posi + new Vector2(0, Mathf.Sin(Time.time * SinSpeed) * SinWidth);
		Vector2 shurio_posi = shurio.transform.position;

		if (shurio_posi.x - posi.x > 0) {
			this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(movePower, 0));
			// 水の抵抗力
			this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(resistance * -1, 0));

			if (rotation) {
				this.gameObject.transform.Rotate(new Vector3(0, 180, 0));
				rotation = false;
			}
		} else if (shurio_posi.x - posi.x < 0) {
			this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1 * movePower, 0));
			// 水の抵抗力
			this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(resistance, 0));

			if (!rotation) {
				this.gameObject.transform.Rotate(new Vector3(0, -180, 0));
				rotation = true;
			}
		}
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log("Attack:" + collider.tag);
		if (collider.tag == "Weapon") {
			Destroy(this.gameObject, deathTime);
		}
	}
}
