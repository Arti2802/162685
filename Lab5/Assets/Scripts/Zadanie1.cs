using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie1 : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 6.6f;
    private bool isRunningUp = true;
    private bool isRunningDown = false;
    public float downPosition;
    public float upPosition;
    private Vector3 start = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 end = new Vector3(0.0f, 10.0f, 0.0f);
    private Vector3 current;

    void Start()
    {
        current = start;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, current, elevatorSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, current) < 0.01f)
        {
            current = (current == start) ? end : start;
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
           
            if (transform.position.y >= upPosition)
            {
                isRunningDown = true;
                isRunningUp = false;
                elevatorSpeed = -elevatorSpeed;
            }
            else if (transform.position.y <= downPosition)
            {
                isRunningUp = true;
                isRunningDown = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
        }
    }
}
