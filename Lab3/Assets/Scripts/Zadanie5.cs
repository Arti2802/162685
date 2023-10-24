using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie5 : MonoBehaviour
{
    public GameObject myCube;

    // Start is called before the first frame update
    void Start()
    {
        float x;
        float z;
        List<Vector3> positions = new List<Vector3> { };
        Vector3 pos;
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        for (int i = 0; i < 10; i++)
        {
            do
            {
                x = Random.Range(-5.0f, 5.0f);
                z = Random.Range(-5.0f, 5.0f);
                pos = new Vector3(x, 0.5f, z);
            }
            while (IsPositionOccupied(positions, pos) || x < -4.5f || x > 4.5f || z < -4.5f || z > 4.5f);
            Instantiate(myCube, pos, Quaternion.identity);
            positions.Add(pos);
        }
    }
    bool IsPositionOccupied(List<Vector3> positions, Vector3 targetPosition)
    {
        foreach (Vector3 position in positions)
        {
            if (Vector3.Distance(position, targetPosition) < 1.0f)
            {
                return true;
            }
        }
        return false;
    }
}