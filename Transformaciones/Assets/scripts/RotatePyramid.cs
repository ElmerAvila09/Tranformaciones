using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePyramid : MonoBehaviour
{

    public static Vector4 Vector3To4(Vector3 inVec)
    {
        Vector4 outVec = new Vector4(inVec.x, inVec.y, inVec.z, 1);
        return outVec;
    }
    public static Vector3 Vector4To3(Vector4 inVec)
    {
        Vector3 outVec = new Vector3(inVec.x, inVec.y, inVec.z);
        return outVec;
    }

    Vector3[] vertex;
    public int[] topology;
    private float angle = -15f;
    private float d2r = Mathf.PI / 180f;
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        vertex = new Vector3[4];
        vertex[0] = new Vector3(-1.812f, -4.13f, 5.247f);
        vertex[1] = new Vector3(-3.462f, -6.824f, 6.199f);
        vertex[2] = new Vector3(-0.162f, -6.824f, 6.199f);
        vertex[3] = new Vector3(-1.812f, -6.824f, 3.523f);
    
        topology = new int[12];
        topology[0] = 1;
        topology[1] = 3;
        topology[2] = 2;
    
        topology[3] = 1;
        topology[4] = 2;
        topology[5] = 0;
    
        topology[6] = 1;
        topology[7] = 0;
        topology[8] = 3;
    
        topology[9] = 2;
        topology[10] = 3;
        topology[11] = 0;
        
        mesh.vertices = vertex;
        mesh.triangles = topology;
        mesh.RecalculateNormals();
        
        
    }

    int count = 0;

    // Update is called once per frame
    void Update()
    {

        // Llevamos al origen, rotamos y devolvemos a la posicion inicial
        Matrix4x4 transform1 = Transformations.TranslateM(-1.81f, -6.1475f, 5.2925f) * Transformations.RotateM(-15*d2r, Transformations.AXIS.AX_Y) * Transformations.TranslateM(1.81f, 6.1475f, -5.2925f);

        vertex[0] = transform1 * Vector3To4(vertex[0]);
        vertex[1] = transform1 * Vector3To4(vertex[1]);
        vertex[2] = transform1 * Vector3To4(vertex[2]);
        vertex[3] = transform1 * Vector3To4(vertex[3]);


        GetComponent<MeshFilter>().mesh.vertices = vertex;

        Debug.Log(GetComponent<MeshFilter>().mesh.vertices);

    }

}