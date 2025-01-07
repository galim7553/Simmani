using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace GamePlay.Scene
{
    /// <summary>
    /// �� ������ ���� Ŭ����.
    /// �־��� Terrain �����͸� ������� �� �����͸� �����ϰ� ���� ���� ���θ� Ȯ���Ͽ� JSON ���Ϸ� �����մϴ�.
    /// </summary>
    public class CellDataCreator : MonoBehaviour
    {
        [SerializeField] Transform _terrainParent;              // ��ü �ͷ��ε��� �θ�
        [SerializeField] int _cellSize = 16;                 // �� �� ũ�� (16x16 ũ���� ��, �� 48x48 = 2304 ��)
        [SerializeField] float _checkRadius = 1f;               // �� �������� NavMesh ��ħ Ȯ�� �ݰ�
        [SerializeField] float _spawnThreshold = 0.5f;          // NavMesh���� ��ħ �Ӱ谪
        [SerializeField] float _spawnRadius = 4.0f;

        Terrain[] _terrains;
        int _terrainSize;
        int _terrainRowCount;

        int _cellRowCount;
        int _terrainCellRowCount;

        [SerializeField] List<CellData> _cellDatas = new List<CellData>();


        /// <summary>
        /// Context Menu���� ȣ�� ������ �޼���.
        /// �� �����͸� �����ϰ� JSON ���Ϸ� �����մϴ�.
        /// </summary>
        [ContextMenu("Generate Cell Datas")]
        public void GenerateCellDatas()
        {
            InitializeTerrains();
            DetermineSpawnableCells();
            SaveSpawnDataToJson();
        }

        /// <summary>
        /// Terrain �ʱ�ȭ �� ������ �غ�.
        /// </summary>
        void InitializeTerrains()
        {
            _terrains = _terrainParent.GetComponentsInChildren<Terrain>();
            CalculateAreaBounds();
        }

        /// <summary>
        /// Terrain ���� ���.
        /// Terrain�� ũ��� �� ������ �������� �� ��꿡 �ʿ��� ���� �����մϴ�.
        /// </summary>
        void CalculateAreaBounds()
        {
            if (_terrains == null || _terrains.Length == 0)
            {
                Debug.LogWarning("No terrains found under the specified parent.");
                return;
            }

            _terrainRowCount = Mathf.RoundToInt(Mathf.Sqrt(_terrains.Length));  // ���ĵ� n*n ������ �ͷ��� ���� ���
            Terrain firstTerrain = _terrains[0];
            _terrainSize = Mathf.RoundToInt(firstTerrain.terrainData.size.x);

            _cellRowCount = (_terrainRowCount * _terrainSize) / _cellSize;
            _terrainCellRowCount = _terrainSize / _cellSize;
        }

        /// <summary>
        /// ���� ������ ���� Ȯ���ϰ� �����͸� �����մϴ�.
        /// </summary>
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

        /// <summary>
        /// �־��� ���� Terrain �ε����� ��ȯ�մϴ�.
        /// </summary>
        /// <param name="pos">���� 2D ��ǥ</param>
        /// <returns>Terrain �ε���</returns>
        int GetTerrainIndex(Vector2Int pos)
        {
            int x = pos.x / _terrainCellRowCount;
            int z = pos.y / _terrainCellRowCount;
            return x * _terrainRowCount + z;
        }


        /// <summary>
        /// �� ������ �˻� �������� ��ȯ�մϴ�.
        /// </summary>
        /// <param name="cellPos">�� ��ġ</param>
        /// <param name="terrainIndex">���� ���� Terrain�� �ε���</param>
        /// <param name="centerPos">�� �߽� ��ǥ</param>
        /// <returns>�� ������ ���� �迭</returns>
        Vector3[] GetCellPoints(Vector2Int cellPos, out int terrainIndex, out Vector3 centerPos)
        {
            terrainIndex = GetTerrainIndex(cellPos);
            centerPos = new Vector3(cellPos.x * _cellSize + _cellSize / 2, 0, cellPos.y * _cellSize + _cellSize / 2);

            float quarterCell = _cellSize / 4;
            float threeQuarterCell = 3 * quarterCell;

            Vector3[] points = new Vector3[]
            {
                centerPos,  // �߽� ����
                centerPos + new Vector3(quarterCell, 0, quarterCell),
                centerPos + new Vector3(threeQuarterCell, 0, quarterCell),
                centerPos + new Vector3(quarterCell, 0, threeQuarterCell),
                centerPos + new Vector3(threeQuarterCell, 0, threeQuarterCell)
            };

            // �� ������ y ��ǥ�� �ش� ��ġ�� Terrain ���̿� �°� ����
            for (int i = 0; i < points.Length; i++)
            {
                points[i].y = GetTerrainHeight(terrainIndex, points[i]);
            }
            return points;
        }

        /// <summary>
        /// �־��� ��ġ���� Terrain�� ���̸� ��ȯ�մϴ�.
        /// </summary>
        /// <param name="terrainIndex">Terrain �ε���</param>
        /// <param name="position">��ǥ</param>
        /// <returns>Terrain ����</returns>
        float GetTerrainHeight(int terrainIndex, Vector3 position)
        {
            return _terrains[terrainIndex].SampleHeight(position);
        }

        /// <summary>
        /// Ư�� ��ġ���� NavMesh ��ħ ���θ� Ȯ���մϴ�.
        /// </summary>
        /// <param name="position">��ġ</param>
        /// <param name="radius">�ݰ�</param>
        /// <param name="threshold">��ħ �Ӱ谪</param>
        /// <returns>NavMesh ��ħ ����</returns>
        bool IsNavMeshAtPoint(Vector3 position, float radius, float threshold)
        {
            NavMeshHit hit;
            bool isNavMeshFound = NavMesh.SamplePosition(position, out hit, radius, NavMesh.AllAreas);

            return isNavMeshFound && (hit.distance <= radius * threshold);
        }

        /// <summary>
        /// ������ �� �����͸� JSON �������� �����մϴ�.
        /// </summary>
        void SaveSpawnDataToJson()
        {
            string path = Path.Combine(Application.dataPath, "CellDatas.json");
            string jsonData = JsonUtility.ToJson(new CellDataContainer(_cellDatas, _cellSize, _spawnRadius), true);
            File.WriteAllText(path, jsonData);
            Debug.Log("CellData���� JSON �������� ����Ǿ����ϴ�: " + path);

            // ���� ������ (isSpawnable�� true��) ���� ������ ���
            int spawnableCount = 0;
            foreach (var cellData in _cellDatas)
            {
                if (cellData.IsSpawnable)
                {
                    spawnableCount++;
                }
            }
            Debug.Log($"���� ������ ���� ��: {spawnableCount}");

#if UNITY_EDITOR
            AssetDatabase.Refresh();
#endif
        }

    }
}