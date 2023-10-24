using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie4 : MonoBehaviour
{
    float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0.0f, 0.5f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(hor, 0.0f, ver);
        transform.Translate(move * speed * Time.deltaTime);
    }
}
