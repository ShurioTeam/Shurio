using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RengaScriptVertical : MonoBehaviour {
	private float xValue;
	public float maxHeight = 0.1f;
	public float theta = 1.0f;
	private Vector3 basePosi;
	// Use this for initialization
	void Start () {
		basePosi = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		xValue += Time.deltaTime;
		this.gameObject.transform.position = basePosi + new Vector3(0, maxHeight * Mathf.Sin(xValue * theta), 0);
	}
}
