using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie5 : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();

            if (playerRigidbody != null)
            {
                float currentGravity = Physics.gravity.y;
                float jumpForce = currentGravity * 3.0f;
                playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            }
        }
    }
}
