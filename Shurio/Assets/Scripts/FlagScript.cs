using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour {
	public GameObject bird;
	public int posiX;
	public int bird_num = 1;
	// Use this for initialization
	private int num;
	private int direction = 1;
	void Start () {
		num = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {
			if (bird_num > num++) {
				int r = Random.Range(0, 2);
				if (r == 0) {
					direction = -1;
				}
				Vector3 posi = new Vector3(this.transform.position.x - posiX * direction, 10, 0);
				GameObject gbird = GameObject.Instantiate(bird, posi, Quaternion.identity);
			}
		}
	}
}
