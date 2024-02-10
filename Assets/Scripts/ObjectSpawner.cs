using UnityEngine;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject tyre;
    public GameObject fuelcan;
    public GameObject airFilter;  

    
    public int tyreSpawnCount;
    public int fuelcanSpawnCount;
    public int airFilterSpawnCount;



    public Transform[] tyrespawnPoints; 
    public Transform[] fuelCanspawnPoints; 
    public Transform[] airFilterspawnPoints; 

    void Start()
    {
        SpawnObjects(tyre,tyrespawnPoints,tyreSpawnCount);
        SpawnObjects(fuelcan,fuelCanspawnPoints,fuelcanSpawnCount);
        SpawnObjects(airFilter,airFilterspawnPoints,airFilterSpawnCount);
    }

    void SpawnObjects(GameObject obj, Transform[] spawnpoints,int count)
    {
       
            
            for (int i = 0; i < count; i++)
            {     
               Transform spawnPoint = GetRandomSpawnPoint(spawnpoints);
                Instantiate(obj, spawnPoint.position, Quaternion.identity);
            }
        
    }

    Transform GetRandomSpawnPoint(Transform[] spawnPoints)
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        return spawnPoints[randomIndex];
    }
}
