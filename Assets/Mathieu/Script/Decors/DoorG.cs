using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorG : MonoBehaviour
{

    public Transform doorG;

    public DoorBas triggerG;
    public bool openingG = false;

    public bool closingG = false;
    public float speedG = 0;
    public float maxOpenValueG;
    public float currentValueG = 0f;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (openingG == true && triggerG.openingBas == true)
        {
            Debug.Log(triggerG.openingBas);
            OpenDoor();
        }
        if (closingG == true)
        {
            CloseDoor();
        }
    }


    private void OnTriggerEnter(Collider Clé)
    {
        if (Clé.gameObject.CompareTag("Clé"))
        {
            openingG = true;
            closingG = false;

        }
    }

    void OpenDoor()
    {
        float movementG = speedG * Time.deltaTime;
        currentValueG += movementG;
        if (currentValueG <= maxOpenValueG)
        {
            doorG.position = new Vector3(doorG.position.x, doorG.position.y, doorG.position.z - movementG);
        }
        else
        {
            openingG = false;
        }
    }

    void CloseDoor()
    {
        float movementG = speedG * Time.deltaTime;
        currentValueG -= movementG;
        if (currentValueG >= 0)
        {
            doorG.position = new Vector3(doorG.position.x, doorG.position.y, doorG.position.z + movementG);
        }
        else
        {
            closingG = false;
        }
    }
}
