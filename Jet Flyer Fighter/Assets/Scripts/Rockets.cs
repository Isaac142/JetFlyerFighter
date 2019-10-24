using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockets : MonoBehaviour
{

    static public Rockets S;

    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond = 0.5f;
    public float enemySpawnPadding = 1.5f;

    public bool idk;
    public float enemySpawnRate;


    private void Awake()
    {
        S = this;
        enemySpawnRate = 1f / enemySpawnPerSecond;
        Invoke("SpawnEnemy", enemySpawnRate);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate(prefabEnemies[ndx]) as GameObject;
        Vector3 pos = Vector3.zero;
        pos.x = Random.Range(0, 20);
        pos.y = Random.Range(0, 10);
        go.transform.position = pos;
        Invoke("SpawnEnemy", enemySpawnRate);
    }
}
