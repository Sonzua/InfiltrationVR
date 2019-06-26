using UnityEngine.Audio;
using System;
using UnityEngine;

public class AuidoManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AuidoManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play (string name, float value=1)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){
            Debug.LogWarning("Sound: " + name + "not found !");
            return;
        }
        s.source.PlayOneShot(s.source.clip);
        s.source.pitch = value;
    }

}
