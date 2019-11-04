using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

	float spawnTime;

	//The amount of time between each spawn
	public float minSpawnTime;
	public float maxSpawnTime;

	//How long before first enemy is spawned
	public float spawnDelay = 3f;

	//Array of enemies (put enemy prefab in the inspector)
	public GameObject[] enemies;

	//spawn area size (change in inspector)
	public Vector3 centre;
	public Vector3 size;


	void Start ()
	{
		spawnTime = Random.Range (minSpawnTime, maxSpawnTime);
		//Start calling the Spawn function repeatedly after a delay.
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}
	void Spawn ()
	{
		//saying that the float spawnTime = a random number between the specified min and max time.
		spawnTime = Random.Range (minSpawnTime, maxSpawnTime);

		//if you have more than 1 enemy, it picks a random one to spawn
		int enemyIndex = Random.Range(0, enemies.Length);

		//sets the spawn location to somewhere inside of the area for each new enemy spawned
		Vector3 pos = transform.position + new Vector3 (Random.Range (-size.x / 2, size.x / 2), Random.Range (-size.y / 2, size.y / 2), Random.Range (-size.z / 2, size.z / 2));

		//spawns the enemy and then automatically destroys it after a certain ammount of time (120 seconds in this case).

		Destroy (Instantiate (enemies [enemyIndex], pos, transform.rotation), 200f); 

		//use this instead and commment out the first one if you dont want to destroy the enemy after you spawn it.

		//(Instantiate (enemies [enemyIndex], pos, transform.rotation)); 
	}

	//allows you to visualise the spawn area
	void OnDrawGizmosSelected(){
		Gizmos.color = new Color (0, 0, 1, 0.5f);
		Gizmos.DrawCube (transform.position, size);

	}
}
