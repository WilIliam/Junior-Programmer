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

	private float spawnRange = 9.0f;
	public int enemtCount;
	public int waveNumber = 1;

	public GameObject spawn;
	public GameObject powerup;
	#endregion

	#region Unity Mehods

	// Start is called before the first frame update
	void Start()
	{
		SpawnEnemyWave(waveNumber);
		Instantiate(powerup, GenerateSpawnPosition(), powerup.transform.rotation);
	}

	// Update is called once per frame
	void Update()
	{
		enemtCount = FindObjectsOfType<EnemyController>().Length;

		if(enemtCount == 0)
		{
			waveNumber++;
			SpawnEnemyWave(waveNumber);
			Instantiate(powerup, GenerateSpawnPosition(), powerup.transform.rotation);
		}
	}



	#endregion

	#region Class

	void SpawnEnemyWave(int enemiesToSpawn)
	{
		for (int i = 0; i < enemiesToSpawn; i++)
		{
			Instantiate(spawn, GenerateSpawnPosition(), spawn.transform.rotation);

		}
	}

	private Vector3 GenerateSpawnPosition()
	{
		float spawnPosX = Random.Range(-spawnRange, spawnRange);
		float spawnPosY = Random.Range(-spawnRange, spawnRange);

		Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosY);

		return randomPos;
	}

	#endregion
}
