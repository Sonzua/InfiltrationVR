using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //Utilisation VRTK
    public VRTK.VRTK_ControllerEvents controllerEvent;
    public GameObject parents;
    public VRTK_InteractableObject couteaux;
    public VRTK_InteractableObject pistolets;
    public VRTK_InteractGrab rightHand;
    
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
        //FindObjectOfType<AuidoManager>().Play("Pistolet"); Ligne test son
    }

    // Update is called once per frame
    void Update()
    {
        //Vérification si grabbed
        Debug.Log(couteaux.IsGrabbed(gameObject));
        if (couteaux.IsGrabbed(gameObject))
        {
            couteau.transform.parent = parents.transform;
            couteau.transform.localRotation = parents.transform.localRotation;
            couteauEnMain = true;
            couteauInventaire = false;
        }

        if (pistolets.IsGrabbed(gameObject))
        {
            Debug.Log("coucou");
            pistolet.transform.parent = parents.transform;
            pistolet.transform.localRotation = parents.transform.localRotation;
            pistoletEnMain = true;
            pistoletInventaire = false;
        }


        //Mise dans inventaire



        if ((couteauEnMain == true || couteauInventaire == true) && pistoletEnMain == false )
        {
            gameObject.GetComponent<VRTK_InteractGrab>().AttemptGrab();
            if (Input.GetKeyDown(KeyCode.LeftArrow) || controllerEvent.gripClicked)
            {
                /*couteau.transform.parent = parents.transform;
                couteau.transform.localRotation = parents.transform.localRotation;*/

                ToggleCouteau();

            }
        }




        if ((pistoletEnMain == true || pistoletInventaire == true) && couteauEnMain == false) 
        {
            gameObject.GetComponent<VRTK_InteractGrab>().AttemptGrab();
            
            if (Input.GetKeyDown(KeyCode.RightArrow) || controllerEvent.touchpadPressed )
            {

                pistolet.transform.parent = parents.transform;
                pistolet.transform.localRotation = parents.transform.localRotation;
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
