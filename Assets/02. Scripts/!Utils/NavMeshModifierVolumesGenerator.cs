using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshModifierVolumesGenerator : MonoBehaviour
{
    [ContextMenu("Generate NavMesh Modifier Volumes")]
    public void GenerateVolumes()
    {
        // 현재 게임오브젝트의 모든 자식 Terrain에 대해 반복
        Terrain[] terrainComponents = GetComponentsInChildren<Terrain>();
        if (terrainComponents.Length == 0)
        {
            Debug.LogError("Terrain을 찾을 수 없습니다. 이 스크립트는 Terrain을 포함하는 게임오브젝트에 있어야 합니다.");
            return;
        }

        foreach (Terrain terrainComponent in terrainComponents)
        {
            // Terrain에 페인트된 나무 찾기
            TreeInstance[] trees = terrainComponent.terrainData.treeInstances;
            TreePrototype[] treePrototypes = terrainComponent.terrainData.treePrototypes;
            int layer = terrainComponent.gameObject.layer;

            foreach (TreeInstance tree in trees)
            {
                Vector3 worldTreePosition = Vector3.Scale(tree.position, terrainComponent.terrainData.size) + terrainComponent.transform.position;
                float treeScale = tree.widthScale; // TreeInstance의 스케일 고려
                Quaternion treeRotation = Quaternion.Euler(0, tree.rotation * Mathf.Rad2Deg, 0); // TreeInstance의 회전 고려

                // 트리 프로토타입 확인
                GameObject treePrefab = treePrototypes[tree.prototypeIndex].prefab;
                CapsuleCollider[] colliders = treePrefab.GetComponentsInChildren<CapsuleCollider>();

                foreach (CapsuleCollider collider in colliders)
                {
                    // NavMeshModifierVolume 추가
                    GameObject volumeObject = new GameObject("NavMeshModifierVolume");
                    volumeObject.layer = layer;
                    Vector3 localColliderPosition = treeRotation * (collider.transform.localPosition * treeScale);
                    Vector3 adjustedPosition = worldTreePosition + localColliderPosition;
                    volumeObject.transform.position = adjustedPosition;
                    volumeObject.transform.rotation = treeRotation * collider.transform.rotation;

                    NavMeshModifierVolume modifierVolume = volumeObject.AddComponent<NavMeshModifierVolume>();
                    modifierVolume.area = 1; // Not Walkable 설정
                    modifierVolume.center = Vector3.zero;
                    modifierVolume.size = new Vector3(0.2f, 1.0f, 0.2f);
                    volumeObject.transform.parent = terrainComponent.transform;
                }
            }
        }
    }

    [ContextMenu("Delete All NavMesh Modifier Volumes")]
    public void DeleteVolumes()
    {
        // 현재 게임오브젝트의 모든 자식 Terrain에 대해 반복
        Terrain[] terrainComponents = GetComponentsInChildren<Terrain>();
        if (terrainComponents.Length == 0)
        {
            Debug.LogError("Terrain을 찾을 수 없습니다. 이 스크립트는 Terrain을 포함하는 게임오브젝트에 있어야 합니다.");
            return;
        }

        foreach (Terrain terrainComponent in terrainComponents)
        {
            // Terrain의 자식 오브젝트들 중 "NavMeshModifierVolume" 이름인 것을 모두 찾음
            Transform[] childTransforms = terrainComponent.GetComponentsInChildren<Transform>();
            foreach (Transform child in childTransforms)
            {
                if (child.gameObject.name == "NavMeshModifierVolume")
                {
                    DestroyImmediate(child.gameObject);
                }
            }
        }
    }
}
