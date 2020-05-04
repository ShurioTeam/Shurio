using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {
	public GameObject camera1;
	public GameObject camera2;

	private const int MAX_DEPTH = 3;
	// Use this for initialization
	void Start () {
		camera1.SetActive(true);
		camera2.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		float action = Input.GetAxis("LT_Joy1");
		Debug.Log("Camera Switch");
		if (action > 0.0f) {
			if (camera1.active) {
				Debug.Log("Camera Switch2");
				camera1.SetActive(false);
				camera2.SetActive(true);
			} else if (camera2.active) {
				Debug.Log("Camera Switch1");
				camera1.SetActive(true);
				camera2.SetActive(false);
			}
		}
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player_bk") {
			camera1.GetComponent<Camera>().depth += 1;
			camera2.GetComponent<Camera>().depth += 1;
			if (camera1.GetComponent<Camera>().depth > MAX_DEPTH) {
				camera1.GetComponent<Camera>().depth = 0;
			}

			if (camera2.GetComponent<Camera>().depth > MAX_DEPTH) {
				camera2.GetComponent<Camera>().depth = 0;
			}
		}

		if (collider.tag == "Player") {
			camera1.SetActive(true);
		}
	}

	public void OnTriggerExit2D(Collider2D collider) {
		if (collider.tag == "Player") {
			if (camera2.active) {
				camera1.SetActive(false);
			}
		}
	}
}
