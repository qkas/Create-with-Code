using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // check for collisions
    void OnTriggerEnter(Collider other)
    {
        // destroy both objects on object collision, 
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
