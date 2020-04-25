using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RengaScript : MonoBehaviour {
	public float maxWidth = 0.1f;
	public float theta = 2.0f;
	private float xValue;
	private Vector3 basePosi;
	// Use this for initialization
	void Start () {
		xValue = 0.0f;
		basePosi = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		xValue += Time.deltaTime;
		this.gameObject.transform.position = basePosi + new Vector3(maxWidth * Mathf.Sin(xValue * theta), 0, 0);
	}
}
