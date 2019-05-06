using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour
{

    public GameObject parent;

    // Use this for initialization
    void Start()
    {
        Parent();
    }

    // Update is called once per frame
    void Update()
    {
        Updt();
    }

    public void Parent()
    {
        gameObject.transform.parent = parent.transform;
    }

    public void Updt()
    {
        gameObject.transform.parent = parent.transform;
    }
}



