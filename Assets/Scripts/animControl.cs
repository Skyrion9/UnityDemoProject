using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animControl : MonoBehaviour
{

    new Animator animation;
    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.U))
        {
            rotateStart();
        }
        else
        {
            animation.SetBool("Active", false);
        }
    }

    void rotateStart()
    {
        animation.SetBool("Active", true);
    }
}
