using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{

    public float speeden = 1;
    public float randomRange;

    private void Start() {
        speeden += Random.Range(-randomRange, randomRange);
        Destroy(gameObject, 60f);
    }
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speeden, Space.Self);
    }
}
