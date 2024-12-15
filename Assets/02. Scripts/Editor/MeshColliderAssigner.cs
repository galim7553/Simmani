using UnityEngine;
using UnityEditor;
using System.Linq;

/// <summary>
/// Town Objects 가공 용도로 사용합니다.
/// </summary>
public class MeshColliderAssigner : Editor
{
    [MenuItem("Tools/Assign ConvexHull MeshCollider to Selected Objects")]
    static void AssignMeshCollidersToSelectedObjects()
    {
        // 선택된 모든 오브젝트 가져오기
        GameObject[] selectedObjects = Selection.gameObjects;

        if (selectedObjects.Length == 0)
        {
            Debug.LogError("오브젝트를 선택하세요.");
            return;
        }

        foreach (GameObject selectedObject in selectedObjects)
        {
            // 선택된 오브젝트의 MeshFilter 가져오기
            MeshFilter meshFilter = selectedObject.GetComponent<MeshFilter>();

            if (meshFilter == null)
            {
                Debug.LogWarning($"{selectedObject.name}에는 MeshFilter가 없습니다. 건너뜁니다.");
                continue;
            }

            // MeshCollider가 있는지 확인하고 없으면 추가
            MeshCollider meshCollider = selectedObject.GetComponent<MeshCollider>();
            if (meshCollider == null)
            {
                meshCollider = selectedObject.AddComponent<MeshCollider>();
            }

            // MeshFilter의 메쉬 이름을 기반으로 ConvexHulls 메쉬 이름 생성
            string meshName = meshFilter.sharedMesh != null ? meshFilter.sharedMesh.name : "UnnamedMesh";
            string convexMeshName = $"{meshName}_ConvexHulls";

            // 해당 모델 내부에서 ConvexHulls 이름의 서브 메쉬 찾기
            Mesh convexMesh = FindMeshInModel(meshFilter.sharedMesh, convexMeshName);
            if (convexMesh != null)
            {
                meshCollider.sharedMesh = convexMesh;
                Debug.Log($"{convexMeshName} 메쉬가 {selectedObject.name} 오브젝트에 연결되었습니다.");
            }
            else
            {
                Debug.LogWarning($"{convexMeshName} 메쉬를 찾을 수 없습니다. {selectedObject.name}에 원래 메쉬를 사용합니다.");
                meshCollider.sharedMesh = meshFilter.sharedMesh;
            }

            // Convex 옵션 설정
            meshCollider.convex = true;
        }

        Debug.Log("선택된 오브젝트들에 MeshColliders가 성공적으로 할당되었습니다.");
    }

    // 특정 모델 안에서 서브 메쉬를 찾는 함수
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
        // 선택된 모든 오브젝트 가져오기
        GameObject[] selectedObjects = Selection.gameObjects;

        if (selectedObjects.Length == 0)
        {
            Debug.LogError("오브젝트를 선택하세요.");
            return;
        }

        // 이름 필터에 들어가는 문자열들
        string[] targetKeywords = { "Ground", "Wall", "Floor", "Roof", "Window" };

        foreach (GameObject selectedObject in selectedObjects)
        {
            // 자식 오브젝트 포함해서 처리
            Transform[] allChildren = selectedObject.GetComponentsInChildren<Transform>();

            foreach (Transform child in allChildren)
            {
                // 자식 오브젝트 이름에 "Ground", "Wall", "Floor", "Roof", "Window"가 포함되어 있는지 확인
                if (targetKeywords.Any(keyword => child.name.Contains(keyword)))
                {
                    // MeshFilter 가져오기
                    MeshFilter meshFilter = child.GetComponent<MeshFilter>();

                    if (meshFilter == null)
                    {
                        Debug.LogWarning($"{child.name}에는 MeshFilter가 없습니다. 건너뜁니다.");
                        continue;
                    }

                    // MeshCollider가 있는지 확인하고 없으면 추가
                    MeshCollider meshCollider = child.GetComponent<MeshCollider>();
                    if (meshCollider == null)
                    {
                        meshCollider = child.gameObject.AddComponent<MeshCollider>();
                    }

                    // MeshFilter의 메쉬 이름을 기반으로 ConvexHulls 메쉬 이름 생성
                    string meshName = meshFilter.sharedMesh != null ? meshFilter.sharedMesh.name : "UnnamedMesh";
                    string convexMeshName = $"{meshName}_ConvexHulls";

                    // 해당 모델 내부에서 ConvexHulls 이름의 서브 메쉬 찾기
                    Mesh convexMesh = FindMeshInModel(meshFilter.sharedMesh, convexMeshName);
                    if (convexMesh != null)
                    {
                        meshCollider.sharedMesh = convexMesh;
                        Debug.Log($"{convexMeshName} 메쉬가 {child.name} 오브젝트에 연결되었습니다.");
                    }
                    else
                    {
                        Debug.LogWarning($"{convexMeshName} 메쉬를 찾을 수 없습니다. {child.name}에 원래 메쉬를 사용합니다.");
                        meshCollider.sharedMesh = meshFilter.sharedMesh;
                    }

                    // Convex 옵션 설정
                    meshCollider.convex = true;
                }
            }
        }

        Debug.Log("선택된 오브젝트들에 필터링된 MeshColliders가 성공적으로 할당되었습니다.");
    }

    // 특정 모델 안에서 서브 메쉬를 찾는 함수
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