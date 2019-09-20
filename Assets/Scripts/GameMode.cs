using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour {

    private void Awake() {
        // Toggle fullscreen
        //Screen.fullScreen = !Screen.fullScreen;

        Screen.SetResolution(512, 288, false);
    }

    void Update() {
        if (Input.GetKey("escape")) {
            Application.Quit();
        }
    }
}
