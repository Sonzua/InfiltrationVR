using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{

    public  float debugDrawRadius = 0.5f;
    public virtual void OnDrawGuizmo()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, debugDrawRadius);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
