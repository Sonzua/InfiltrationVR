using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using VRTK;

public class UIManager : MonoBehaviour
{
    public bool menuActif = true;
    public GameObject menuPrincipal;
    public GameObject controllerLeft;
    public GameObject controllerRight;
    private VRTK_Pointer pointer;
    private VRTK_BezierPointerRenderer bezier;
    private VRTK_StraightPointerRenderer straight;
    // Start is called before the first frame update
    void Start()
    {
         pointer = controllerLeft.GetComponent<VRTK_Pointer>();
         bezier = controllerRight.GetComponent<VRTK_BezierPointerRenderer>();
         straight = controllerRight.GetComponent<VRTK_StraightPointerRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(menuActif == true)
        {
            pointer.enabled = false;
           bezier.enabled = false;
            straight.enabled = true;
        }
    }

    public void Jouer()
    {
        Debug.Log(menuActif);
        Debug.Log(FindObjectOfType<AuidoManager>());
        menuActif = false;
        menuPrincipal.SetActive(false);
        FindObjectOfType<AuidoManager>().Play("Bouton");
        //bezier.enabled = true;
        //straight.enabled = false;
    }

    public void Quitter()
    {
        FindObjectOfType<AuidoManager>().Play("Bouton");
        Debug.Log(FindObjectOfType<AuidoManager>());
        Application.Quit();    }
}
