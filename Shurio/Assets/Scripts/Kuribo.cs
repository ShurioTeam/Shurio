using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kuribo : MonoBehaviour {
	float direction;
	public float power = 5.0f;
	public float MASS;
	public float throw_time = 2.0f;

	// Use this for initialization
	void Start () {
		if (Random.value > 0.5f) {
			direction = 1.0f;
		} else {
			direction = -1.0f;
		}
		MASS = this.gameObject.GetComponent<Rigidbody2D>().mass;
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(power, 0) * direction);
	}

	void NowThrowing() {
		BoxCollider2D[] collider = this.gameObject.GetComponentsInChildren<BoxCollider2D>();
		PhysicsMaterial2D material = new PhysicsMaterial2D();
		material.friction = 0.0f;
		material.bounciness = 1.0f;
		collider[0].sharedMaterial = material;
		float time = 0.0f;
		while (time < throw_time) {
			time += Time.deltaTime;
		}
		collider[0].sharedMaterial = null;
		SetMass();
	}

	void SetMass() {
		this.gameObject.GetComponent<Rigidbody2D>().mass = MASS;
	}
}
