using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManagerG : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManagerG instance;

    // Start is called before the first frame update
    void Awake()
    {
        InstanceAudio();

        DontDestroyOnLoad(gameObject);
        
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

    }

    void InstanceAudio()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void Play2 (string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.Name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
           
        s.source.Play();
    }



     
}
