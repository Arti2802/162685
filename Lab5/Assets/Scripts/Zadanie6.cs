using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie6 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Block"))
        {
            Debug.Log("Rozpocz�to kontakt z przeszkod�!");
        }
    }
}
