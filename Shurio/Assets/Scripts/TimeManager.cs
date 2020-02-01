using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
	public long limit;
	public GUIText scoreBoad;

	private float time;
	private float limitTime;
	private float ltime;
	private int score;
	private GameObject scoreObject;
	
    // Start is called before the first frame update
    void Start()
    {
		scoreObject = GameObject.Find("Score");
		if (scoreObject != null) {
			scoreBoad = scoreObject.GetComponentInChildren<GUIText>();
			scoreBoad.text = "制限時間:" + limit + "\r\nスコアー:" + score + "点";
		}
    }

    // Update is called once per frame
    void Update()
    {
		time += Time.deltaTime;

		ltime = Mathf.Floor(limit - time);
		if (ltime <= 0) {
			Application.LoadLevel("End");
		}

		scoreBoad.text = "制限時間:" + ltime + "\r\nスコアー:" + score + "点";
        
    }
    void GetPoint(int score) {
		this.score = score;
		ltime = Mathf.Floor(limit - time);
		scoreBoad.text = "制限時間:" + ltime + "\r\nスコアー:" + score + "点";
	}
}

