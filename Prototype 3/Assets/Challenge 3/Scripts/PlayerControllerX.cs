using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce = 2000;
    private float gravityModifier = 1.807f;
    private float topBoundary = 15.0f;
    private float bounceForce = 10.0f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }

        if(transform.position.y >= topBoundary)
		{
            transform.position = new Vector3(transform.position.x, topBoundary, transform.position.z);
            playerRb.velocity = Vector3.zero;
		}
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

        else if(other.gameObject.CompareTag("Ground") && !gameOver)
		{
            // Play sound 
            playerAudio.PlayOneShot(moneySound, 1.0f);
            // Bounce by bounceForce
            playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            BounceBalloon();
        }

    }

    private void BounceBalloon()
    {
        if (!gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce);
            playerRb.velocity = new Vector3(0, 10, 0);
        }
    }

}
