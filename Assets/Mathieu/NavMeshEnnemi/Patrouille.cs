using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrouille : MonoBehaviour
{

    public bool patrolWaiting; //pause de l'ennemi a une position précise pendant un temps précis
    public float totalWaitTime = 3f; //temps d'arret
    public float switchProbability = 0.2f; // Chance de changer de direction
    public List<WayPoint> patrolPoints; //list des chexkpoint que l'ennemi va voir

    NavMeshAgent navMeshAgent;
    int currentPatrolIndex;
    bool travelling;
    bool waiting;
    bool patrolForward;
    float waitTimer;



    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("Nav Mesh component is not attached" + gameObject.name);
        }
        else
        {
            if (patrolPoints != null && patrolPoints.Count >= 2)
            {
                currentPatrolIndex = 0;
                SetDestination();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Verifie si on est proche d'un waypoint
        if(travelling && navMeshAgent.remainingDistance <= 1.0f)
        {
            travelling = false;

            //Si le npc doit attendre
            if (patrolWaiting)
            {
                waiting = true;
                waitTimer = 0f;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();
            }
        }
        //L'ennemi attend
        if (waiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= totalWaitTime)
            {
                waiting = false;
                ChangePatrolPoint();
                SetDestination();
            }
        }
    }

    private void SetDestination()
    {
        if(patrolPoints != null)
        {
            Vector3 targetVector = patrolPoints[currentPatrolIndex].transform.position; // Va vers le Waypoint de la liste le plus proche de lui
            navMeshAgent.SetDestination(targetVector);
            travelling = true;
        }
    }

    private void ChangePatrolPoint()
    {
        if(UnityEngine.Random.Range(0f,1f) <= switchProbability)
        {
            patrolForward = !patrolForward;
        }

        if (patrolForward)
        {
            currentPatrolIndex++;
            if(currentPatrolIndex >= patrolPoints.Count)
            {
                currentPatrolIndex = 0;
            }
            
        }
        else
        {
            currentPatrolIndex--;
            if(currentPatrolIndex < 0)
            {
                currentPatrolIndex = patrolPoints.Count - 1;
            }

        }
    }

}
