using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour {
	public GameObject mushrooms;
	public bool appearing = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {
			if (!appearing) {
				appearing = true;
				Vector3 margin = new Vector3(0, 1, 0);
				GameObject mushroom = GameObject.Instantiate(mushrooms, this.gameObject.transform.position + margin,Quaternion.identity);
				//mushroom.GetComponent<Rigidbody2D>().AddForce(new Vector3(5.0F, 0, 0));
			}
		}
	}
}
