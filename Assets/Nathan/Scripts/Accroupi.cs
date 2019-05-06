using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Accroupi : MonoBehaviour
{
    public NavMeshAgent Agent;
    public GameObject HeadPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == HeadPlayer)
        {
            Agent.speed = 2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == HeadPlayer)
        {
            Agent.speed = 3;
        }
    }
}
