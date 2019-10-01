﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour {

    private void Awake() {
        // Toggle fullscreen
        //Screen.fullScreen = !Screen.fullScreen;

        Screen.SetResolution(512, 288, false);
    }

    

    private void Start() {
        Invoke("PlayMusic", 3f);
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
