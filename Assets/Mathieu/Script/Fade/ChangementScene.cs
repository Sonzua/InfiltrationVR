using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangementScene : MonoBehaviour
{
    [SerializeField] Fade fade;
    private float _fadeDuration = 1f;
    public string sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ChangementScene"))
        {
            Debug.Log("Changement");
            SteamVR_Fade.Start(Color.clear, 0f);
            //set and start fade to
            SteamVR_Fade.Start(Color.black, _fadeDuration);
            SceneManager.LoadScene(sceneToLoad);
            //fade.FadeOut();
        }
    }
}
