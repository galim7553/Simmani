using GamePlay.Hubs;
using GamePlay.Modules;
using System.Collections;
using UnityEngine;

namespace GamePlay.Scene
{
    /// <summary>
    /// TerrainCuller 클래스는 카메라와의 거리를 기준으로 Terrain 활성화를 관리하여 성능을 최적화하는 역할을 합니다.
    /// </summary>
    public class TerrainCuller : ModuleBase
    {
        ITerrainCullerModel _model;
        ICoroutineRunner _runner;

        Terrain[] _terrains;
        Vector3[] _terrainCenters;

        /// <summary>
        /// TerrainCuller 생성자. Terrain 데이터를 초기화하고, Terrain 중심 위치를 계산합니다.
        /// </summary>
        /// <param name="model">Terrain Culling 설정 모델</param>
        /// <param name="terrainParent">Terrain 객체들의 부모 Transform</param>
        /// <param name="runner">Coroutine 실행기</param>
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

        /// <summary>
        /// 일정 간격으로 카메라와 Terrain 간의 거리를 계산하여 Terrain의 활성화를 관리합니다.
        /// </summary>
        /// <returns>Coroutine</returns>
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


