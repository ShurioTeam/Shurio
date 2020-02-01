using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBlockScript : MonoBehaviour {
	public GameObject item;
	// Use this for initialization
	void Start () {
		item.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {
			if (item != null) {
				item.SetActive(true);
			}
		}
	}
}
