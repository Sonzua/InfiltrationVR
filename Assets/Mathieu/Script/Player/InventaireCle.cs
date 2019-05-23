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
    public GameObject parents;

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
            if (Input.GetKeyDown(KeyCode.Space) || controllerEvent.gripClicked)
            {
                cle.transform.parent = parents.transform;
                cle.transform.localRotation = parents.transform.localRotation;
                ToggleCarte();
            }
        }




    }

    public void ToggleCarte()
    {
        Debug.Log(cle);
        cle.SetActive(!cle.activeSelf);

        if (cle.activeSelf)
        {
            Debug.Log("Main");
            cleEnMain = true;
            cleDansInventaire = false;
            carteUI.SetActive(false);

        }
        if (!cle.activeSelf)
        {
            Debug.Log("Inventaire");
            cleDansInventaire = true;
            cleEnMain = false;
            carteUI.SetActive(true);
        }

    }
}