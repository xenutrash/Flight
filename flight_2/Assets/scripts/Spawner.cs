using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float SpawnRate = 2;
    public GameObject[] Enemies;
   
   
    private int ArrayLength;
    private int SpawnPointLength;

    public GameObject[] SpawnPoints;


    // Start is called before the first frame update
    void Start()
    {
        ArrayLength = Enemies.Length;
        SpawnPointLength = SpawnPoints.Length;
        InvokeRepeating(nameof(Spawn), SpawnRate, SpawnRate);
    }


    void Spawn()
    {
        Vector2 Target = SpawnPoints[Random.Range(0, SpawnPointLength)].transform.position;
        Instantiate( Enemies[Random.Range(0, ArrayLength )], Target, Quaternion.identity);
        Debug.Log("Enemy spawned!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
