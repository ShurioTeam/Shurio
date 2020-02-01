using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinoko : MonoBehaviour {
	public MushroomType mushType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {
			if (mushType == MushroomType.Red) {
				collider.gameObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
				Destroy(this.gameObject, 1.0f);
			} else if (mushType == MushroomType.Green) {
				collider.gameObject.transform.localScale = new Vector3(0.40f, 0.40f, 0.40f);
				Destroy(this.gameObject, 3.0f);
			} else if (mushType == MushroomType.Blue) {
				collider.gameObject.transform.localScale = new Vector3(0.30f, 0.30f, 0.30f);
				Destroy(this.gameObject, 1.0f);
			}
		}
	}

}

public enum MushroomType {
	Red   = 1,
	Green = 2,
	Blue  = 3,
}

