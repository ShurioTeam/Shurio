using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerInstantiate : MonoBehaviour
{
    public GameObject killer;
    public float sleep = 100.0f;
    public float posiMax = 15.0f;
    public float posiMin = 0.0f;
    public float high_time = 5.0f;
    public float low_time = 2.0f;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= sleep) {
            Vector3 posi = new Vector3(-10, Random.Range(posiMax, posiMin), 0);
            GameObject.Instantiate(killer, posi, Quaternion.identity);
            time = 0.0f;
        }
        time += Random.Range(high_time, low_time) * Time.deltaTime;
    }
}
