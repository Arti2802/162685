using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie6 : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public float yVelocity = 0.0f;

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
        //transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
        transform.position = new Vector3(Mathf.Lerp(-1.0f, 1.0f, smoothTime), 0, 0);
    }
}
