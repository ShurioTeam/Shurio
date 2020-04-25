using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
  public Boolean inWater = false;
  public Boolean waterFall = false;
	public String shurioName;
	private GameObject shurio;

    // Start is called before the first frame update
    void Start()
    {
		shurio = GameObject.Find(shurioName);
    }

    // Update is called once per frame
    void Update()
    {
      if (shurio == null) {
        shurio = GameObject.Find (shurioName);
      }
      if (shurio != null) {
        if (inWater) {
    		  this.gameObject.transform.localPosition = new Vector3 (shurio.transform.localPosition.x, shurio.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z);
        } else if (waterFall) {
    		  this.gameObject.transform.localPosition = new Vector3 (this.transform.localPosition.x, shurio.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z);
        } else {
    		  this.gameObject.transform.localPosition = new Vector3 (shurio.transform.localPosition.x, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z);
        }
      }
    }

    void GetPoint(int score) {
      Debug.Log("Get point Call!!!" + score);
    }
}
