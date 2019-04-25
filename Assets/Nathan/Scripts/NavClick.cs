using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using VRTK;

public class NavClick : MonoBehaviour
{

    public NavMeshAgent agent;
    public GameObject hand;
    public VRTK_Pointer pointer;
    public bool Nav = false;



    // Use this for initialization
    void Awake()
    {
        //swalkpointer = GetComponent<>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        pointer = hand.GetComponentInChildren<VRTK_Pointer>();
        if (Nav == true)
        {
            Vector3 reticle = pointer.pointerRenderer.GetDestinationHit().point;
            agent.destination = reticle;
            agent.isStopped = false;
        }
    }

    public void ActivationButtonReleased()
    {
        Vector3 reticle = pointer.pointerRenderer.GetDestinationHit().point;
        agent.destination = reticle;
        agent.isStopped = false;
    }
}