﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiMove : MonoBehaviour
{

     public Transform destination;
     NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(navMeshAgent == null)
        {
            Debug.LogError("Nav Mesh component is not attached" + gameObject.name);
        }
        else
        {
            SetDestination();
            
        }
    }

    private void SetDestination()
    {
        if(destination != null)
        {
            
            Vector3 targetVector = destination.transform.position;
            navMeshAgent.SetDestination(targetVector);
            FindObjectOfType<AuidoManager>().Play("RobotMove");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
