using UnityEngine;
using Unity.Mathematics;

public class PoolObjects : MonoBehaviour {

    [SerializeField] private int _poolCount = 3;
    [SerializeField] private PooledObject pooledObjectPrefab;

    private PoolMono<PooledObject> _pool;

    private void Start()
    {
        this._pool = new PoolMono<PooledObject>(this.pooledObjectPrefab, this._poolCount, this.transform);
    }

    public GameObject CreateObject(Vector3 position, Quaternion rotation)
    {
        var example = this._pool.GetFreeElement();
        example.transform.position = position;
        example.transform.rotation = rotation;

        return example.gameObject;
    }

}
