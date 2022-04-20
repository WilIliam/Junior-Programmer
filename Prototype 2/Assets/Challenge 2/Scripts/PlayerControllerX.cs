using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float fRate = 0.5f;
    private float nextF = 0.0f;

    private void Start()
	{
        float spawnInterval = Random.Range(0, 5.0f);
        float startDelay = 0.5f;

        InvokeRepeating("SpawnDog", startDelay, spawnInterval);
    }

	// Update is called once per frame
	void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextF)
        {
            nextF = Time.time + fRate;
            Instantiate(dogPrefab,
                transform.position, dogPrefab.transform.rotation);
        }
    }

    void SpawnDog()
	{
        Instantiate(dogPrefab,
                transform.position, dogPrefab.transform.rotation);
    }
}
