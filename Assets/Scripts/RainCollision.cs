using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCollision : MonoBehaviour {

    public float targetDelay = 0.0001f;
    public GameObject raindrop;

    float delay = 1.0f;
    float xx;
    float zz;
    public float height = 20;
    public float size = 5;
    bool hasExited = false;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "RainHitbox") {
            //InvokeRepeating("Spawn", delay, delay);
            Invoke("Spawn", delay);
        }
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.name == "RainHitbox") {
            if (delay > targetDelay) {
                delay /= 1.01f;
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "RainHitbox") {
            hasExited = true;
        }
    }

    private void Update() {
        if (hasExited) {
            if (delay < 1) {
                delay *= 1.004f;
            } else {
                hasExited = false;
                CancelInvoke();
            }
        }
    }

    void Spawn() {
        xx = Random.Range(-size, size) + transform.position.x;
        zz = Random.Range(-size, size) + transform.position.z;
        Instantiate(raindrop, new Vector3(xx, height, zz), Quaternion.identity);
        Invoke("Spawn", delay);
    }
    
}
