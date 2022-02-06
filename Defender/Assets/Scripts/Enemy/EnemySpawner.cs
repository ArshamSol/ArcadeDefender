using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawner
{
    public class EnemySpawner : MonoBehaviour//https://www.youtube.com/watch?v=C3VExnf4kmY&ab_channel=AlexanderZotov
    {
        [SerializeField] private MutantEnemy mutant;
        private GameObject newEnemy;
        private SpriteRenderer rend;
        private int randomSpawnZone;
        private float randomXposition, randomYposition;
        private Vector3 spawnPosition;

 
        void Start()
        {
            mutant.enemyBehavior();
            
        }
        public void SpawnNewEnemy()
        {

            /*randomSpawnZone = Random.Range(0, 4);

            switch (randomSpawnZone)
            {

                case 0:

                    randomXposition = Random.Range(-11f, -10f);
                    randomYposition = Random.Range(-8f, -8f);
                    break;
                case 1:

                    randomXposition = Random.Range(-10f, 10f);
                    randomYposition = Random.Range(-7f, -8f);
                    break;
                case 2:

                    randomXposition = Random.Range(10f, 11f);
                    randomYposition = Random.Range(-8f, 8f);
                    break;
                case 3:

                    randomXposition = Random.Range(10f, 11f);
                    randomYposition = Random.Range(7f, 8f);
                    break;

            }


            spawnPosition = new Vector3(randomXposition, randomYposition, 0f);
            newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
            rend = newEnemy.GetComponent<SpriteRenderer>();
            rend.color = new Color(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2), 1f);*/
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}