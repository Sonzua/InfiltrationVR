using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reperage : MonoBehaviour
{
    public bool repéré = false;
    public bool zone = false;
    public Vector3 Head;
    public Vector3 RobotHead;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Head = GameObject.FindGameObjectWithTag("Player").transform.position;
        RobotHead = GameObject.Find("EyeModel").transform.position;
        if (zone == true)
        {
            Raycast();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            zone = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            zone = false;
        }
    }
    void Raycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(RobotHead,Head+ transform.up*0.2f,out hit))
        {
            Debug.DrawRay(RobotHead, Head+ transform.up*0.2f, Color.yellow);

            if (hit.collider.gameObject == player)
            {
                print("There is nothing in front of the object!");
                Debug.DrawRay(RobotHead, Head, Color.yellow);
            } 
        }
    }
}
