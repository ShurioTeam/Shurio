using UnityEngine;
using System.Collections;

public class TelopScript : MonoBehaviour {
	private double time = 0.0d;
	public double destroy_time = 1.0d;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (destroy_time <= time) {
			Destroy (this.gameObject);
		}
	}


}
