﻿#pragma strict

public var kame:GameObject;
public var sleep:float = 500.0f;
private var time:float = 0.0f;
public var high_time:float = 4.0f;
public var low_time:float = 2.0f;
public var posiX:float = -6.0f;
public var posiY:float = 14.0f;
function Start () {
	time = 0.0f;
}

function Update () {
	if (sleep <= time) {
		var posi:Vector3 = new Vector3(Random.Range(posiX, posiY), 10, 0);
		var kames:GameObject = GameObject.Instantiate(kame, posi, Quaternion.identity) as GameObject;
//		kames.GetComponent.<AudioSource>().Play();
		time = 0.0f;
	}
	time += Random.Range(low_time,high_time) * Time.deltaTime;
}