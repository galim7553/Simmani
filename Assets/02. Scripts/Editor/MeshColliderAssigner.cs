using UnityEngine;
using UnityEditor;
using System.Linq;

/// <summary>
/// Town Objects ���� �뵵�� ����մϴ�.
/// </summary>
public class MeshColliderAssigner : Editor
{
    [MenuItem("Tools/Assign ConvexHull MeshCollider to Selected Objects")]
    static void AssignMeshCollidersToSelectedObjects()
    {
        // ���õ� ��� ������Ʈ ��������
        GameObject[] selectedObjects = Selection.gameObjects;

        if (selectedObjects.Length == 0)
        {
            Debug.LogError("������Ʈ�� �����ϼ���.");
            return;
        }

        foreach (GameObject selectedObject in selectedObjects)
        {
            // ���õ� ������Ʈ�� MeshFilter ��������
            MeshFilter meshFilter = selectedObject.GetComponent<MeshFilter>();

            if (meshFilter == null)
            {
                Debug.LogWarning($"{selectedObject.name}���� MeshFilter�� �����ϴ�. �ǳʶݴϴ�.");
                continue;
            }

            // MeshCollider�� �ִ��� Ȯ���ϰ� ������ �߰�
            MeshCollider meshCollider = selectedObject.GetComponent<MeshCollider>();
            if (meshCollider == null)
            {
                meshCollider = selectedObject.AddComponent<MeshCollider>();
            }

            // MeshFilter�� �޽� �̸��� ������� ConvexHulls �޽� �̸� ����
            string meshName = meshFilter.sharedMesh != null ? meshFilter.sharedMesh.name : "UnnamedMesh";
            string convexMeshName = $"{meshName}_ConvexHulls";

            // �ش� �� ���ο��� ConvexHulls �̸��� ���� �޽� ã��
            Mesh convexMesh = FindMeshInModel(meshFilter.sharedMesh, convexMeshName);
            if (convexMesh != null)
            {
                meshCollider.sharedMesh = convexMesh;
                Debug.Log($"{convexMeshName} �޽��� {selectedObject.name} ������Ʈ�� ����Ǿ����ϴ�.");
            }
            else
            {
                Debug.LogWarning($"{convexMeshName} �޽��� ã�� �� �����ϴ�. {selectedObject.name}�� ���� �޽��� ����մϴ�.");
                meshCollider.sharedMesh = meshFilter.sharedMesh;
            }

            // Convex �ɼ� ����
            meshCollider.convex = true;
        }

        Debug.Log("���õ� ������Ʈ�鿡 MeshColliders�� ���������� �Ҵ�Ǿ����ϴ�.");
    }

    // Ư�� �� �ȿ��� ���� �޽��� ã�� �Լ�
    static Mesh FindMeshInModel(Mesh mainMesh, string meshName)
    {
        if (mainMesh == null)
        {
            return null;
        }

        Mesh[] meshes = AssetDatabase.LoadAllAssetsAtPath(AssetDatabase.GetAssetPath(mainMesh)).OfType<Mesh>().ToArray();
        foreach (Mesh mesh in meshes)
        {
            if (mesh.name == meshName)
            {
                return mesh;
            }
        }

        return null;
    }
}

public class FilteredMeshColliderAssigner : Editor
{
    [MenuItem("Tools/Assign ConvexHull MeshCollider to Filtered Child Objects")]
    static void AssignMeshCollidersToFilteredChildObjects()
    {
        // ���õ� ��� ������Ʈ ��������
        GameObject[] selectedObjects = Selection.gameObjects;

        if (selectedObjects.Length == 0)
        {
            Debug.LogError("������Ʈ�� �����ϼ���.");
            return;
        }

        // �̸� ���Ϳ� ���� ���ڿ���
        string[] targetKeywords = { "Ground", "Wall", "Floor", "Roof", "Window" };

        foreach (GameObject selectedObject in selectedObjects)
        {
            // �ڽ� ������Ʈ �����ؼ� ó��
            Transform[] allChildren = selectedObject.GetComponentsInChildren<Transform>();

            foreach (Transform child in allChildren)
            {
                // �ڽ� ������Ʈ �̸��� "Ground", "Wall", "Floor", "Roof", "Window"�� ���ԵǾ� �ִ��� Ȯ��
                if (targetKeywords.Any(keyword => child.name.Contains(keyword)))
                {
                    // MeshFilter ��������
                    MeshFilter meshFilter = child.GetComponent<MeshFilter>();

                    if (meshFilter == null)
                    {
                        Debug.LogWarning($"{child.name}���� MeshFilter�� �����ϴ�. �ǳʶݴϴ�.");
                        continue;
                    }

                    // MeshCollider�� �ִ��� Ȯ���ϰ� ������ �߰�
                    MeshCollider meshCollider = child.GetComponent<MeshCollider>();
                    if (meshCollider == null)
                    {
                        meshCollider = child.gameObject.AddComponent<MeshCollider>();
                    }

                    // MeshFilter�� �޽� �̸��� ������� ConvexHulls �޽� �̸� ����
                    string meshName = meshFilter.sharedMesh != null ? meshFilter.sharedMesh.name : "UnnamedMesh";
                    string convexMeshName = $"{meshName}_ConvexHulls";

                    // �ش� �� ���ο��� ConvexHulls �̸��� ���� �޽� ã��
                    Mesh convexMesh = FindMeshInModel(meshFilter.sharedMesh, convexMeshName);
                    if (convexMesh != null)
                    {
                        meshCollider.sharedMesh = convexMesh;
                        Debug.Log($"{convexMeshName} �޽��� {child.name} ������Ʈ�� ����Ǿ����ϴ�.");
                    }
                    else
                    {
                        Debug.LogWarning($"{convexMeshName} �޽��� ã�� �� �����ϴ�. {child.name}�� ���� �޽��� ����մϴ�.");
                        meshCollider.sharedMesh = meshFilter.sharedMesh;
                    }

                    // Convex �ɼ� ����
                    meshCollider.convex = true;
                }
            }
        }

        Debug.Log("���õ� ������Ʈ�鿡 ���͸��� MeshColliders�� ���������� �Ҵ�Ǿ����ϴ�.");
    }

    // Ư�� �� �ȿ��� ���� �޽��� ã�� �Լ�
    static Mesh FindMeshInModel(Mesh mainMesh, string meshName)
    {
        if (mainMesh == null)
        {
            return null;
        }

        Mesh[] meshes = AssetDatabase.LoadAllAssetsAtPath(AssetDatabase.GetAssetPath(mainMesh)).OfType<Mesh>().ToArray();
        foreach (Mesh mesh in meshes)
        {
            if (mesh.name == meshName)
            {
                return mesh;
            }
        }

        return null;
    }
}