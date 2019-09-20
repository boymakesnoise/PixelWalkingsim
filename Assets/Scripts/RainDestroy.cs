using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDestroy : MonoBehaviour
{
    public float lifetime;
    public float rainspeed = 20;
    private Rigidbody rb;

    void Start() {
        Destroy(gameObject, lifetime);
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        rb.AddForce(Physics.gravity * rb.mass * rainspeed);
    }

    void OnTriggerEnter() {
        Destroy(gameObject);
    }
}
