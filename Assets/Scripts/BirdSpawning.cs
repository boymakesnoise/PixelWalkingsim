using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawning : MonoBehaviour
{

    public GameObject blod;
    public int nrOfBirds = 15;
    public float spread = 30;
    public float sizeMin = 0.05f;
    public float sizeMax = 0.3f;

    private GameObject birden;

    void Start()
    {
        // Set rotation
        Quaternion vinkel = Quaternion.Euler(90, 0, 0);

        // Randomize a few puddles of different sizes
        for (int i = 0; i < nrOfBirds; i++) {
            Vector3 birdPositionSpread = transform.position + new Vector3(Random.Range(-spread, spread), 0, Random.Range(-spread, spread));
            birden = Instantiate(blod, birdPositionSpread, vinkel);
            float size = Random.Range(sizeMin, sizeMax);
            birden.transform.localScale = new Vector3(size, size, 1);
        }
    }

}
