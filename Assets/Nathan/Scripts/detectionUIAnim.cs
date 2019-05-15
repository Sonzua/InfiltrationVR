using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionUIAnim : MonoBehaviour
{

    float detection;
    public Animator Anim;
    public Animator Anim2;
    public Animator Anim3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        detection = GameManager.instance.timer;

        if (detection > 0)
        {
            Anim.SetBool("DetectUI", true);
            Anim2.SetBool("DetectUI", true);
            Anim3.SetBool("DetectUI", true);

        }

        if (detection <= 0)
        {
            Anim.SetBool("DetectUI", false);
            Anim2.SetBool("DetectUI", false);
            Anim3.SetBool("DetectUI", false);

        }
    }
}
