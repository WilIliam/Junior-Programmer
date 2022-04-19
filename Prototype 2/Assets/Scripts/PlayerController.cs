using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hInput;
    public float speed = 10;
    public float xRange = 25;

    public GameObject[] bulletPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        hInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * hInput * Time.deltaTime * speed);

		if (Input.GetKeyDown(KeyCode.Space))
		{
            int index = Random.RandomRange(0, bulletPrefabs.Length);
            Instantiate(bulletPrefabs[index],transform.position, bulletPrefabs[index].transform.rotation);
		}
    }
}
