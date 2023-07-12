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

        private VirtualHorizont _virtualHorizont;

        private void Awake()
        {
            _camTransform = GetComponent<Transform>();
        }

        private void Start()
        {
            _virtualHorizont = GameObject.Find("VirtualHorizont").GetComponent<VirtualHorizont>();

            _virtualHorizont.ExplodeEvent += Shake;
        }

        private void OnDestroy()
        {
            _virtualHorizont.ExplodeEvent -= Shake;
        }

        private void Shake()
        {
            transform.localPosition -= new Vector3(0, 0, _distanceMovingCamera);
            _originPos = _camTransform.localPosition;

            StartCoroutine(ShakeCoroutine());
        }

        private IEnumerator ShakeCoroutine()
        {
            bool isShake = true;

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
            }

            yield return true;
        }
    }
}
