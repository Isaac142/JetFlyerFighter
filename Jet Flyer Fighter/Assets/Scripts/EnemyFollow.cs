using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
	public Transform Player;

	//Speed of enemies
	public float speed = 2f;

	//How far away from the player they stop. stops the enemies from moving inside of the player. adjust for you models.
	private float minDistance = 0.5f;
	private float range;


	void Update ()
	{
		//checks how far the enemy is from the player and stops them if they are getting too close
		range = Vector3.Distance(transform.position, Player.position);
		if (range > minDistance)
		{
			//finds the location of the player. MAKE SURE YOU ADD PLAYER TAG TO THE PLAYER GAMEOBJECT AND ENEMY TAG TO THE ENEMY GAMEOBJECT
			Player = GameObject.FindGameObjectWithTag ("Player").transform;

			//gets the position of the enemy and slowly moves it towards the player.
			transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
		}
	}
}
