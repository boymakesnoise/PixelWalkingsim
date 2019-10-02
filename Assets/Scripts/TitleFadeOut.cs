using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleFadeOut : MonoBehaviour
{

    public Image black;
    public Animator anim;

    private bool canPressSubmit = true;

    private void Awake() {
        // Sätter fullskärm och behåller crisp bild även vid 512x288 rez.
        Screen.SetResolution(1920, 1080, true);
        Cursor.visible = false;
    }

    private void Start() {
        Invoke("PlayMusic", 3f);
    }

    private void PlayMusic() {
        FindObjectOfType<AudioManager>().Play("TitleMusic");
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && canPressSubmit) {
            canPressSubmit = false;
            StartCoroutine(Fading());

            Invoke("PlayCocking", 3.5f);
        }
    }

    private void PlayCocking() {
        FindObjectOfType<AudioManager>().Play("Cocking");
    }

    IEnumerator Fading() {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("Level");
    }
}
