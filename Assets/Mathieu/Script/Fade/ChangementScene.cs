using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangementScene : MonoBehaviour
{
    [SerializeField] Fade fade;
    private float _fadeDuration = 2f;
    public string sceneToLoad;
    bool changement;
    float Timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (changement)
        {
            Timer += Time.deltaTime;
            if(Timer>=_fadeDuration)
            {
               SceneManager.LoadScene(sceneToLoad);


            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ChangementScene"))
        {
            Debug.Log("Changement");
            //SteamVR_Fade.Start(Color.clear, 0f);
            
            SteamVR_Fade.View(Color.black, _fadeDuration);
            Debug.Log("Fondu");
            changement = true;
            //fade.FadeOut();
        }
    }
}
