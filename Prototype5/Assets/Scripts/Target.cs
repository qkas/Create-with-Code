using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Target : MonoBehaviour
{
    private GameManager gameManager;

    private Rigidbody rb;

    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 10f;
    private float xRange = 4f;
    private float ySpawnPos = -6f;

    public ParticleSystem explosionParticle;

    public int pointValue;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        rb = gameObject.GetComponent<Rigidbody>();

        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    void Update()
    {
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
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

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
