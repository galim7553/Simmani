using GamePlay.Hubs;
using GamePlay.Modules;
using System.Collections;
using UnityEngine;

namespace GamePlay.Scene
{
    /// <summary>
    /// TerrainCuller Ŭ������ ī�޶���� �Ÿ��� �������� Terrain Ȱ��ȭ�� �����Ͽ� ������ ����ȭ�ϴ� ������ �մϴ�.
    /// </summary>
    public class TerrainCuller : ModuleBase
    {
        ITerrainCullerModel _model;
        ICoroutineRunner _runner;

        Terrain[] _terrains;
        Vector3[] _terrainCenters;

        /// <summary>
        /// TerrainCuller ������. Terrain �����͸� �ʱ�ȭ�ϰ�, Terrain �߽� ��ġ�� ����մϴ�.
        /// </summary>
        /// <param name="model">Terrain Culling ���� ��</param>
        /// <param name="terrainParent">Terrain ��ü���� �θ� Transform</param>
        /// <param name="runner">Coroutine �����</param>
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
        /// ���� �������� ī�޶�� Terrain ���� �Ÿ��� ����Ͽ� Terrain�� Ȱ��ȭ�� �����մϴ�.
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


