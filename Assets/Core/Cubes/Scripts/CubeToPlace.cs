using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Cubes
{
    public class CubeToPlace : MonoBehaviour
    {
        [SerializeField] private float _speedChangePlace;

        private CubePositions _cubePositions;
        private List<Vector3> _validPositions;
        private Vector3 _lastCubePosition = new Vector3(0, 1, 0);


        private List<Vector3> _variantPositionCubeToPlace = new List<Vector3>
        {
            new Vector3(0, 1, 0),
            new Vector3(0, -1, 0),
            new Vector3(1, 0, 0),
            new Vector3(-1, 0, 0),
            new Vector3(0, 0, 1),
            new Vector3(0, 0, -1)
        };

        private void Awake()
        {
            _cubePositions = new CubePositions();
            _validPositions = new List<Vector3>();
        }

        private void Start()
        {
            GetValidPositions();
            StartCoroutine(CubePos());
        }

        private void Update()
        {

        }

        private void GetValidPositions()
        {
            foreach (Vector3 cubePosition in _variantPositionCubeToPlace)
            {
                Vector3 checkingPosition = cubePosition + _lastCubePosition;

                bool isFreePosition = IsObjectAtPosition(checkingPosition);

                if (isFreePosition)
                {
                    _validPositions.Add(cubePosition);
                }
            }
        }

        IEnumerator CubePos()
        {
            while (true)
            {
                foreach (Vector3 cubePosition in _validPositions)
                {
                    transform.position = _lastCubePosition;
                    transform.position = transform.TransformPoint(cubePosition);

                    yield return new WaitForSeconds(_speedChangePlace);
                }
            }
        }

        bool IsObjectAtPosition(Vector3 localPosition)
        {
            Vector3 globalPosition = transform.TransformPoint(localPosition);
            Vector3 halfExtents = new Vector3(0.5f, 0.5f, 0.5f); // средняя точка куба, так как куб имеет размеры 1х1х1

            Collider[] colliders = Physics.OverlapBox(globalPosition, halfExtents);

            return colliders.Length > 0; // Возвращает true, если найдены коллайдеры на заданной позиции
        }

        private bool IsPositionEmpty(Vector3 targetPos)
        {
            if (targetPos.y == 0)
                return false;

            foreach (Vector3 pos in _cubePositions)
            {
                if (pos.Equals(targetPos))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
