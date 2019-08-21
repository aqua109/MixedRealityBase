﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchLunarModule : MonoBehaviour
{
    public float thrust;
    public Rigidbody rb;
    public bool ThrustOn;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    public void resetModule()
    {
        StopThurster();
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }

    public void StartThurster()
    {
        StartCoroutine(Thruster());
    }

    public void StopThurster()
    {
        ThrustOn = false;
    }

    public IEnumerator Thruster()
    {
        rb.isKinematic = false;

        ThrustOn = true;

        yield return null;

        while (ThrustOn)
        {
            yield return new WaitForSeconds(0.01f);
            rb.AddForce(transform.up * thrust);
        }

    }
}
