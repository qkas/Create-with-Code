using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float spawnCooldown = 1f;
    private float spawnTimer = 1f; // 1 because first dog send doesn't have cooldown

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && spawnTimer >= spawnCooldown)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            spawnTimer = 0;
        }
    }
}
