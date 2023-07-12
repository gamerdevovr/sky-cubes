using System;
using UnityEngine;

public class VirtualHorizont : MonoBehaviour
{
    public event Action ExplodeEvent;

    [SerializeField] private GameObject _explosion;
    [SerializeField] private float _explosionForce = 70f;
    [SerializeField] private Vector3 _explosionPosition = Vector3.up;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private Vector3 _scaleAfterExplosion = new Vector3(3f, 0.5f, 3f);

    private void OnCollisionEnter(Collision collision)
    {
        int countCubes = collision.transform.childCount - 1;

        for (int i = countCubes; i >= 0; i--)
        {
            Transform child = collision.transform.GetChild(i);
            child.SetParent(null);

            GameObject cube = child.gameObject;

            cube.AddComponent<Rigidbody>();
            cube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, _explosionPosition, _explosionRadius);
        }

        Vector3 pointInstantiateExplode = collision.contacts[0].point;

        GameObject newExplosion = Instantiate(_explosion, pointInstantiateExplode, Quaternion.identity);
        Destroy(newExplosion, 2.5f);

        transform.localScale = _scaleAfterExplosion;

        ExplodeEvent.Invoke();
    }
}
