using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPooling <T> where T : Component
{
    [SerializeField] private Queue<T> qPool;
    public int max;
    int count = 0;

    public ObjectPooling() => qPool ??= new Queue<T>();

    #region public T Spawn(T _prefab, Vector3 _position = default, Quaternion = default)
    public T Spawn(T _prefab,                                          Transform _parent = null) => Spawn(_prefab, Vector3.zero, Quaternion.identity, _parent);
    public T Spawn(T _prefab, Vector3 _position,                       Transform _parent = null) => Spawn(_prefab,    _position, Quaternion.identity, _parent);
    public T Spawn(T _prefab,                    Quaternion _rotation, Transform _parent = null) => Spawn(_prefab, Vector3.zero,           _rotation, _parent);
    public T Spawn(T _prefab, Vector3 _position, Quaternion _rotation, Transform _parent = null)
    {
        if (count >= max) return null;
        count = Mathf.Min(count + 1, max);

        if (qPool.Count == 0) return Object.Instantiate(_prefab, _position, _rotation, _parent) as T;

        T temp = qPool.Dequeue();
        temp.gameObject.SetActive(true);
        temp.transform.position = _position;
        temp.transform.rotation = _rotation;
        temp.transform.parent = _parent;
        return temp;
    }
    #endregion

    public void Despawn(T _temp)
    {
        count = Mathf.Max(0, count - 1);
        _temp.gameObject.SetActive(false);
        qPool.Enqueue(_temp);
    }
}