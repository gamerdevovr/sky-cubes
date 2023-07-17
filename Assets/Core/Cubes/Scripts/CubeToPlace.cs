using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.Cubes
{
    public class CubeToPlace : MonoBehaviour
    {
        [SerializeField] private AllCubes _allCubes;
        [SerializeField] private GameObject[] _cubes;
        [SerializeField] private float _speedChangePlace;

        private readonly List<Vector3> _variantPositionCubeToPlace = new List<Vector3>
        {
            new Vector3(0, 1, 0),
            new Vector3(0, -1, 0),
            new Vector3(1, 0, 0),
            new Vector3(-1, 0, 0),
            new Vector3(0, 0, 1),
            new Vector3(0, 0, -1)
        };

        private InputManager _inputManager => InputManager.Instance;
        private List<Vector3> _validPositions;
        private Transform _lastCube;
        private int randomIndex;

        private void Start()
        {
            _lastCube = GameObject.Find("MainCube").transform;

            _inputManager.ClickToScreenEvent += ClickHandler;

            // TODO: Після тестів видалити
            _inputManager.ClickRightEvent += Right;

            ValidPositions();
            StartCoroutine(CubePos());
        }

        private void OnDestroy() => _inputManager.ClickToScreenEvent -= ClickHandler;
 
        private void ValidPositions() => _validPositions =  _variantPositionCubeToPlace.Except(_allCubes.AllPositionsCubes).ToList();
      
        private void ClickHandler()
        {

            _allCubes.AllPositionsCubes.Add(_validPositions[randomIndex]);

            GameObject newCube = Instantiate(_cubes[0], _validPositions[randomIndex], Quaternion.identity);
            newCube.transform.SetParent(_allCubes.transform);
            newCube.name = "MainCube";

            _lastCube.name = "Cube";
            _lastCube = newCube.transform;

            ValidPositions();
        }

        private IEnumerator CubePos()
        {
            int previousIndex = -1;

            while (true)
            {
                yield return new WaitForSeconds(_speedChangePlace);

                do
                {
                    randomIndex = Random.Range(0, _validPositions.Count);
                } while (randomIndex == previousIndex);

                previousIndex = randomIndex;

                transform.position = _lastCube.position;
                transform.position = transform.TransformPoint(_validPositions[randomIndex]);
            }
        }

        // TODO: Після тестів видалити
        private void Right()
        {
            foreach(Vector3 pos in _validPositions)
                Debug.Log(pos);
        }
    }
}
