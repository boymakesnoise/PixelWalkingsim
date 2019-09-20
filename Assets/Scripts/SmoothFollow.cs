using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour {

    public Transform target;
    public float smoothSpeed = 0.001f;

    void LateUpdate() {

        //target.rotation = Quaternion.Lerp(target.rotation, transform.rotation, rotationSpeed);

        Quaternion desiredRotation = target.transform.rotation;
        Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
        transform.rotation = smoothedRotation;
        
    }
}