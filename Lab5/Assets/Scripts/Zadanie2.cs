using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie2 : MonoBehaviour
{
    public float doorSpeed = 2.0f;
    public float openDistance = 3.0f;

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isOpen = false;

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition + new Vector3(openDistance, 0, 0);
    }

    void Update()
    {
        if (isOpen)
        {
            transform.Translate(Vector3.right * doorSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, other.transform.position);
            if (distanceToPlayer < openDistance)
            {
                isOpen = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isOpen)
        {
            isOpen = false;
        }
    }
}
