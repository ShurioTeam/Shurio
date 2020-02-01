using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuriboInstantiate : MonoBehaviour {
	public GameObject kuribo;
	public float sleep = 500.0f;
	private float time = 0.0f;
	public float high_time = 4.0f;
	public float low_time = 2.0f;
	public float posiX = -6.0f;
	public float posiY = 14.0f;

	// Use this for initialization
	void Start () {
		time = 0.0f;		
	}
	
	// Update is called once per frame
	void Update () {
		if (sleep <= time) {
			Vector3 posi = new Vector3(Random.Range(posiX, posiY), 10, 0);
			GameObject.Instantiate(kuribo, posi, Quaternion.identity);
			//		kuribos.GetComponent<AudioSource>().Play();
			time = 0.0f;
		}
		time += Random.Range(low_time,high_time) * Time.deltaTime;
	}
}
