using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gabon : MonoBehaviour
{
	public GameObject ball;
	public GameObject shurio;
	private float timer;
	private float direct;
    // Start is called before the first frame update
    void Start()
    {
		timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime;

		if (timer > 3.0f) {
			timer = 0.0f;
			Vector3 direction = shurio.transform.position - this.gameObject.transform.position;
			direct = 1.0f;
			if (direction.x < 0) {
				direct = -1.0f;
			}
			GameObject _ball = GameObject.Instantiate (ball, this.gameObject.transform.position + new Vector3(direct, 0, 0), Quaternion.identity);
			_ball.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (direct * 200, 3));
			Destroy (_ball, 10.0f);
		}
    }

	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log (collider.tag);
		if (collider.tag == "item_lightning" || collider.tag == "player") {
			Vector3 direction = this.gameObject.transform.position - collider.gameObject.transform.position;
			direct = 1.0f;
			if (direction.x < 0) {
				direct = -1.0f;
			}
			this.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector3 (10, 2, 5));
			this.gameObject.GetComponent<Collider2D> ().isTrigger = true;
		}
	}
}
