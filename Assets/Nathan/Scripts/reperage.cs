using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;


public class reperage : MonoBehaviour
{
    public bool repere = false;
    public bool zone = false;
    public Vector3 Objectif1;
    public Vector3 Objectif2;
    public Vector3 PlayerPos;
    public Vector3 EnnemyHead;
    public GameObject HeadL;
    public GameObject HeadR;
    public GameObject Ennemy;
    public GameObject player;
    public float distance = 200f;
    public float timer = 0f;
    public NavMeshAgent agent;
    bool cherche = false;
    public Collider headcolliderl;
    public Collider headcolliderr;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    
    void Update()
    {
        EnnemyHead = Ennemy.transform.position;
        Objectif1 = (HeadL.transform.position - EnnemyHead);
        Objectif2 = (HeadR.transform.position - EnnemyHead);


        if (zone)
        {
            RaycastHit hit;
            if (Physics.Raycast(EnnemyHead, Objectif1, out hit, distance) || Physics.Raycast(EnnemyHead, Objectif2, out hit, distance))
            {
                Debug.Log(hit.transform.name);
                Debug.DrawRay(EnnemyHead, Objectif1 * distance, Color.yellow);
                Debug.DrawRay(EnnemyHead, Objectif2 * distance, Color.yellow);

                if (hit.collider == headcolliderl || hit.collider == headcolliderr)
                {
                    Debug.DrawRay(EnnemyHead, Objectif1 * distance, Color.red);
                    Debug.DrawRay(EnnemyHead, Objectif2 * distance, Color.red);
                    repere = true;
                }
                else if (!hit.collider == headcolliderl && !hit.collider == headcolliderr)
                {
                    repere = false;
                }
            }
        }
        else if (!zone)
        {
            repere = false;
        }

        if (repere == true)
        {


            if (timer >= 3)
            {
                Debug.Log("Dead");
            }

            if (timer >= 1)
            {
                PlayerPos = player.transform.position;
                cherche = true;
                Debug.Log("walk");
            }
                timer = timer + Time.deltaTime;
        }

        if (repere == false)
        {
            timer = 0;
            cherche = false;
        }

        if (cherche == true)
        {
            agent.destination = PlayerPos;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == HeadL || other.gameObject == HeadR)
        {
            zone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == HeadL || other.gameObject == HeadR)
        {
            zone = false;
        }
    } 
}
