using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private Coin _prefabCoin;
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
            Instantiate(_prefabCoin, _points[Random.Range(0, _points.Length)].position, Quaternion.identity);
            yield return secondsForWait;
        }
    }
}
