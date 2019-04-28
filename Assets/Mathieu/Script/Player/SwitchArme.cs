using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


public class SwitchArme : MonoBehaviour
{
    /*
    public enum SwitchArme
    {
        Couteau,
        Pistolet,
        Teleporteur,
        Main
    }

    public SwitchArme type = SwitchArme.Main;
    */

    public GameObject couteau;
    public GameObject pistolet;
    public GameObject teleporteur;
    public VRTK.VRTK_ControllerEvents controllerEvent;
    



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Inputprocess();
    }

    public void Inputprocess()
    {

      
        if (Input.GetKeyDown(KeyCode.LeftArrow) || controllerEvent.gripClicked)
        {
            
            couteau.SetActive(true);
            pistolet.SetActive(false);
            teleporteur.SetActive(false);
            

        }

        if (Input.GetKeyDown(KeyCode.RightArrow) /*|| controllerEvent.gripPressed*/)
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
