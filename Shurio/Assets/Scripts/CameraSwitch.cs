using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {
	public GameObject camera1;
	public GameObject camera2;

	private const int MAX_DEPTH = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
