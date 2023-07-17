using System.Collections.Generic;
using UnityEngine;

public class AllCubes : MonoBehaviour
{
    public List<Vector3> AllPositionsCubes;

    private void Awake()
    {
        AllPositionsCubes.Add(new Vector3(0, 0, 0));
        AllPositionsCubes.Add(new Vector3(0, -1, 0));
    }
}
