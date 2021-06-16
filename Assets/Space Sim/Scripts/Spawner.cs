using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static ObjectPooling<Minable> pool;

    public Vector3 centre = Vector3.zero;
    public Vector3 size = Vector3.one;

    [SerializeField] private Minable prefab = null;

    [SerializeField]
    private List<Minable> minables = new List<Minable>();

    private void Awake()
    {
        pool ??= new ObjectPooling<Minable>();
        pool.max = 10;
    }

    private void Update()
    {
        if (minables.Count < 10) StartCoroutine(WaitSecondsForSpawn(Random.Range(30, 210)));
    }

    private IEnumerator WaitSecondsForSpawn(int _seconds)
    {
        yield return new WaitForSeconds(_seconds);
        Spawn();
    }

    public void Spawn()
    {
        Debug.Log("Spawning");
        Vector3 pos = transform.position + new Vector3(Random.Range(-size.x * 0.5f, size.x * 0.5f),
                                                       Random.Range(-size.y * 0.5f, size.y * 0.5f),
                                                       Random.Range(-size.z * 0.5f, size.z * 0.5f)) + centre;
        pos = transform.InverseTransformPoint(pos);
        Minable minable = pool.Spawn(prefab, pos, transform);
        if (prefab == null) throw new System.NullReferenceException();
        if (minable != null) minables.Add(minable);
        Debug.Log(minables.Count.ToString());
    }
}