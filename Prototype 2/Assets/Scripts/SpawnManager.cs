using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	private float minX = -20;
	private float maxX = 20;
	public GameObject[] spawn;
	private float startDelay = 1;
	private float spawnInterval = 1.5f;
	// Start is called before the first frame update
	void Start()
	{
		InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	void SpawnRandomAnimal()
	{
		// Random array
		int index = Random.RandomRange(0, spawn.Length);

		//Random Location spawn
		Vector3 pos = new Vector3(Random.Range(minX, maxX), 0, maxX);

		Instantiate(spawn[index], pos,
			spawn[index].transform.rotation);
	}
}
