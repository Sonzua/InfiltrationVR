using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour
{

    public GameObject parent;

    // Use this for initialization
    void Start()
    {
        gameObject.transform.parent = parent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.parent = parent.transform;
    }
}
