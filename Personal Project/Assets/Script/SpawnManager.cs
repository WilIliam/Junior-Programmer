/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

	#region Variables
	public GameObject[] enemies;
	public GameObject powerup;

	private float zEnemySpawn = 20.0f;
	private float xSpawnRange = 10.0f;
	private float zPowerRange = 5.0f;
	private float ySpawn = 0.75f;

	private float powerupSpawnTime = 5.0f;
	private float enemySpawnTime = 1.0f;
	private float startDelay = 1.0f;
	#endregion

	#region Unity Mehods

	// Start is called before the first frame update
	void Start()
	{
		InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);
		InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
	}

	// Update is called once per frame
	void Update()
	{

	}


	#endregion

	#region Class

	void SpawnEnemy()
	{
		float randomX = Random.RandomRange(-xSpawnRange, xSpawnRange);
		int randomIndex = Random.Range(0, enemies.Length);

		Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);

		Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
	}

	void SpawnPowerup()
	{
		float randomX = Random.Range(-xSpawnRange, xSpawnRange);
		float randomZ = Random.Range(-zPowerRange, zPowerRange);

		Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);

		Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
	}
	#endregion
}
