using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie3 : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3[] points = new Vector3[4]{
        new Vector3(10.0f, 0.0f, 0.0f),
        new Vector3(10.0f, 0.0f, 10.0f),
        new Vector3(0.0f, 0.0f, 10.0f),
        new Vector3(0.0f, 0.0f, 0.0f) };
    public int actual = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = points[actual];
        Debug.Log(target);
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        Quaternion targetRotation = Quaternion.LookRotation(target - transform.position, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 90.0f * Time.deltaTime);
        if (transform.position == target)
        {
            actual = (actual + 1) % 4;;
        }
    }
}
