using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _spawnRate = 1f;

    private void Awake()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var secondsForWait = new WaitForSeconds(_spawnRate);

        while (enabled)
        {
            Instantiate(_prefab, _points[Random.Range(0, _points.Length)].position, Quaternion.identity);
            yield return secondsForWait;
        }
    }

#if UNITY_EDITOR
    [ContextMenu("Fill Points Array")]
    private void FillPointsArray()
    {
        _points = new Transform[gameObject.transform.childCount];

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            _points[i] = gameObject.transform.GetChild(i);
        }
    }
#endif
}
