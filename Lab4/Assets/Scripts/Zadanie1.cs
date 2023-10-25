using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Zadanie1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    public int objectsCount = 10;
    // obiekt do generowania
    public GameObject block;

    void Start()
    {
        int x = (int) transform.position[0];
        int z = (int) transform.position[2];
        List<int> pozycje_x = new List<int>(Enumerable.Range(x-5, x+5).OrderBy(x => Guid.NewGuid()).Take(objectsCount));
        List<int> pozycje_z = new List<int>(Enumerable.Range(z-5, z+5).OrderBy(x => Guid.NewGuid()).Take(objectsCount));
        
        for(int i=0; i<objectsCount; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 5, pozycje_z[i]));
        }
        foreach(Vector3 elem in positions){
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {
        
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach(Vector3 pos in positions)
        {
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
