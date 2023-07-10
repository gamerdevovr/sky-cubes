using System.Collections;
using UnityEngine;

namespace Core.Camera
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private float _shakeDur;
        [SerializeField] private float _shakeAmount;
        [SerializeField] private float _decreaseFactor;
        [SerializeField] private float _distanceMovingCamera;

        private Transform _camTransform;
        private Vector3 _originPos;

        private ExplodeCubes _explodeCubes;

        private void Awake()
        {
            _camTransform = GetComponent<Transform>();
        }

        private void Start()
        {
            _explodeCubes = GameObject.Find("Horizont").GetComponent<ExplodeCubes>();

            _explodeCubes.ExplodeEvent += Shake;
        }

        private void OnDestroy()
        {
            _explodeCubes.ExplodeEvent -= Shake;
        }

        private void Shake()
        {
            Debug.Log("Shake");

            transform.localPosition -= new Vector3(0, 0, _distanceMovingCamera);
            _originPos = _camTransform.localPosition;


            StartCoroutine(ShakeCoroutine());
        }

        private IEnumerator ShakeCoroutine()
        {
            bool isShake = true;
            //int i = 1;

            while (isShake)
            {
                if (_shakeDur > 0)
                {
                    _camTransform.localPosition = _originPos + Random.insideUnitSphere * _shakeAmount;
                    _shakeDur -= Time.deltaTime * _decreaseFactor;
                }
                else
                {
                    _shakeDur = 0;
                    _camTransform.localPosition = _originPos;
                    isShake = false;
                }
                //Debug.Log(i++);
            }

            yield return true;
        }
    }
}
