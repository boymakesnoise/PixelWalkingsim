using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    Renderer rend;
    public GameObject roads;
    public GameObject trees;
    public GameObject rocks;
    public GameObject ground;
    public float transitionTime = 2f; // Amount of time it takes to fade between colors

    Color32 sunnyTree = new Color32(0xFD, 0x93, 0x01, 0xFF);
    Color32 sunnyRoad = new Color32(0xFE, 0xB7, 0x34, 0xFF);
    Color32 sunnyRock = new Color32(0xFE, 0xDB, 0x66, 0xFF);
    Color32 sunnyGround = new Color32(0xFF, 0xFF, 0x99, 0xFF);

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "SunHitbox") {
            StartCoroutine(ColorChange());
        }
    }

    IEnumerator ColorChange() {
        float transitionRate = 0;
        while (transitionRate < 1) {
            foreach (Renderer rend in trees.GetComponentsInChildren<Renderer>()) {
                rend.material.SetColor("_Color", Color.Lerp(rend.material.color, sunnyTree, Time.deltaTime * transitionRate));
            }
            foreach (Renderer rend in roads.GetComponentsInChildren<Renderer>()) {
                rend.material.SetColor("_Color", Color.Lerp(rend.material.color, sunnyRoad, Time.deltaTime * transitionRate));
            }
            foreach (Renderer rend in rocks.GetComponentsInChildren<Renderer>()) {
                rend.material.SetColor("_Color", Color.Lerp(rend.material.color, sunnyRock, Time.deltaTime * transitionRate));
            }
            foreach (Renderer rend in ground.GetComponentsInChildren<Renderer>()) {
                rend.material.SetColor("_Color", Color.Lerp(rend.material.color, sunnyGround, Time.deltaTime * transitionRate));
            }
            transitionRate += Time.deltaTime / transitionTime; // Increment transitionRate over the length of transitionTime
            yield return null; // wait for a frame then loop again
        }
        yield return null; // wait for a frame then loop again
    }
}
