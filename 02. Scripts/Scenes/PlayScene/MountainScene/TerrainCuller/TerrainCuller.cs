using GamePlay.Hubs;
using GamePlay.Modules;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Scene
{
    public class TerrainCuller : ModuleBase
    {
        ITerrainCullerModel _model;
        ICoroutineRunner _runner;

        Terrain[] _terrains;
        Vector3[] _terrainCenters;

        public TerrainCuller(ITerrainCullerModel model, Transform terrainParent, ICoroutineRunner runner)
        {
            _model = model;
            _terrains = terrainParent.GetComponentsInChildren<Terrain>(true);
            _runner = runner;

            _terrainCenters = new Vector3[_terrains.Length];
            for (int i = 0; i < _terrains.Length; i++)
            {
                _terrainCenters[i] = _terrains[i].transform.position
                    + _terrains[i].terrainData.size.x * 0.5f * Vector3.right
                    + _terrains[i].terrainData.size.z * 0.5f * Vector3.forward;
                _terrainCenters[i].y = 0;
            }
        }


        public void Start()
        {
            _runner.RunCoroutine(UpdateTerrainsCulling());
        }


        IEnumerator UpdateTerrainsCulling()
        {
            while (true)
            {
                if (Camera.main != null)
                {
                    Vector3 cameraPos = Camera.main.transform.position;
                    cameraPos.y = 0;
                    for (int i = 0; i < _terrains.Length; i++)
                    {
                        float dist = Vector3.Distance(cameraPos, _terrainCenters[i]);
                        _terrains[i].gameObject.SetActive(dist < _model.Threshold);
                    }
                }
                yield return new WaitForSeconds(_model.UpdateSpan);
            }
        }

    }
}


