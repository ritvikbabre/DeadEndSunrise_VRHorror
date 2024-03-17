using UnityEngine;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject tyre;
    public GameObject fuelcan;
    public GameObject airFilter;  
    public GameObject key;

    
    public int tyreSpawnCount;
    public int fuelcanSpawnCount;
    public int airFilterSpawnCount;
    public int keySpawnCount;



    public List<Transform> tyrespawnPoints; 
    public List<Transform> fuelCanspawnPoints; 
    public List<Transform> airFilterspawnPoints; 
    public List<Transform> keySpawnPoints;

    void Start()
    {
        SpawnObjects(tyre,tyrespawnPoints,tyreSpawnCount);
        SpawnObjects(fuelcan,fuelCanspawnPoints,fuelcanSpawnCount);
        SpawnObjects(airFilter,airFilterspawnPoints,airFilterSpawnCount);
        SpawnObjects(key,keySpawnPoints,keySpawnCount);
    }

    void SpawnObjects(GameObject obj, List<Transform> spawnpoints,int count)
    {
       
            
            for (int i = 0; i < count; i++)
            {     
               Transform spawnPoint = GetRandomSpawnPoint(spawnpoints);
                Instantiate(obj, spawnPoint.position, Quaternion.identity);
                
            }
        
    }

    Transform GetRandomSpawnPoint(List<Transform> spawnPoints)
    {
        int randomIndex = Random.Range(0, spawnPoints.Count);
        Transform _spawnpoint = spawnPoints[randomIndex];
        spawnPoints.RemoveAt(randomIndex);
        return _spawnpoint;
    }
}
