using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenTarget : MonoBehaviour
{
    public GameObject[] flowerPrefabs;
    public FlowerCount fC;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pollen"))
        {
            for(int i = 0; i < flowerPrefabs.Length; i++)
            {
                var seed = this.gameObject.transform;
                Instantiate(flowerPrefabs[Random.Range(0,flowerPrefabs.Length)], seed.position, seed.rotation);
                GameObject.Destroy(seed);
                fC.flowerCount++;
            }

        } else
        {
            return;
        }
    }
}
