using System;
using System.Collections;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public Spawner[] _spawners;
    public GameObject _GameOverText;
    public int _spawnCount = 3;
    private int _totalLandersCount=12;
    public Baiter _baiterSpawner;

    void Start()
    {
        foreach (var spawner in _spawners)//Span Scientists
        {
            if (!spawner._spawnOnEnter)
            {
                spawner.Spawn(_spawnCount);
            }
            else
            {
                spawner.ShipEntered += Spawner_ShipEntered;
            }
        }    

    }

    void Spawner_ShipEntered(object sender, EventArgs e)
    {
        var spawner = sender as Spawner;
        if (spawner != null)
        {
            spawner.ShipEntered -= Spawner_ShipEntered;
            StartCoroutine(SpawnItems(spawner));
        }
    }

    IEnumerator SpawnItems(Spawner spawner)
    {
        if (spawner._spawnDelay > 0)
        {
            yield return new WaitForSeconds(spawner._spawnDelay);
        }

        spawner.Spawn(_spawnCount);
    }

    public void GameOver()
    {
        _GameOverText.SetActive(true);
        StartCoroutine(ChangeScene());
       
    }

    public IEnumerator ChangeScene()
    {
        
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + 2;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1;
        GetComponent<SceneChanger>().MenuScene();
    }

    public int  GetTotalLandersCount()
    {
        return _totalLandersCount;
    }

    public void StartSpawningBaiters()
    {
        _baiterSpawner.InvokSpawnBaiters();
    }

}
