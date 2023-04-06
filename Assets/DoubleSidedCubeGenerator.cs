using UnityEditor;
using UnityEngine;


[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class DoubleSidedCubeGenerator : MonoBehaviour
{
    public float size = 10f;

    void Start()
    {
        GenerateDoubleSidedCube();
        SaveMeshAsAsset(GetComponent<MeshFilter>().sharedMesh, "DoubleSidedCube");
    }

    private void GenerateDoubleSidedCube()
    {
        Mesh mesh = new Mesh();
        mesh.name = "Double Sided Cube";

        float halfSize = size * 0.5f;
        Vector3[] vertices = new Vector3[24]
        {
            // Front face
            new Vector3(-halfSize, -halfSize, halfSize),
            new Vector3(halfSize, -halfSize, halfSize),
            new Vector3(halfSize, halfSize, halfSize),
            new Vector3(-halfSize, halfSize, halfSize),

            // Back face
            new Vector3(-halfSize, -halfSize, -halfSize),
            new Vector3(halfSize, -halfSize, -halfSize),
            new Vector3(halfSize, halfSize, -halfSize),
            new Vector3(-halfSize, halfSize, -halfSize),

            // Top face
            new Vector3(-halfSize, halfSize, halfSize),
            new Vector3(halfSize, halfSize, halfSize),
            new Vector3(halfSize, halfSize, -halfSize),
            new Vector3(-halfSize, halfSize, -halfSize),

            // Bottom face
            new Vector3(-halfSize, -halfSize, halfSize),
            new Vector3(halfSize, -halfSize, halfSize),
            new Vector3(halfSize, -halfSize, -halfSize),
            new Vector3(-halfSize, -halfSize, -halfSize),

            // Left face
            new Vector3(-halfSize, -halfSize, halfSize),
            new Vector3(-halfSize, -halfSize, -halfSize),
            new Vector3(-halfSize, halfSize, -halfSize),
            new Vector3(-halfSize, halfSize, halfSize),

            // Right face
            new Vector3(halfSize, -halfSize, halfSize),
            new Vector3(halfSize, -halfSize, -halfSize),
            new Vector3(halfSize, halfSize, -halfSize),
            new Vector3(halfSize, halfSize, halfSize)
        };

        int[] triangles = new int[72]
        {
            // Front face
            0, 1, 2,
            0, 2, 3,
            2, 1, 0,
            3, 2, 0,

            // Back face
            4, 5, 6,
            4, 6, 7,
            6, 5, 4,
            7, 6, 4,

            // Top face
            8, 9, 10,
            8, 10, 11,
            10, 9, 8,
            11, 10, 8,

            // Bottom face
            12, 13, 14,
            12, 14, 15,
            14, 13, 12,
            15, 14, 12,

            // Left face
            16, 17, 18,
            16, 18, 19,
            18, 17, 16,
            19, 18, 16,

            // Right face
            20, 21, 22,
            20, 22, 23,
            22, 21, 20,
            23, 22, 20

        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = mesh;
    }

    private void SaveMeshAsAsset(Mesh mesh, string assetName)
    {
        string assetPath = "Assets/" + assetName + ".asset";
        AssetDatabase.CreateAsset(mesh, assetPath);
        AssetDatabase.SaveAssets();
    }
}
