using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInstantiate : MonoBehaviour
{
	public GameObject chest1;
	public GameObject chest2;
	public GameObject chest3;
	public GameObject chest4;
	public GameObject chest5;
	public GameObject chest6;
	public float sleep = 10.0f;
	private float time = 0.0f;
	public float high_time = 5.0f;
	public float low_time = 1.0f;
	public float posiX = -6.0f;
	public float posiY = 14.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (sleep <= time) {
			time = 0.0f;
			Vector3 posi = new Vector3 (Random.Range (posiX, posiY), 10, 0);
			int idx = Random.Range (1, 7);
			GameObject chest = chest1;
			if (idx == 1) {
				chest = chest1;
			} else if (idx == 2) {
				chest = chest2;
			} else if (idx == 3) {
				chest = chest3;
			} else if (idx == 4) {
				chest = chest4;
			} else if (idx == 5) {
				chest = chest5;
			} else if (idx == 6) {
				chest = chest6;
			}
			GameObject chests = GameObject.Instantiate (chest, posi, Quaternion.identity);
			chests.GetComponent<AudioSource> ().Play ();
		}
		time += Random.Range (low_time, high_time) * Time.deltaTime;
    }

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {

		}
	}
}
