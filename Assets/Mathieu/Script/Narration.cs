using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Narration : MonoBehaviour
{

    public GameObject tutorielCouteau;
    public GameObject tutorielKill;
    public GameObject tutorielAccroup;
    public GameObject tutorielInventaire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            tutorielCouteau.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Intro"))
        {
            FindObjectOfType<AuidoManager>().Play("Couteau");
            tutorielCouteau.SetActive(true);

        }
        if (other.gameObject.CompareTag("Miliru"))
        {
            FindObjectOfType<AuidoManager>().Play("MortRobot");
            tutorielKill.SetActive(true);
        }

        if (other.gameObject.CompareTag("Accroupi"))
        {
            
            tutorielAccroup.SetActive(true);
        }

        if (other.gameObject.CompareTag("RangerArme"))
        {
            FindObjectOfType<AuidoManager>().Play("MortRobot");
            tutorielInventaire.SetActive(true);
        }
    }

}
