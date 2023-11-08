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
    Collider m_Collider;
    public Material[] materials;

    void Start()
    {
        int min_x = (int) m_Collider.bounds.min[0];
        int max_x = (int) m_Collider.bounds.max[0];
        int min_z = (int)m_Collider.bounds.min[2];
        int max_z = (int)m_Collider.bounds.max[2];
        List<int> pozycje_x = new List<int>(Enumerable.Range(min_x, max_x).OrderBy(x => Guid.NewGuid()).Take(objectsCount));
        List<int> pozycje_z = new List<int>(Enumerable.Range(min_z, max_z).OrderBy(x => Guid.NewGuid()).Take(objectsCount));
        
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
            Material material = materials[UnityEngine.Random.Range(0, 5)];
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            Renderer renderer = this.block.GetComponent<Renderer>();
            renderer.material = material;
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
