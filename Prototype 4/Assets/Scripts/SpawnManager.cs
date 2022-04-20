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

	public GameObject spawn;
	#endregion

	#region Unity Mehods

	// Start is called before the first frame update
	void Start()
	{
		Instantiate(spawn, GenerateSpawnPosition(), spawn.transform.rotation);
	}

	// Update is called once per frame
	void Update()
	{

	}

	

	#endregion

	#region Class

	private Vector3 GenerateSpawnPosition()
	{
		float spawnPosX = Random.Range(-spawnRange, spawnRange);
		float spawnPosY = Random.Range(-spawnRange, spawnRange);

		Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosY);

		return randomPos;
	}

	#endregion
}
