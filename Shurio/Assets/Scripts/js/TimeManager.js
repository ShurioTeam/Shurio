#pragma strict

public var limit:long;
private var time:float;
private var limitTime:float;
private var ltime:long;
private var score:int;
public var scoreBoad:GUIText;
private var scoreObject:GameObject;

function Start () {
	scoreObject = GameObject.Find("Score");
	if (scoreObject != null) {
		scoreBoad = scoreObject.GetComponentInChildren(GUIText);
		scoreBoad.text = "制限時間:" + limit + "\r\nスコアー:" + score + "点";
	}
}

function Update () {
	time += Time.deltaTime;

	ltime = Mathf.Floor(limit - time);
	if (ltime <= 0) {
		Application.LoadLevel("End");
	}

	scoreBoad.text = "制限時間:" + ltime + "\r\nスコアー:" + score + "点";

}

function GetPoint(score:int) {
	this.score = score;
	ltime = Mathf.Floor(limit - time);
	scoreBoad.text = "制限時間:" + ltime + "\r\nスコアー:" + score + "点";
}