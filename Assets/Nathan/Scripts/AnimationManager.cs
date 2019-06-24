using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator Anim;
    public bool endanim =false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void EndAnim()
    {
        endanim = true;
        Anim.SetBool("turn", false);
    }
}
