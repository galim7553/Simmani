using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TerrainData))]
public class TerrainDataCustomEditor : Editor
{
    private float heightMultiplier = 1.0f;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TerrainData terrainData = (TerrainData)target;

        // 현재 나무 수 표시
        int treeCount = terrainData.treeInstanceCount;
        EditorGUILayout.LabelField("Current Tree Count", treeCount.ToString());

        // 나무와 디테일 삭제 버튼
        if (GUILayout.Button("Clear Trees and Details"))
        {
            ClearTreesAndDetails(terrainData);
        }

        // 나무 수 절반 줄이기 버튼
        if (GUILayout.Button("Reduce Tree Count by Half"))
        {
            ReduceTreeCountByHalf(terrainData);
        }

        // 높이맵 스케일 값 입력 필드
        heightMultiplier = EditorGUILayout.Slider("Height Multiplier", heightMultiplier, 0f, 10f);
        if (GUILayout.Button("Apply Height Multiplier"))
        {
            ApplyHeightMultiplier(terrainData, heightMultiplier);
        }
    }

    private void ClearTreesAndDetails(TerrainData terrainData)
    {
        if (terrainData != null)
        {
            Undo.RegisterCompleteObjectUndo(terrainData, "Clear Trees");
            terrainData.treeInstances = new TreeInstance[0];
            Debug.Log("All trees have been cleared from the TerrainData.");

            Undo.RegisterCompleteObjectUndo(terrainData, "Clear Details");
            int detailLayerCount = terrainData.detailPrototypes.Length;
            int width = terrainData.detailWidth;
            int height = terrainData.detailHeight;

            for (int layer = 0; layer < detailLayerCount; layer++)
            {
                int[,] emptyDetailLayer = new int[width, height];
                terrainData.SetDetailLayer(0, 0, layer, emptyDetailLayer);
            }
            Debug.Log("All details (grass) have been cleared from the TerrainData.");

            EditorUtility.SetDirty(terrainData);
        }
    }

    private void ApplyHeightMultiplier(TerrainData terrainData, float multiplier)
    {
        if (terrainData != null)
        {
            int heightmapWidth = terrainData.heightmapResolution;
            int heightmapHeight = terrainData.heightmapResolution;
            float[,] heights = terrainData.GetHeights(0, 0, heightmapWidth, heightmapHeight);

            Undo.RegisterCompleteObjectUndo(terrainData, "Apply Height Multiplier");

            for (int x = 0; x < heightmapWidth; x++)
            {
                for (int y = 0; y < heightmapHeight; y++)
                {
                    heights[x, y] *= multiplier;
                }
            }

            terrainData.SetHeights(0, 0, heights);
            EditorUtility.SetDirty(terrainData);
            Debug.Log($"Height multiplier {multiplier} applied to the terrain.");
        }
    }

    private void ReduceTreeCountByHalf(TerrainData terrainData)
    {
        if (terrainData != null)
        {
            Undo.RegisterCompleteObjectUndo(terrainData, "Reduce Tree Count by Half");

            TreeInstance[] originalTrees = terrainData.treeInstances;
            List<TreeInstance> reducedTrees = new List<TreeInstance>();

            for (int i = 0; i < originalTrees.Length; i++)
            {
                if (i % 2 == 0)
                {
                    reducedTrees.Add(originalTrees[i]);
                }
            }

            terrainData.treeInstances = reducedTrees.ToArray();
            EditorUtility.SetDirty(terrainData);
            Debug.Log($"Tree count reduced by half. New count: {reducedTrees.Count}");
        }
    }

}
