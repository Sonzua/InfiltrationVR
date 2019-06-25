using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveScene : MonoBehaviour
{
    [SerializeField] Fade fade;
    private float _fadeDuration = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //set and start fade to
        SteamVR_Fade.View(Color.black, _fadeDuration);

        SteamVR_Fade.View(Color.clear, _fadeDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Fade de manière générale
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ChangementScene"))
        {
            Debug.Log("Changement");
            fade.FadeOut();
        }
    }
}
