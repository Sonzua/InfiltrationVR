using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;


public class reperage : MonoBehaviour
{

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

    public Animation AnimScript;
    public bool endnavmesh=false;
    public GameObject ennemyall;
    public Transform ennemypos;
    public Animator EnnemyAnim;

    float morttimer = 2f;  //timer mort
    float cherchetimer = 1f; //timer cherche



    // Start is called before the first frame update
    void Start()
    {
        AnimScript.GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        if (timer > 0)
        {
            GameManager.instance.timer = timer;
        }

        if (timer < 0)
        {
            timer = 0;
        }
        if (timer > 2)
        {
            timer = 2;
        }

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
                else
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

            if (timer >= 0.5f)
            {

                Vector3 difference = HeadL.transform.position - EnnemyAnimRotation.transform.position;
                float rotationY = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
                EnnemyAnimRotation.transform.rotation = Quaternion.Lerp(EnnemyAnimRotation.transform.rotation,Quaternion.Euler(0.0f, rotationY, 0.0f), 5 * Time.deltaTime);
            }
            if (timer >= morttimer)
            {
                Debug.Log("Dead");
            }

            if (timer >= cherchetimer)
            {
                //EnnemyAnimRotation.transform.localRotation = Quaternion.Lerp(EnnemyAnimRotation.transform.localRotation, Quaternion.identity, 5 * Time.deltaTime);
                PlayerPos = player.transform.position;
                cherche = true;
                EnnemyAnim.enabled = false;
                EnnemyAnim.SetBool("turn", false);  // ------------------------------------------------------ANIM !!! 
                Debug.Log("walk");
            }
            if (timer <= morttimer)
            {
                timer +=Time.deltaTime;

            }

        }

        if (repere == false && timer >=0)
        {
            timer -=Time.deltaTime*0.5f;
        }

        if (cherche == true)
        {
            agent.destination = PlayerPos;
        }


        // ------------->  FinNavMesh

        ennemypos = ennemyall.GetComponent<Transform>();
        if (ennemypos.transform.position.x == PlayerPos.x && ennemypos.transform.position.z == PlayerPos.z && EnnemyAnim.enabled == false)
        {
            EndNav();
        }

        if (AnimScript.GetComponent<Animation>().endanim == true)
        {
            EndAnimEnnemy();
        }

        if (EnnemyAnim.GetBool("turn") == true)
        {
            
            EnnemyAnim.enabled = false;
            EnnemyAnim.SetBool("turn", false);
            cherche = false;

        }
    }

    void EndNav()
    {
        endnavmesh = true;
        EnnemyAnim.enabled = true;
        EnnemyAnim.Play("turn", -1, 0f);
    }

    public void EndAnimEnnemy()
    {
       cherche = false;
        EnnemyAnim.enabled = false;
        PlayerPos = new Vector3(0,0,0);
        endnavmesh = false;
    }




    // -------------------->  Entrée champ de vision

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
    // -------------------->  End


}
