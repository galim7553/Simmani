using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace GamePlay.Scene
{
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


        public CellData GetCellData(Vector3 position)
        {
            Vector2Int pos = new Vector2Int();
            pos.x = Mathf.FloorToInt(position.x / CellSize);
            pos.y = Mathf.FloorToInt(position.z / CellSize);
            if(_cellDataMap.TryGetValue(pos, out var cellData))
                return cellData;
            return null;
        }

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


