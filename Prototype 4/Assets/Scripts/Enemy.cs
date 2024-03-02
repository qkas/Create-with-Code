using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody rb;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        // destroy enemy if they fall off
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

        // get vector towards player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        // move towards the player
        rb.AddForce(lookDirection * speed);
    }
}
