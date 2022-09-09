using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{      
    public bool hit = false;
    public Rigidbody[] _rigidBodies;

    private void Start()
    {
        _rigidBodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigidbody in _rigidBodies)
        {
            rigidbody.isKinematic = true;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (hit)
        {
            _rigidBodies = GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody rigidbody in _rigidBodies)
            {
                rigidbody.isKinematic = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        hit = true;
        gameObject.tag = "Untagged";
    }
}
