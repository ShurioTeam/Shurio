using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinoko : MonoBehaviour {
	public MushroomType mushType;
	private Vector3 shurioSize;
	private Vector3 aorioSize;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {
			Vector3 beforeSize = collider.gameObject.transform.localScale;
			if (mushType == MushroomType.Red) {
				if (beforeSize.x > 0.05f) {
					collider.gameObject.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
				}
				Destroy(this.gameObject, 1.0f);
			} else if (mushType == MushroomType.Green) {
				collider.gameObject.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
				Destroy(this.gameObject, 3.0f);
			} else if (mushType == MushroomType.Blue) {
				collider.gameObject.SendMessage("setDefaultSize");
				Destroy(this.gameObject, 1.0f);
			}
		}
	}

	public void setShurioSize(Vector3 size) {
		this.shurioSize = size;
	}
	public void setAorioSize(Vector3 size) {
		this.aorioSize = size;
	}
}

public enum MushroomType {
	Red   = 1,
	Green = 2,
	Blue  = 3,
}

