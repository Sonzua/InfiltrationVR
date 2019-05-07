using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBas : MonoBehaviour
{
    public bool openingBas = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider Clé)
    {
        if (Clé.gameObject.CompareTag("Clé"))
        {
            openingBas = true;
        }
    }


}
