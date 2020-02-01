using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
	public GameObject fire;
	public float sleep = 10.0f;
	private float time = 0.0f;
	public float high_time = 2.0f;
	public float low_time = 0.0f;
	public float live_time = 2.0f;
	public float posiX = -6.0f;
	public float posiY = 14.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (sleep <= time) {
			Vector3 posi = new Vector3 (Random.Range (posiX, posiY), 10, 0);
			GameObject fires = GameObject.Instantiate (fire, posi, Quaternion.identity);
			fires.GetComponent<AudioSource> ().Play ();
			Destroy (fires, live_time);
			time = 0.0f;
		}
		time += Random.Range (low_time, high_time) * Time.deltaTime;
    }
}
