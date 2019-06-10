using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timer;
    public bool Dead = false;
    public static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        Dead = false;
    }

    void Update()
    {

        if (timer > 5 && Dead ==false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Dead = true;
            timer = 0;
        }
        else
        {
            Dead = false;
        }
    }
}


