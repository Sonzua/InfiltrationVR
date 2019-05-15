using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //Utilisation VRTK
    public VRTK.VRTK_ControllerEvents controllerEvent;
    
    public VRTK_InteractableObject couteaux;
    public VRTK_InteractableObject pistolets;
    public VRTK_InteractGrab rightHand;

    //Variable Carte mAg
    
    public GameObject controller;
    

    // Variable Arme
    public bool pistoletEnMain = false;
    public bool pistoletInventaire = false;
    public bool couteauEnMain = false;
    public bool couteauInventaire = false;
    public GameObject couteau;
    public GameObject pistolet;

    public GameObject pistoletUI;
    public GameObject couteauUI;

    // Start is called before the first frame update
    void Start()
    {
        couteauUI.SetActive(false);
        pistoletUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Vérification si grabbed
        if(couteaux.IsGrabbed(controller) == true)
        {

            couteauEnMain = true;
            couteauInventaire = false;
        }

        if (pistolets.IsGrabbed(controller) == true)
        {           
            pistoletEnMain = true;
            pistoletInventaire = false;
        }


        //Mise dans inventaire



        if (couteauEnMain == true || couteauInventaire == true)
        {
            gameObject.GetComponent<VRTK_InteractGrab>().AttemptGrab();
            if (Input.GetKeyDown(KeyCode.LeftArrow) || controllerEvent.gripClicked)
            {
                ToggleCouteau();

            }
        }
        



        if (pistoletEnMain == true || pistoletInventaire == true)
        {
            gameObject.GetComponent<VRTK_InteractGrab>().AttemptGrab();
            
            if (Input.GetKeyDown(KeyCode.RightArrow) || controllerEvent.touchpadPressed )
            {
                TogglePistolet();
            }
        }

    }
    
    public void TogglePistolet()
    {
            Debug.Log(pistolet);
            pistolet.SetActive(!pistolet.activeSelf);
            
            if (pistolet.activeSelf)
            {
                Debug.Log("Main");
                pistoletEnMain = true;
                pistoletInventaire = false;
                pistoletUI.SetActive(false);

            }
            if (!pistolet.activeSelf)
            {
                Debug.Log("Inventaire");
                pistoletInventaire = true;
                pistoletEnMain = false;
                pistoletUI.SetActive(true);
            }
        
    }

    public void ToggleCouteau()
    {
        Debug.Log(couteau);
        couteau.SetActive(!couteau.activeSelf);
        
        if (couteau.activeSelf)
        {
            couteauUI.SetActive(false);
            couteauEnMain = true;
            couteauInventaire = false;
        }
        if (!couteau.activeSelf)
        {
            couteauInventaire = true;
            couteauEnMain = false;
            couteauUI.SetActive(true);
        }

    }

}
