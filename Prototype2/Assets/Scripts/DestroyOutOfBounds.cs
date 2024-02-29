using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30f;
    private float bottomBound = -10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check for gameobjects exiting the top border
        if (transform.position.z > topBound)
        {
            // destroy out of bounds object
            Destroy(gameObject);
        }
        // check for gameobjects exiting the bottom border
        else if (transform.position.z < bottomBound)
        {
            // destroy out of bounds object and log "game over!"
            Debug.Log("game over!");
            Destroy(gameObject);
        }
    }
}
