using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPoint : MonoBehaviour
{
    public bool onp=false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.tag =="ennemybody")
        onp = true;
        Destroy(gameObject);
    }
}
