using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Cubes
{
    public class CubePositions : IEnumerable<Vector3>
    {
        public int Length => _targetPositions.Length;

        private Vector3[] _targetPositions =
        //{
        //    new Vector3(0, 0, 0),
        //    new Vector3(1, 0, 0),
        //    new Vector3(-1, 0, 0),
        //    new Vector3(0, 1, 0),
        //    new Vector3(0, 0, 1),
        //    new Vector3(0, 0, -1),
        //    new Vector3(1, 0, 1),
        //    new Vector3(-1, 0, -1),
        //    new Vector3(-1, 0, 1),
        //    new Vector3(1, 0, -1),
        //};
        {

            new Vector3(0, 1, 0),
            new Vector3(0, -1, 0),
            new Vector3(1, 0, 0),
            new Vector3(-1, 0, 0),
            new Vector3(0, 0, 1),
            new Vector3(0, 0, -1)
        };

        public IEnumerator<Vector3> GetEnumerator()
        {
            return ((IEnumerable<Vector3>)_targetPositions).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _targetPositions.GetEnumerator();
        }
    }
}