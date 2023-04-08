using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject[] obstaclePrefab;
    public  GameObject moneyPrefab;
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnMoney();
        SpawnObstacle();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }
    
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        int randomIndex = Random.Range(0,obstaclePrefab.Length);
        int obstacleSpawnIndex = Random.Range(2,5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstaclePrefab[randomIndex], spawnPoint.position, Quaternion.identity, transform);
    }

    void SpawnMoney()
    {
        int moneyToSpawn = 2;
        for (int i = 0; i < moneyToSpawn; i++)
        {
            GameObject money = Instantiate(moneyPrefab, transform);
            money.transform.position = GetRandomPointCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointCollider(Collider c)
    {
        Vector3 point = new Vector3(Random.Range(c.bounds.min.x, c.bounds.max.x), Random.Range(c.bounds.min.y, c.bounds.max.y), Random.Range(c.bounds.min.z, c.bounds.max.z));
        if (point != c.ClosestPoint(point))
        {
            point = GetRandomPointCollider(c);
        }
        point.y = 1;
        return point;
    }
}
