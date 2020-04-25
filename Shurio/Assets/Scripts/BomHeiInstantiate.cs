using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomHeiInstantiate : MonoBehaviour
{
	public GameObject bom;
	public float sleep = 100.0f;
	public float high_time = 4.0f;
	public float low_time = 2.0f;
	public float posiX = -6.0f;
	public float posiY = 14.0f;

	private float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
		time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
		if (sleep <= time) {
			time = 0.0f;
			Vector3 posi = new Vector3(Random.Range(posiX, posiY), 10, 0);
			GameObject boms = GameObject.Instantiate(bom,posi, Quaternion.identity);
			boms.GetComponent<AudioSource>().Play();
		}
		time += Random.Range(low_time, high_time) * Time.deltaTime;
    }
}
