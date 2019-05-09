using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.UI;

public class InventaireCle : MonoBehaviour
{
    //Utilisation VRTK
    public VRTK_ControllerEvents controllerEvent;
    public VRTK_InteractableObject cleMag;

    public VRTK_InteractGrab rightHand;

    //Variable Carte mAg
    public bool cleDansInventaire = false;
    public bool cleEnMain = false;
    public GameObject cle;
    public GameObject controller;
    public SetParent carte;
    public bool frame = false;
    public GameObject carteUI;


    // Start is called before the first frame update
    void Start()
    {
        carteUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Vérification si grabbed
        
        if (cleMag.IsGrabbed(controller) == true)
        {
            cleEnMain = true;
            cleDansInventaire = false;
            carteUI.SetActive(false);
        }

        //Mise dans inventaire

        if (cleEnMain == true)
        {
            gameObject.GetComponent<VRTK_InteractGrab>().AttemptGrab();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                cle.SetActive(false);
                cleDansInventaire = true;
                cleEnMain = false;
                carteUI.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace) && cleDansInventaire == true)
        {
            cle.SetActive(true);

            cleDansInventaire = false;
            cleEnMain = true;
        }

       
    }


}
