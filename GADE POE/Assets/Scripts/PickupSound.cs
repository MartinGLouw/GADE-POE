using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSound : MonoBehaviour
{
    public AudioSource Pickup;

    private void Start()
    {
        Pickup.GetComponent<AudioSource>();
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Flying"))
        {
            Pickup.Play();
        }

        if (other.gameObject.CompareTag("DPPoints"))
        {
            Pickup.Play();
        }

        if (other.gameObject.CompareTag("Inv"))
        {
            Pickup.Play();
        }

        return null;
    }
}
