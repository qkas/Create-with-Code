﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
