using System.Collections;
using System.Collections.Generic;
using GamePlay.Scene;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace GamePlay.Scene
{
    public class CellDataCreator : MonoBehaviour
    {
        [SerializeField] Transform _terrainParent;              // 전체 터레인들의 부모
        [SerializeField] int _cellSize = 16;                 // 각 셀 크기 (16x16 크기의 셀, 총 48x48 = 2304 셀)
        [SerializeField] float _checkRadius = 1f;               // 각 지점에서 NavMesh 겹침 확인 반경
        [SerializeField] float _spawnThreshold = 0.5f;          // NavMesh와의 겹침 임계값
        [SerializeField] float _spawnRadius = 4.0f;

        Terrain[] _terrains;
        int _terrainSize;
        int _terrainRowCount;

        int _cellRowCount;
        int _terrainCellRowCount;

        [SerializeField] List<CellData> _cellDatas = new List<CellData>();

        [ContextMenu("Generate Cell Datas")]
        public void GenerateCellDatas()
        {
            InitializeTerrains();
            DetermineSpawnableCells();
            SaveSpawnDataToJson();
        }

        void InitializeTerrains()
        {
            _terrains = _terrainParent.GetComponentsInChildren<Terrain>();
            CalculateAreaBounds();
        }

        void CalculateAreaBounds()
        {
            if (_terrains == null || _terrains.Length == 0)
            {
                Debug.LogWarning("No terrains found under the specified parent.");
                return;
            }

            _terrainRowCount = Mathf.RoundToInt(Mathf.Sqrt(_terrains.Length));  // 정렬된 n*n 형태의 터레인 개수 계산
            Terrain firstTerrain = _terrains[0];
            _terrainSize = Mathf.RoundToInt(firstTerrain.terrainData.size.x);

            _cellRowCount = (_terrainRowCount * _terrainSize) / _cellSize;
            _terrainCellRowCount = _terrainSize / _cellSize;
        }

        void DetermineSpawnableCells()
        {
            _cellDatas.Clear();

            for (int x = 0; x < _cellRowCount; x++)
            {
                for (int z = 0; z < _cellRowCount; z++)
                {
                    Vector2Int cellPos = new Vector2Int(x, z);
                    Vector3[] points = GetCellPoints(cellPos, out int terrainIndex, out Vector3 centerPos);
                    bool isSpawnable = true;

                    foreach (Vector3 point in points)
                    {
                        if (!IsNavMeshAtPoint(point, _checkRadius, _spawnThreshold))
                        {
                            isSpawnable = false;
                            break;
                        }
                    }

                    _cellDatas.Add(new CellData(cellPos, centerPos, terrainIndex, isSpawnable));
                }
            }
        }


        int GetTerrainIndex(Vector2Int pos)
        {
            int x = pos.x / _terrainCellRowCount;
            int z = pos.y / _terrainCellRowCount;
            return x * _terrainRowCount + z;
        }

        Vector3[] GetCellPoints(Vector2Int cellPos, out int terrainIndex, out Vector3 centerPos)
        {
            terrainIndex = GetTerrainIndex(cellPos);
            centerPos = new Vector3(cellPos.x * _cellSize + _cellSize / 2, 0, cellPos.y * _cellSize + _cellSize / 2);

            float quarterCell = _cellSize / 4;
            float threeQuarterCell = 3 * quarterCell;

            Vector3[] points = new Vector3[]
            {
                centerPos,  // 중심 지점
                centerPos + new Vector3(quarterCell, 0, quarterCell),
                centerPos + new Vector3(threeQuarterCell, 0, quarterCell),
                centerPos + new Vector3(quarterCell, 0, threeQuarterCell),
                centerPos + new Vector3(threeQuarterCell, 0, threeQuarterCell)
            };

            // 각 지점의 y 좌표를 해당 위치의 Terrain 높이에 맞게 설정
            for (int i = 0; i < points.Length; i++)
            {
                points[i].y = GetTerrainHeight(terrainIndex, points[i]);
            }
            return points;
        }

        float GetTerrainHeight(int terrainIndex, Vector3 position)
        {
            return _terrains[terrainIndex].SampleHeight(position);
        }

        bool IsNavMeshAtPoint(Vector3 position, float radius, float threshold)
        {
            NavMeshHit hit;
            bool isNavMeshFound = NavMesh.SamplePosition(position, out hit, radius, NavMesh.AllAreas);

            return isNavMeshFound && (hit.distance <= radius * threshold);
        }

        void SaveSpawnDataToJson()
        {
            string path = Path.Combine(Application.dataPath, "CellDatas.json");
            string jsonData = JsonUtility.ToJson(new CellDataContainer(_cellDatas, _cellSize, _spawnRadius), true);
            File.WriteAllText(path, jsonData);
            Debug.Log("CellData들이 JSON 형식으로 저장되었습니다: " + path);

            // 스폰 가능한 (isSpawnable이 true인) 셀의 개수를 계산
            int spawnableCount = 0;
            foreach (var cellData in _cellDatas)
            {
                if (cellData.IsSpawnable)
                {
                    spawnableCount++;
                }
            }
            Debug.Log($"스폰 가능한 셀의 수: {spawnableCount}");

#if UNITY_EDITOR
            AssetDatabase.Refresh();
#endif
        }

    }
}