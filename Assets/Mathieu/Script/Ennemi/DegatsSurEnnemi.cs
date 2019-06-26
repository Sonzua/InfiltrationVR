using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class DegatsSurEnnemi : MonoBehaviour
{

    //The box's current health point total

    public int currentHealth = 1;
    public Animator Anim;
    public void Damage(int damageAmount)

    {

        //subtract damage amount when Damage function is called

        currentHealth -= damageAmount;

        //Check if health has fallen below zero

        if (currentHealth <= 0)

        {

            //if health has fallen below zero, deactivate it 
            FindObjectOfType<AuidoManager>().Play("Pistolet");
            GameManager.instance.timer = 0;
            Destroy(gameObject.GetComponent<reperage>());
            Destroy(gameObject.GetComponent<NavMeshAgent>());
            FindObjectOfType<AuidoManager>().Play("MortRobot");
            Anim.SetBool("dead", true);
        }

    }

}