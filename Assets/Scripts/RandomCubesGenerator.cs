using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    List<Vector3> VerticeList = new List<Vector3>();
    List<Vector3> VerticeListToShow = new List<Vector3>();
    public Material[] randomMaterials;
    public float ObjectAmount = 0;
    int objectCounter = 0;
    // obiekt do generowania
    public GameObject block;

    void Start()
    {
        VerticeList = new List<Vector3>(GetComponent<MeshFilter>().sharedMesh.vertices);
        foreach (Vector3 point in VerticeList)
        {
            VerticeListToShow.Add(transform.TransformPoint(point));
        }
        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<int> pozycje_x = new List<int>(Enumerable.Range(Mathf.RoundToInt(Mathf.Min(VerticeListToShow[0].x, VerticeListToShow[10].x)), Mathf.RoundToInt(Mathf.Max(VerticeListToShow[0].x, VerticeListToShow[10].x))).OrderBy(x => Guid.NewGuid()).Take(10)); ;
        List<int> pozycje_z = new List<int>(Enumerable.Range(Mathf.RoundToInt(Mathf.Min(VerticeListToShow[0].z, VerticeListToShow[110].z)), Mathf.RoundToInt(Mathf.Max(VerticeListToShow[0].z, VerticeListToShow[110].z))).OrderBy(x => Guid.NewGuid()).Take(10));

        for (int i = 0; i < ObjectAmount; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 5, pozycje_z[i]));
        }
        foreach (Vector3 elem in positions)
        {
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
        foreach (Vector3 pos in positions)
        {
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}