using System.Collections;
using UnityEngine;

namespace Core.Cubes
{
    public class Cube : MonoBehaviour
    {
         public Vector3 Size => new Vector3(1, 1, 1);

         private ExplodeCubes _explodeCubes;

        private void Start()
        {
            _explodeCubes = GameObject.Find("Horizont").GetComponent<ExplodeCubes>();
            
            _explodeCubes.ExplodeEvent += StartDestroy;
        }

        private void OnDestroy()
        {
            _explodeCubes.ExplodeEvent -= StartDestroy; 
        }

        private void StartDestroy()
        {
            StartCoroutine(DestroyCube());
        }

        private IEnumerator DestroyCube()
        {
            float waitSecont = 2f;
            yield return new WaitForSeconds(waitSecont);

            float yPosition = transform.position.y;
            float yPositionDestroy = -3f;

            if (yPosition < yPositionDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}
