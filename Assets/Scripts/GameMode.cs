using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour {

    private void Awake() {
        // Toggle fullscreen
        //Screen.fullScreen = !Screen.fullScreen;

        Screen.SetResolution(512, 288, false);
    }

    

    private void Start() {
        //Invoke("PlayMusic", 3f);
        Invoke("PlayShotAndAmbience", 0.1f);
    }

    private void PlayShotAndAmbience() {
        FindObjectOfType<AudioManager>().Play("Skott");
        FindObjectOfType<AudioManager>().Play("AmbienceDark");
    }

    private void PlayMusic() {
        FindObjectOfType<AudioManager>().Play("Music1");
    }

    void Update() {
        if (Input.GetKey("escape")) {
            Application.Quit();
        }
    }
}
