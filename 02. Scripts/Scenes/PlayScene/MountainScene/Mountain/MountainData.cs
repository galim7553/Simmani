using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GamePlay.Scene
{
    /// <summary>
    /// 단일 셀에 대한 데이터 클래스. 셀의 위치, 중심 좌표, 관련 지형, 스폰 가능 여부를 포함합니다.
    /// </summary>
    [Serializable]
    public class CellData
    {
        [SerializeField] Vector2Int _pos;
        public Vector2Int Pos => _pos;

        [SerializeField] Vector3 _centerPos;
        public Vector3 CenterPos => _centerPos;

        [SerializeField] int _terrainIndex;
        public int TerrainIndex => _terrainIndex;

        [SerializeField] bool _isSpawnable;
        public bool IsSpawnable => _isSpawnable;

        public CellData(Vector2Int pos, Vector3 centerPos, int terrainIndex, bool isSpawnable)
        {
            _pos = pos;
            _centerPos = centerPos;
            _terrainIndex = terrainIndex;
            _isSpawnable = isSpawnable;
        }
    }


    /// <summary>
    /// 다수의 셀 데이터를 보관하는 컨테이너 클래스. 셀의 크기와 스폰 반경 포함.
    /// </summary>
    [Serializable]
    public class CellDataContainer
    {
        [SerializeField] List<CellData> _cellDatas;
        public IReadOnlyList<CellData> CellDatas => _cellDatas;

        [SerializeField] float _cellSize;
        public float CellSize => _cellSize;

        [SerializeField] float _spawnRadius;
        public float SpawnRadius => _spawnRadius;

        public CellDataContainer(List<CellData> cellDatas, float cellSize, float spawnRadius)
        {
            _cellDatas = cellDatas;
            _cellSize = cellSize;
            _spawnRadius = spawnRadius;
        }
    }

    /// <summary>
    /// 산 지형 데이터 관리 클래스. 셀 데이터와 스폰 가능한 셀을 관리하며, 셀 검색 기능을 제공합니다.
    /// </summary>
    public class MountainData
    {
        CellDataContainer _cellDataContainer;

        public float CellSize => _cellDataContainer.CellSize;
        public float SpawnRadius => _cellDataContainer.SpawnRadius;
        int _cellRowCount = 0;
        Dictionary<Vector2Int, CellData> _cellDataMap = new Dictionary<Vector2Int, CellData>();


        List<CellData> _spawnableCellDatas = new List<CellData>();
        public IReadOnlyList<CellData> SpawnableCellDatas => _spawnableCellDatas;

        public MountainData(CellDataContainer cellDataContainer)
        {
            _cellDataContainer = cellDataContainer;

            foreach(var cellData in _cellDataContainer.CellDatas)
                _cellDataMap[cellData.Pos] = cellData;
            _cellRowCount = Mathf.RoundToInt(Mathf.Sqrt(_cellDataMap.Count));

            _spawnableCellDatas = _cellDataContainer.CellDatas.Where(c => c.IsSpawnable == true).ToList();
        }


        /// <summary>
        /// 지정된 위치에 해당하는 셀 데이터를 반환합니다.
        /// </summary>
        /// <param name="position">월드 좌표</param>
        /// <returns>셀 데이터 또는 null</returns>
        public CellData GetCellData(Vector3 position)
        {
            Vector2Int pos = new Vector2Int();
            pos.x = Mathf.FloorToInt(position.x / CellSize);
            pos.y = Mathf.FloorToInt(position.z / CellSize);
            if(_cellDataMap.TryGetValue(pos, out var cellData))
                return cellData;
            return null;
        }

        /// <summary>
        /// 특정 위치 주변의 셀 데이터를 반환합니다.
        /// </summary>
        /// <param name="position">기준 위치</param>
        /// <param name="minDist">최소 거리</param>
        /// <param name="maxDist">최대 거리</param>
        /// <param name="isSpawnable">스폰 가능 여부</param>

        public List<CellData> GetSurroundingCellDatas(Vector3 position, float minDist, float maxDist, bool isSpawnable = true)
        {
            List<CellData> cellDatas = new List<CellData>();
            CellData cellData = GetCellData(position);
            if(cellData == null) return cellDatas;

            int halfLegnth = Mathf.RoundToInt(maxDist / CellSize);


            Vector2Int pos = new Vector2Int();
            for(int x = Mathf.Max(cellData.Pos.x - halfLegnth, 0); x < Mathf.Min(cellData.Pos.x + halfLegnth + 1, _cellRowCount); x++)
            {
                for(int z = Mathf.Max(cellData.Pos.y - halfLegnth, 0); z < Mathf.Min(cellData.Pos.x + halfLegnth + 1, _cellRowCount); z++)
                {
                    pos.x = x;
                    pos.y = z;
                    if(_cellDataMap.TryGetValue(pos, out var surroundingCell))
                    {
                        float dist = Vector3.Distance(cellData.CenterPos, surroundingCell.CenterPos);
                        if (dist > minDist && dist < maxDist
                            &&  surroundingCell.IsSpawnable == isSpawnable)
                                cellDatas.Add(surroundingCell);
                    }
                }
            }

            return cellDatas;
        }
    }
}


