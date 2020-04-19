using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

	public GameObject[] objects;
	public float spawnTime = 6f;
	private Vector2 spawnPosition;

	

	void Start()

	{
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

	

	void Spawn()
	{
		spawnPosition.x = Random.Range(-8, -4);
		spawnPosition.y = Random.Range(3, 9);

		Instantiate(objects[UnityEngine.Random.Range(0, objects.Length - 1)], spawnPosition, Quaternion.identity);
	}  
	
    //
}
