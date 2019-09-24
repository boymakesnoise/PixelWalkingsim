using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : MonoBehaviour
{
    public GameObject blod;
    public int nrOfDrops = 10;
    public float spread = 1;
    public float sizeMin = 0.05f;
    public float sizeMax = 0.3f;
    public int dripNrOfDrops = 10;
    public float dripSpread = 0.5f;
    public float dripSizeMin = 0.01f;
    public float dripSizeMax = 0.03f;

    private GameObject puddle;


    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Skott");

        // Spawn first blood -----------------------------------------------------------
        // Set rotation and align with floor height
        Quaternion vinkel = Quaternion.Euler(90, 0, 0);
        Vector3 blodPosition = transform.position - new Vector3(0, 0.3f, 0);

        // Randomize a few puddles of different sizes
        for (int i = 0; i < nrOfDrops; i++) {
            Vector3 blodPositionSpread = blodPosition + new Vector3(Random.Range(-spread, spread), 0, Random.Range(-spread, spread));
            puddle = Instantiate(blod, blodPositionSpread, vinkel);
            float size = Random.Range(sizeMin, sizeMax);
            puddle.transform.localScale = new Vector3(size, size, 1);
        }

        // Start bleeding continously
        Invoke("Bleeding", 1);
        
    }

    private void Bleeding() {
        // Set rotation
        Quaternion vinkel = Quaternion.Euler(90, 0, 0);
        for (int i = 0; i < dripNrOfDrops; i++) {
            Vector3 blodPositionSpread = transform.position + new Vector3(Random.Range(-dripSpread, dripSpread), 0, Random.Range(-dripSpread, dripSpread));
            puddle = Instantiate(blod, blodPositionSpread, vinkel);
            float dripSize = Random.Range(dripSizeMin, dripSizeMax);
            puddle.transform.localScale = new Vector3(dripSize, dripSize, 1);
        }
        Invoke("Bleeding", Random.Range(1, 3));
    }
}
