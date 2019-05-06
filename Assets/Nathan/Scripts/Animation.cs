using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator Anim;
    public GameObject myObject;
    public bool endanim =false;
    float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >1)
        {
            endanim = false;
        }
    }

    void EndAnim()
    {
        endanim = true;
        Anim.SetBool("turn", true);
        timer = 0;
    }
}
