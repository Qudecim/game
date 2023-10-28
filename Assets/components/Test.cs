using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Animation>().Play("Mini Simple Armature|Idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetBool("Run", true);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("Run", false);
        }
    }
}
