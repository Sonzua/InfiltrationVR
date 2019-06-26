using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;


public class reperage : MonoBehaviour
{
    public float stuntimer;
    public Collider view;
    public bool stun = false;
    public bool repere = false;     //repéré par raycast
    public bool zone = false;       //dans le champ de vision
    Vector3 Objectif1;       //position tete1
    Vector3 Objectif2;       //position tete2
    Vector3 PlayerPos;       //pos finale NavMesh
    public Vector3 EnnemyHead;      //pos ennemy
    public GameObject EnnemyAnimRotation;

    //-----------------> Partie Corps Joueur
    public GameObject HeadL;        
    public GameObject HeadR;
    public Collider headcolliderl;
    public Collider headcolliderr;
    //-----------------------------------//

    public GameObject Ennemy;
    public GameObject player;
    public float distance = 200f;
    public float timer = 0f;
    public NavMeshAgent agent;
    public bool cherche = false;


    public GameObject AnimScript;
    public bool endnavmesh=false;
    public GameObject ennemyall;
    public Transform ennemypos;
    public Animator EnnemyAnim;

    float morttimer = 2f;  //timer mort
    float cherchetimer = 1f; //timer cherche

    public float timeranim;
    public int luck;

    // Start is called before the first frame update
    void Start()
    {
        AnimScript.GetComponent<AnimationManager>();
    }

    // Update is called once per frame

    void Update()
    {
        if (timer > 0)
        {
            GameManager.instance.timer = timer;
        }


        EnnemyHead = Ennemy.transform.position;
        Objectif1 = (HeadL.transform.position - EnnemyHead);
        Objectif2 = (HeadR.transform.position - EnnemyHead);


        if (stun == true)
        {
            EnnemyAnim.SetBool("dead", true);
            EnnemyAnim.SetBool("turn", false);
            stuntimer += Time.deltaTime;
            if (stuntimer >= 5)
            {
                EnnemyAnim.SetBool("dead", false);
                stun = false;
                stuntimer = 0;
            }
        }
        if (stun==false)
        {

            timeranim += Time.deltaTime;

            if(timeranim >= 3 && timer<cherchetimer)
            {
                luck = UnityEngine.Random.Range(1, 5);
                if (luck <= 1)
                {
                    EnnemyAnim.SetBool("wait1", true);
                    timeranim = 0;
                }
                if (luck > 2)
                {
                    EnnemyAnim.SetBool("wait2", true);
                    timeranim = 0;
                }
                else
                {
                    timeranim = 0;
                }
            }
            if (timeranim >= 1 && timeranim<=3)
            {
                EnnemyAnim.SetBool("wait2", false);
                EnnemyAnim.SetBool("wait1", false);
            }

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
                    else
                    {
                        repere = false;
                    }
                }
            }
        }

        if (!zone)
        {
            repere = false;
        }

        if (stun == false)
        {

            if (repere == true)
            {
                if(timer <= morttimer)
                {
                    timer += Time.deltaTime;
                }

                if (timer >= 0.5f)
                {

                    Vector3 difference = HeadL.transform.position - EnnemyAnimRotation.transform.position;
                    float rotationY = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
                    EnnemyAnimRotation.transform.rotation = Quaternion.Lerp(EnnemyAnimRotation.transform.rotation, Quaternion.Euler(0.0f, rotationY, 0.0f), 5 * Time.deltaTime);
                }

                if (timer >= cherchetimer)
                {
                    //EnnemyAnimRotation.transform.localRotation = Quaternion.Lerp(EnnemyAnimRotation.transform.localRotation, Quaternion.identity, 5 * Time.deltaTime);
                    PlayerPos = player.transform.position;
                    cherche = true;
                    //EnnemyAnim.enabled = false;
                }
                else
                {
                    cherche = false;
                }

                if (timer >= morttimer)
                {

                }

            }
        }

        //if (timer < cherchetimer)
        {
           // cherche = false;
        }

        if (repere == false || stun ==true)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime * 0.5f;
            }
        }

        if (stun == false)
        {

            if (cherche == true)
            {
                agent.destination = PlayerPos;
                if (Vector3.Distance(agent.destination, agent.transform.position) <= agent.stoppingDistance)

                //if (Vector3.Distance(agent.destination, agent.transform.position) <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        Debug.Log("endnavmesh");
                        EnnemyAnim.SetBool("turn", true);
                        endnavmesh = false;
                        cherche = false;
                    }
                }
            }
        }

        // ------------->  FinNavMesh


        if (EnnemyAnim.GetBool("turn") == true)
        {
            //EnnemyAnim.enabled = false;
        }
    }

    void EndNav()
    {
        endnavmesh = true;
        EnnemyAnim.Play("turn", -1, 0f);
    }

    public void EndAnimEnnemy()
    {

    }
    // -------------------->  End
}
