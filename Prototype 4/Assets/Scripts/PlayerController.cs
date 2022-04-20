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

    private Rigidbody playerRb;
    private GameObject focalPoint;

    public float speed = 3.0f;
    private float powerUpStrength = 10.0f;
    public bool hasPowerup = false;
    public GameObject powerupIndicatior;
    #endregion

    #region Unity Mehods

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);

        powerupIndicatior.transform.position = transform.position + new Vector3(0,-0.5f,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicatior.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PoweupCOuntdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRig = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRig.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            Debug.Log("Collided with: " + collision.gameObject.name + " with power up set to " + hasPowerup);
        }
    }


    #endregion

    #region Class
    IEnumerator PoweupCOuntdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicatior.gameObject.SetActive(false);
    }
    #endregion
}
