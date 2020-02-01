using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameScript : MonoBehaviour
{
	public int high_power = 6;
	public int low_power = 4;
	public float KAME_MASS;
	public float wakeup_time = 10.0f;
	public float throw_time = 10.0f;

	private Animator anime;
	private int direction;
	private GameObject kame;
	private float kora_time;
    // Start is called before the first frame update
    void Start()
    {
		kame = this.gameObject;
		anime = kame.GetComponentInChildren<Animator> ();
		anime.SetBool ("InKora", false);
		kora_time = 0.0f;

		float dir = Random.Range (1.0f, 2.0f);
		if (dir <= 1.5f) {
			direction = 1;
			kame.transform.Rotate (0, 180, 0);
		} else {
			direction = -1;
		}
		KAME_MASS = kame.GetComponent<Rigidbody2D> ().mass;
   }

    // Update is called once per frame
    void Update()
    {
		int power = Random.Range (low_power, high_power);
		Vector3 vkame = kame.transform.localEulerAngles;
		bool inkora = anime.GetBool ("InKora");
		if (!inkora && (vkame.z >= -10 && vkame.z <= 10)) {
			kame.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction, 0)* power);
			kora_time = 0.0f;
		} else {
			anime.SetBool("InKora", true);
		}

		if (inkora) {
			if (kora_time > wakeup_time) {
				if (vkame.z >= -10 && vkame.z <= 10) {
					anime.SetBool("InKora", false);
				}
			}
			kora_time += 1 * Time.deltaTime;
		}
    }

	void OnTriggerEnter2D(Collider2D collider) {
		direction *= -1;
		kame.transform.Rotate (0, 180, 0);

		if (collider.tag == "Player") {
			Vector3 face = collider.gameObject.transform.position;
			Vector3 posi = kame.transform.position;
			if ((face - posi).y > 0 || (face - posi).y < 0) {
				anime.SetBool ("InKora", true);
			}
		}
	}

	void NowThrowing() {
		BoxCollider2D collider = kame.GetComponentInChildren<BoxCollider2D> ();
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
		kame.GetComponent<Rigidbody2D> ().mass = KAME_MASS;
	}
}
