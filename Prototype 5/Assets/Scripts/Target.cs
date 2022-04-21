/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

	#region Variables

	public int pointValue;
	public ParticleSystem exploreP;

	private Rigidbody targetRb;

	private float minSpeed = 12;
	private float maxSpeed = 18;
	private float maxTorque = 100;
	private float xRange = 4;
	private float ySpawnPos = 2;

	private GameManager gameManager;
	#endregion

	#region Unity Mehods

	// Start is called before the first frame update
	void Start()
	{
		targetRb = GetComponent<Rigidbody>();
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

		targetRb.AddForce(RandomForce(), ForceMode.Impulse);
		targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

		transform.position = RandomSpawnPos();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnMouseDown()
	{
		if (gameManager.isGameActive)
		{
			Destroy(gameObject);
			Instantiate(exploreP, transform.position, exploreP.transform.rotation);
			gameManager.UpdateScore(pointValue);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Destroy(gameObject);
		if (!gameObject.CompareTag("Bad"))
		{
			gameManager.GameOver();
		}
	}

	#endregion

	#region Class

	Vector3 RandomForce()
	{
		return Vector3.up * Random.Range(minSpeed, maxSpeed);

	}

	Vector3 RandomSpawnPos()
	{
		return new Vector3(Random.Range(-xRange, xRange), -ySpawnPos);
	}

	float RandomTorque()
	{
		return Random.Range(-maxTorque, maxTorque);

	}

	#endregion
}
