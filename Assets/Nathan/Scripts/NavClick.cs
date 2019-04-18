using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavClick : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    private Ray shootRay;
    private RaycastHit shootHit;
    private bool walking;
    public GameObject walkpointer;

    // Use this for initialization
    void Awake()
    {
        //swalkpointer = GetComponent<>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetButtonDown("Fire2"))
        {
            if (Physics.Raycast(ray, out hit, 100))

            {
                walking = true;
                navMeshAgent.destination = hit.point;
            }
        }

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
        if (!navMeshAgent.hasPath || Mathf.Abs(navMeshAgent.velocity.sqrMagnitude) < float.Epsilon)
                walking = false;
        }
        else
        {
                walking = true;
        }
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
           // navMeshAgent.isStopped = true;
        }
    }
}