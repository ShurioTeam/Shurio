﻿#pragma strict

public var chest1:GameObject;
public var chest2:GameObject;
public var chest3:GameObject;
public var chest4:GameObject;
public var chest5:GameObject;
public var chest6:GameObject;
public var sleep:float = 10.0f;
private var time:float = 0.0f;
public var high_time:float =5.0f;
public var low_time:float = 1.0f;
public var posiX:float = -6.0f;
public var posiY:float = 14.0f;
function Start () {
}


function Update () {
	if (sleep <= time) {
		time = 0.0f;
		var posi:Vector3 = new Vector3(Random.Range(posiX, posiY), 10, 0);
		var idx:int = Random.Range(1,7);
		var chest:GameObject;
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
		var chests:GameObject = GameObject.Instantiate(chest, posi, Quaternion.identity) as GameObject;
		chests.GetComponent.<AudioSource>().Play();
		// Destroy(chests, 2.0F);
	}
	time += Random.Range(low_time,high_time) * Time.deltaTime;
}

function OnTriggerEnter2D(collider:Collider2D) {
	if (collider.tag == "Player") {
		//Destroy(this.gameObject);
	}
}