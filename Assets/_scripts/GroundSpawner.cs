using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject ground;
    Vector3 nextSpawnPoint;

    public void SpawnTile()
    {
        GameObject sp = Instantiate(ground, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = sp.transform.GetChild(1).transform.position;
        
    }
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
                SpawnTile();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
