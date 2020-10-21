using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCubes : MonoBehaviour
{
    public GameObject myPrefab;
    List<Vector3> VerticeList = new List<Vector3>();
    List<Vector3> VerticeListToShow = new List<Vector3>();
    List<float> listX = new List<float>();
    List<float> listZ = new List<float>();


    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {  
        VerticeList = new List<Vector3>(GetComponent<MeshFilter>().sharedMesh.vertices); 
        foreach (Vector3 point in VerticeList)
        {
            VerticeListToShow.Add(transform.TransformPoint(point));
        }
                Debug.Log(name + " has " + VerticeListToShow.Count + " vertices on it.");

        for (float i = Mathf.Min(VerticeListToShow[0].x, VerticeListToShow[10].x); i < Mathf.Max(VerticeListToShow[0].x, VerticeListToShow[10].x); i++)    
        {
            listX.Add(i);
        }
        for (float i = Mathf.Min(VerticeListToShow[0].z, VerticeListToShow[110].z); i < Mathf.Max(VerticeListToShow[0].z, VerticeListToShow[110].z); i++)    
        {
            listZ.Add(i);
        }

        for (int i = 0; i < 10; i++)
        {
            int indexX = Random.Range(0, listX.Count - 1);
            float rX = listX[indexX];    
            listX.RemoveAt(indexX);
            int indexZ = Random.Range(0, listZ.Count - 1);
            float rZ = listZ[indexZ];    
            listZ.RemoveAt(indexZ);
            

            Vector3 position = new Vector3(rX, 0.1f, rZ);
            Debug.Log(position);
            Instantiate(myPrefab, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
