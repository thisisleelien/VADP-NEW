using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguishFire : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("fire"))
        {
            other.GetComponent<ParticleSystem>().Stop();
            other.transform.GetChild(2).gameObject.SetActive(true);
        }
    }
}
