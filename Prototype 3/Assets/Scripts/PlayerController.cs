using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody playerRb;
	private Animator animator;
	private AudioSource playerAudio;

	public ParticleSystem exploreP;
	public ParticleSystem dirtP;
	public AudioClip jumpSound;
	public AudioClip crashSound;

	public float jumpForce = 2000;
	public float gravityModifier = 9.807f;

	public bool isOnGround = true;
	public bool gameOver;
	// Start is called before the first frame update
	void Start()
	{
		playerRb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		playerAudio = GetComponent<AudioSource>();
		Physics.gravity *= gravityModifier;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
		{
			playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			isOnGround = false;
			animator.SetTrigger("Jump_trig");
			dirtP.Stop();
			playerAudio.PlayOneShot(jumpSound,1);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			isOnGround = true;
			dirtP.Play();
		}else if (collision.gameObject.CompareTag("Obstacle"))
		{
			Debug.Log("Game over");
			gameOver = true;
			animator.SetBool("Death_b",true);
			animator.SetInteger("DeathType_int", 1);
			exploreP.Play();
			dirtP.Stop();
			playerAudio.PlayOneShot(crashSound,1);
		}
	}
}
