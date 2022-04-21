/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	#region Variables

	private float speed = 50.0f;
	private float zBound = 18.0f;
	private float yBound = 10;

	private Rigidbody playerRb;

	#endregion

	#region Unity Mehods

	// Start is called before the first frame update
	void Start()
	{
		playerRb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		MovePlayer();
		ConstrainPlayerPosition();
	}


	#endregion

	#region Class
	void MovePlayer()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");
		float jumpInput = Input.GetAxis("Jump");

		playerRb.AddForce(Vector3.right * speed * horizontalInput);
		playerRb.AddForce(Vector3.forward * speed * verticalInput);
		playerRb.AddForce(Vector3.up * speed * jumpInput);

	}

	void ConstrainPlayerPosition()
	{
		if (transform.position.z < -zBound)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
		}

		if (transform.position.z > zBound)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
		}

		if (transform.position.y > yBound)
		{
			transform.position = new Vector3(transform.position.x, yBound, transform.position.z);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			Debug.Log("collided with enemy");
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Powerup"))
		{
			Destroy(other.gameObject);
		}
	}
	#endregion
}
