using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerScript : MonoBehaviour
{
    public float speed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(speed,0,0));
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Destroy(this.gameObject, 0.5f);
    }
}
