﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bullet")
        {
            Destroy(gameObject);
            Object.Destroy(other.gameObject);
        }
    }
}
