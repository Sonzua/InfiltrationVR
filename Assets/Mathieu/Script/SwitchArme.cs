using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchArme : MonoBehaviour
{
    /*   
    public enum switchArme
    {
        Couteau,
        Pistolet,
        Teleporteur,
        Main
    }

    public switchArme type = switchArme.Main;
    */

    public GameObject couteau;
    public GameObject pistolet;
    public GameObject teleporteur;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Inputprocess();
    }

    private void Inputprocess()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            couteau.SetActive(true);
            pistolet.SetActive(false);
            teleporteur.SetActive(false);
            

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            couteau.SetActive(false);
            pistolet.SetActive(true);
            teleporteur.SetActive(false);


        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            couteau.SetActive(false);
            pistolet.SetActive(false);
            teleporteur.SetActive(true);


        }

  
    }

}
