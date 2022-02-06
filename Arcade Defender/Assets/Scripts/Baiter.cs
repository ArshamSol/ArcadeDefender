using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baiter : MonoBehaviour
{
    public GameObject _BaiterPrefab;
 
    public GameObject[] _baitersPosition;
    public GameObject[] _baiters;
    private List<GameObject> _baitersPool;

    public void InvokSpawnBaiters()
    {
        _baitersPool = new List<GameObject>(_baiters);
        InvokeRepeating("SpawnBaiters", 0f, 3f);
    }

    private void SpawnBaiters()
    {
        int _randomIndex = Random.Range(0, _baitersPosition.Length);
        float _randomXposition = _baitersPosition[_randomIndex].transform.position.x;
        float _randomYposition = _baitersPosition[_randomIndex].transform.position.y;
        //var spawnPosition = new Vector3(_randomXposition, _randomYposition, 0f);
        if (_baitersPool.Count != 0)
        {
            _baitersPool[0].transform.position = new Vector3(_randomXposition, _randomYposition, 0);
            _baitersPool[0].SetActive(true);
            _baitersPool.RemoveAt(0);
        }
        else
        {
            CancelInvoke();
        }
    }
}
