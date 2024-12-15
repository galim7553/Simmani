using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshModifierVolumesGenerator : MonoBehaviour
{
    [ContextMenu("Generate NavMesh Modifier Volumes")]
    public void GenerateVolumes()
    {
        // ���� ���ӿ�����Ʈ�� ��� �ڽ� Terrain�� ���� �ݺ�
        Terrain[] terrainComponents = GetComponentsInChildren<Terrain>();
        if (terrainComponents.Length == 0)
        {
            Debug.LogError("Terrain�� ã�� �� �����ϴ�. �� ��ũ��Ʈ�� Terrain�� �����ϴ� ���ӿ�����Ʈ�� �־�� �մϴ�.");
            return;
        }

        foreach (Terrain terrainComponent in terrainComponents)
        {
            // Terrain�� ����Ʈ�� ���� ã��
            TreeInstance[] trees = terrainComponent.terrainData.treeInstances;
            TreePrototype[] treePrototypes = terrainComponent.terrainData.treePrototypes;
            int layer = terrainComponent.gameObject.layer;

            foreach (TreeInstance tree in trees)
            {
                Vector3 worldTreePosition = Vector3.Scale(tree.position, terrainComponent.terrainData.size) + terrainComponent.transform.position;
                float treeScale = tree.widthScale; // TreeInstance�� ������ ���
                Quaternion treeRotation = Quaternion.Euler(0, tree.rotation * Mathf.Rad2Deg, 0); // TreeInstance�� ȸ�� ���

                // Ʈ�� ������Ÿ�� Ȯ��
                GameObject treePrefab = treePrototypes[tree.prototypeIndex].prefab;
                CapsuleCollider[] colliders = treePrefab.GetComponentsInChildren<CapsuleCollider>();

                foreach (CapsuleCollider collider in colliders)
                {
                    // NavMeshModifierVolume �߰�
                    GameObject volumeObject = new GameObject("NavMeshModifierVolume");
                    volumeObject.layer = layer;
                    Vector3 localColliderPosition = treeRotation * (collider.transform.localPosition * treeScale);
                    Vector3 adjustedPosition = worldTreePosition + localColliderPosition;
                    volumeObject.transform.position = adjustedPosition;
                    volumeObject.transform.rotation = treeRotation * collider.transform.rotation;

                    NavMeshModifierVolume modifierVolume = volumeObject.AddComponent<NavMeshModifierVolume>();
                    modifierVolume.area = 1; // Not Walkable ����
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
        // ���� ���ӿ�����Ʈ�� ��� �ڽ� Terrain�� ���� �ݺ�
        Terrain[] terrainComponents = GetComponentsInChildren<Terrain>();
        if (terrainComponents.Length == 0)
        {
            Debug.LogError("Terrain�� ã�� �� �����ϴ�. �� ��ũ��Ʈ�� Terrain�� �����ϴ� ���ӿ�����Ʈ�� �־�� �մϴ�.");
            return;
        }

        foreach (Terrain terrainComponent in terrainComponents)
        {
            // Terrain�� �ڽ� ������Ʈ�� �� "NavMeshModifierVolume" �̸��� ���� ��� ã��
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
