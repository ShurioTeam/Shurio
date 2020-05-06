using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogezoScript : MonoBehaviour
{
	public int high_power = 6;
	public int low_power = 4;
    public float power;

	private int direction;
	private GameObject togezo;
    // Start is called before the first frame update
    void Start()
    {
		togezo = this.gameObject;

		float dir = Random.Range (1.0f, 2.0f);
		if (dir <= 1.5f) {
			direction = 1;
			togezo.transform.Rotate (0, 180, 0);
		} else {
			direction = -1;
		}
   }

    // Update is called once per frame
    void Update()
    {
		int power = Random.Range (low_power, high_power);
		togezo.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction, 0)* power);
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Vector3 target_posi = collision.gameObject.transform.position;
            Vector3 posi = this.gameObject.transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(target_posi.x - posi.x, 0, 0) * power);
        }
    }
}
