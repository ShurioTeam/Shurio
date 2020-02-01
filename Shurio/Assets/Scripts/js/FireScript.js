﻿#pragma strict

public var fire:GameObject;
public var sleep:float = 10.0f;
private var time:float = 0.0f;
public var high_time:float = 0.0f;
public var low_time:float = 2.0f;
public var live_time:float = 2.0f;
public var posiX:float = -6.0f;
public var posiY:float = 14.0f;
function Start () {

}


function Update () {
	if (sleep <= time) {
		var posi:Vector3 = new Vector3(Random.Range(posiX, posiY), 10, 0);
		var fires:GameObject = GameObject.Instantiate(fire, posi, Quaternion.identity) as GameObject;
		fires.GetComponent.<AudioSource>().Play();
		Destroy(fires, live_time);
		time = 0.0f;
	}
	time += Random.Range(low_time, high_time) * Time.deltaTime;
}