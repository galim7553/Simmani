using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public class TerrainHolder : ModuleBase, IGroundHolder<Terrain>, IUpdatable, IFixedUpdatable
    {
        float _offset;
        Transform _transform;
        Terrain _ground;

        Vector3 _position;

        public TerrainHolder(Transform transform, Terrain ground)
        {
            _transform = transform;
            SetGround(ground);
        }

        public void OnUpdate()
        {
            HoldTerrain();
        }
        public void OnFixedUpdate()
        {
            HoldTerrain();
        }

        void HoldTerrain()
        {
            if (IsActive == false) return;

            if (_ground == null)
            {
                Debug.LogWarning("Terrain is not set for TerrainHolder.");
                return;
            }

            if (_position == _transform.position) return;

            _position = _transform.position;
            _position.y = _ground.SampleHeight(_position) + _offset;
            _transform.position = _position;
        }

        public void SetGround(Terrain ground)
        {
            _ground = ground;
        }
        public void SetOffset(float offset)
        {
            _offset = offset;
        }
        public float SetOffsetAuto()
        {
            _offset = _transform.position.y - _ground.SampleHeight(_transform.position);
            return _offset;
        }
    }
}

