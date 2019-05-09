using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{

    public Transform door;

    public  DoorBas trigger;
    public bool opening = false;
    
    public bool closing = false;
    public float speed = 0;
    public float maxOpenValue;
    public float currentValue = 0f;
    public float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(opening == true && trigger.openingBas == true)
        {
            Debug.Log(trigger.openingBas);
            OpenDoor();
        }
        if (closing == true)
        {
            CloseDoor();
        }
    }

    
    private void OnTriggerEnter(Collider Clé)
    {
        if (Clé.gameObject.CompareTag("Clé"))
        {
            opening = true;
            closing = false;
            
        }
    }

    void OpenDoor()
    {
        float movement = speed * Time.deltaTime;
        currentValue += movement;
        if (currentValue <= maxOpenValue)
        {
            door.position = new Vector3(door.position.x + movement, door.position.y, door.position.z);
        }
        else
        {
            opening = false;
        }
    }

    void CloseDoor()
    {
        float movement = speed * Time.deltaTime;
        currentValue -= movement;
        if (currentValue >= 0)
        {
            door.position = new Vector3(door.position.x, door.position.y, door.position.z - movement);
        }
        else
        {
            closing = false;
        }
    }
}
