using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start() {
        Invoke("PlayMusic", 1.5f);
    }

    private void PlayMusic() {
        Play("Music1");
    }

    public void Play (string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Ljudet " + name + " hittades inte");
            return;
        }
        s.source.Play();
    }
}
