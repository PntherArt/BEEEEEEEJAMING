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
        fC.GetComponent<FlowerCount>();
    }

    private void OnParticleCollision(GameObject other)
    {

            for (int i = 0; i < 1; i++)
            {
                var seed = this.gameObject.transform;
                Instantiate(flowerPrefabs[Random.Range(0, flowerPrefabs.Length)], seed.position, seed.rotation);
                fC.flowerCount++;
                fC.updateFlowerCount();
                Destroy(gameObject);
                
            }

    }

}
