using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject spawn;
	private PlayerController playerController;

	private Vector3 spawnPos = new Vector3(25, 0, 0);

	private float startDelay = 1;
	private float repeatRate = 3;
	// Start is called before the first frame update
	void Start()
	{
		playerController = GameObject.Find("Player").GetComponent<PlayerController>();
		InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
	}

	// Update is called once per frame
	void Update()
	{

	}

	void SpawnObstacle()
	{
		if (playerController.gameOver == false)
		{
			Instantiate(spawn, spawnPos, spawn.transform.transform.rotation);

		}
	}
}
