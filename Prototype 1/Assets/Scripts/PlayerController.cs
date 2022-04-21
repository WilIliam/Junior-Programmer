using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
	private float horizontalInput;
	[SerializeField]
	private float speed;
	[SerializeField]
	private float rpm;
	private const float turnSpeed = 45.0f;
	private float forwardInput;

	[SerializeField]
	private float horsePower = 0;
	[SerializeField]
	private GameObject centerOfMass;
	[SerializeField]
	private TextMeshProUGUI speedometerText;
	[SerializeField]
	private TextMeshProUGUI rpmText;
	[SerializeField]
	private List<WheelCollider> allWheels;
	[SerializeField]
	private int wheelsOnGround;

	private Rigidbody playerRb;

	private void Start()
	{
		playerRb = GetComponent<Rigidbody>();
		playerRb.centerOfMass = centerOfMass.transform.position;
	}


	// Update is called once per frame
	void FixedUpdate()
	{
		horizontalInput = Input.GetAxis("Horizontal");
		forwardInput = Input.GetAxis("Vertical");
		//transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
		//transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

		if (IsOnGround())
		{
			playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);

			transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

			speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f);
			speedometerText.SetText("Speed: " + speed + "km/h");

			rpm = Mathf.Round((speed % 30) * 40);
			rpmText.SetText("RPM: " + rpm);
		}
	}

	bool IsOnGround()
	{
		wheelsOnGround = 0;
		foreach (WheelCollider wheel in allWheels)
		{
			if (wheel.isGrounded)
			{
				wheelsOnGround++;
			}
		}

		if (wheelsOnGround == 4)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
