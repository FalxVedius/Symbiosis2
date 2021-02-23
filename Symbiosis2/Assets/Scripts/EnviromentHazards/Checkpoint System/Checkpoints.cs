using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public bool isActive = false;

    private Collider checkpointCollider;

    private void Start()
    {
        checkpointCollider = this.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement charMovement = other.gameObject.GetComponentInParent<PlayerMovement>();

        if (charMovement != null)
        {
            isActive = true;
            checkpointCollider.enabled = false;
        }
    }
}
