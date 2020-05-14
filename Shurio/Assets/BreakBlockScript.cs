using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlockScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BreakBlock(bool breakFlag) {
        if (breakFlag) {
            Animator anime = this.gameObject.GetComponent<Animator>();
            anime.SetBool("breaking", true);
            Destroy(this.gameObject, 2.0f);
        }
    }
}
