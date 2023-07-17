using System.Collections;
using UnityEngine;

namespace Core.Cubes
{
    public class Cube : MonoBehaviour
    {
         private VirtualHorizont _virtualHorizont;

        private void Start()
        {
            // �������� ����� ������ ��"���� �� ����, ��� �� �� ������ �������� ��������� �� ��"��� �� ����, ���� ������ ������ �� ������?
            _virtualHorizont = GameObject.Find("VirtualHorizont").GetComponent<VirtualHorizont>();
            
            _virtualHorizont.ExplodeEvent += StartDestroy;
        }

        private void OnDestroy() => _virtualHorizont.ExplodeEvent -= StartDestroy; 

        private void StartDestroy() => StartCoroutine(DestroyCube());

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
