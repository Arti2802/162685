using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie3 : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 6.6f;
    private bool isRunningUp = true;
    private bool isRunningDown = false;
    public float downPosition;
    public float upPosition;
    public List<Vector3> points = new List<Vector3>();
    private int current = 0;
    private bool moveForward = true;


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[current], elevatorSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, points[current]) < 0.01f)
        {
            if (moveForward)
            {
                current++;
                if (current == points.Count)
                {
                    current = points.Count - 2;
                    moveForward = false;
                }
            }
            else
            {
                current--;
                if (current < 0)
                {
                    current = 1;
                    moveForward = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszed³ na windê.");

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
            Debug.Log("Player zszed³ z windy.");
        }
    }
}
