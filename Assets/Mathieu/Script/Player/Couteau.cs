using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couteau : MonoBehaviour
{
    public bool sonJouer = false;
    //public AudioSource couteau;

    // Use this for initialization
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ennemi"))
        {
            other.GetComponent<reperage>().stun = true;
            //couteau.Play();
            FindObjectOfType<AuidoManager>().Play("Couteau");
            GameManager.instance.timer = 0;
            FindObjectOfType<AuidoManager>().Play("MortRobot");
        }
    }
    
}
