using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBirdSpawner : MonoBehaviour
{
    public GameObject birdSpawner;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "BirdHitbox") {
            if (birdSpawner != null) {
                birdSpawner.SetActive(true);
            }
            FindObjectOfType<AudioManager>().Play("CrowsFlying");
        }
    }
}
