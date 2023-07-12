using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Cubes
{
    public class CubeToPlace : MonoBehaviour
    {
        [SerializeField] private float _speedChangePlace;

        private readonly Vector3 _halfExtents = new Vector3(0.5f, 0.5f, 0.5f);
        private readonly List<Vector3> _variantPositionCubeToPlace = new List<Vector3>
        {
            new Vector3(0, 1, 0),
            new Vector3(0, -1, 0),
            new Vector3(1, 0, 0),
            new Vector3(-1, 0, 0),
            new Vector3(0, 0, 1),
            new Vector3(0, 0, -1)
        };

        private Vector3 _lastCubePosition = new Vector3(0, 0, 0);
        private List<Vector3> _validPositions = new List<Vector3>();

        private void Start()
        {
            ValidPositions();
            StartCoroutine(CubePos());
        }

        private void ValidPositions()
        {
            foreach (Vector3 cubePosition in _variantPositionCubeToPlace)
            {
                Vector3 checkingPosition = cubePosition + _lastCubePosition;
                //Vector3 globalPosition = transform.TransformPoint(checkingPosition);

                bool isOccupiedPosition = Physics.CheckBox(checkingPosition, _halfExtents);

                Debug.Log(cubePosition + " = " + checkingPosition + " = " + checkingPosition);

                if (!isOccupiedPosition)
                {
                    _validPositions.Add(checkingPosition);
                }
            }

            foreach (Vector3 pos in _validPositions)
            {
                Debug.Log(pos);
            }
        }

        private IEnumerator CubePos()
        {
            while (true)
            {
                yield return new WaitForSeconds(_speedChangePlace);

                int randomIndex = Random.Range(0, _validPositions.Count);
                //Debug.Log(_validPositions.Count);

                transform.position = _lastCubePosition;
                transform.position = transform.TransformPoint(_validPositions[randomIndex]);
            }
        }
    }
}
