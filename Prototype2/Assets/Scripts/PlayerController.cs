using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    private float horizontalInput;
    private float speed = 25.0f;
    private float xRange = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check if the player is at the left range limit 
        if (transform.position.x < -xRange)
        {
            // lock the players x position
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        // check if the player is at the right range limit
        if (transform.position.x > xRange)
        {
            // lock the players x position
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // get horizontal player input
        horizontalInput = Input.GetAxis("Horizontal");

        // move player horizontally based on horizontal player input
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        // detect space press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // launch projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
