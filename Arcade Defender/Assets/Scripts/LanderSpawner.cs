using System.Collections.Generic;
using UnityEngine;

public class LanderSpawner : Spawner
{

    public GameObject[] _scienttistsSpawnPoints;
    private List<GameObject> _scienttistsPool;
    private Vector3 _directionToScientist;

    public void Start()
    {
        _scienttistsPool = new List<GameObject>(_scienttistsSpawnPoints);
    }

    protected override void SpawnObject(GameObject obj, Vector3 pos)
    {
        obj.transform.position = pos;
        obj.SetActive(true);
        if (_scienttistsPool.Count != 0)//Move toward scientists
        {
            var rbEnemy = obj.GetComponent<Rigidbody2D>();
            _directionToScientist = (_scienttistsPool[0].transform.position - obj.transform.position).normalized;//https://www.youtube.com/watch?v=jdAoLlCn2e8&ab_channel=AlexanderZotov
            rbEnemy.velocity = new Vector2(_directionToScientist.x, _directionToScientist.y) * 0.1f;
            _scienttistsPool.RemoveAt(0);
        }  
    }
}
