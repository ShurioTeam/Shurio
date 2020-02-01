using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
	public float throw_time = 10.0f;
	public float CHEST_MASS = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
		CHEST_MASS = this.gameObject.GetComponent<Rigidbody2D> ().mass;
    }

    // Update is called once per frame
    void Update()
    {
    }

	void NowThrowing() {
		BoxCollider2D collider = this.gameObject.GetComponentInChildren<BoxCollider2D> ();
		PhysicsMaterial2D material = new PhysicsMaterial2D ();
		material.friction = 0.0f;
		material.bounciness = 1.0f;
		collider.sharedMaterial = material;
		float time = 0.0f;
		while (time < throw_time) {
			time += Time.deltaTime;
		}
		collider.sharedMaterial = null;
		SetMass ();
	}

	void SetMass() {
		this.gameObject.GetComponent<Rigidbody2D> ().mass = CHEST_MASS;
	}
}
