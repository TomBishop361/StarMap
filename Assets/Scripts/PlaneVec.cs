using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlaneVec : MonoBehaviour {       
    public int xSize = 3;
    public int zSize = 2;
    Vector3 LocalVec;
    int Distance;     
    
    //Mesh Data that will be used to generate the mesh
    Vector3[] vertices;
    Vector3[] normals;
    Vector2[] uvs;
    int[] triangles;
    Mesh mesh;
    int RandomListNum;

    private void Awake() {
        mesh = new Mesh();
        mesh.name = "MyQuad";
        GetComponent<MeshFilter>().sharedMesh = mesh;
        RandomListNum = Random.Range(0, Stars.Density);
    }
    public void start() { //To make this update live change from Start To Update
        getDistance();
        zSize = Distance;
        Generate();
        updateMesh();
        
        transform.LookAt(GetComponentInParent<Overlap>().SuitableStars[Overlap.reps].transform);       
    }

    void getDistance() {
        //Target Object Loation - Current Star location (in that order)
        if (GetComponentInParent<Overlap>().SuitableStars.Count != 0) {
            LocalVec = new Vector3((GetComponentInParent<Overlap>().SuitableStars[Overlap.reps].transform.position.x - transform.position.x),(GetComponentInParent<Overlap>().SuitableStars[Overlap.reps].transform.position.y - transform.position.y),(GetComponentInParent<Overlap>().SuitableStars[Overlap.reps].transform.position.z - transform.position.z));
            Distance = (int)MathF.Sqrt((LocalVec.x * LocalVec.x) + (LocalVec.y * LocalVec.y) + (LocalVec.z * LocalVec.z));
        } else {
            Debug.Log("NO Connections");           
        }
    }    

    void updateMesh() {
        //Generating the mesh using the Variables Defined
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.uv = uvs;
        mesh.triangles = triangles;
    }

    void Generate() {
        //applying Lenths to the Data Arrays
        //Array is length * width (including the ends)
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        normals = new Vector3[vertices.Length];
        uvs = new Vector2[vertices.Length];
        triangles = new int[xSize * zSize * 6];
        

        //Defining the 6 indicies needed to make a quad and increment 'vert' by 1 and Tris by 6 to create a plane.
        int vert = 0, tris = 0;
        for (int z = 0; z < zSize; z++) {
            for (int x = 0; x < xSize; x++) {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;
                vert++;
                tris += 6;
            }           
            vert++;
        }
        //Creating a plane - vertices positions   
        //This will position all of the vertices.?
        for (int i = 0, z = 0; z <= zSize; z++) {
            for (int x = 0; x <= xSize; x++) {
                vertices[i] = new Vector3(x, 0, z);
                i++;
                }
            }
        }
        
    }    

    
    

