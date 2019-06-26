using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couteau : MonoBehaviour
{
    public bool sonJouer = false;
    float cooldown;
    public GameObject lightning;
    //public AudioSource couteau;

    // Use this for initialization
    void Start()
    {
        cooldown = 10;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        if (cooldown >= 10)
        {
            lightning.SetActive(true);
        }
        else
        {
            lightning.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ennemi"))
        {
            if (cooldown >= 10)
            {
                other.GetComponent<reperage>().stun = true;
                //couteau.Play();
                FindObjectOfType<AuidoManager>().Play("Couteau");
                GameManager.instance.timer = 0;
                FindObjectOfType<AuidoManager>().Play("MortRobot");
                cooldown = 0;
            }
        }
    } 
}
