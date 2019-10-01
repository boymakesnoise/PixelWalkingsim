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

    void Update()
    {
        if (Input.GetKeyDown("space") && canPressSubmit) {
            canPressSubmit = false;
            StartCoroutine(Fading());
        }
    }

    IEnumerator Fading() {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("Level");
    }
}
