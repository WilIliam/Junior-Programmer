using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

	public GameObject player;
	[SerializeField]
	private Vector3 offset = new Vector3(0, 5, -10);
	// Start is called before the first frame update
	void Awake()
	{

	}

	// Update is called once per frame
	void LateUpdate()
	{
		// Offset the camera behide the player 
		transform.position = player.transform.position + offset;
	}
}
