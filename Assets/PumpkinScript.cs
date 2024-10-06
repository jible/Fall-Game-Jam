using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinScript : MonoBehaviour
{

    public List<int> triangles;
    List<Vector3> verticies;
    Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;

        triangles = new List<int>(mesh.triangles);
        verticies = new List<Vector3>(mesh.vertices);
    }


    public void removeTri( int index)
    {
        verticies.RemoveAt(triangles[index] + 2);
        verticies.RemoveAt(triangles[index + 1]);
        verticies.RemoveAt(triangles[index]);
        triangles.RemoveAt(index);
        
        mesh.triangles =triangles.ToArray();
        mesh.vertices = verticies.ToArray();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
