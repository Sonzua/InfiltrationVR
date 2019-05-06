using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Inventory : MonoBehaviour
{

    
    public bool cleDansInventaire = false;
    public bool cleEnMain = false;
    public GameObject cle;
    public GameObject controller;
    public VRTK_InteractableObject cleMag;
    public VRTK_InteractGrab rightHand;
    public SetParent carte;
    public bool frame = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (cleMag.IsGrabbed(controller) == true)
        {
            cleEnMain = true;
            cleDansInventaire = false;
        }
        /*
        else
        {
            cleEnMain = false;
            cleDansInventaire = true;
        }
        */
        if (cleEnMain == true)
        {
            gameObject.GetComponent<VRTK_InteractGrab>().AttemptGrab();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                cle.SetActive(false);
                cleDansInventaire = true;
                cleEnMain = false;
                
            }
        }
        if (Input.GetKeyDown(KeyCode.Backspace) && cleDansInventaire == true)
        {
            cle.SetActive(true);
            
            cleDansInventaire = false;
            cleEnMain = true;
            

        }
        


    }

    /*
    public void ForceGrab()
    {
      gameObject.GetComponent<VRTK_InteractGrab>().ForceControllerAttachPoint(cleMag.GetComponent<Rigidbody>());
    }
    */
}
