using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public int poolSize = 10;

    //public GameObject[] enemyObjPool;
    public Transform[] spawnPoints;
    //public List<GameObject> enemyObjPool;
    public Queue<GameObject> enemyObjPool;


    private float currentTime; // 타이머

    private float minTime = 1;
    private float maxTime = 3;

    public float createTime = 1f; // 생성 주기

    public GameObject enemyFactory;

    void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        //enemyObjPool = new List<GameObject>();
        enemyObjPool = new Queue<GameObject>();

        for(int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);

            enemyObjPool.Enqueue(enemy);
            enemy.SetActive(false);
        }
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime) // 타이머가 생성 주기를 넘었다면
        {

            if (enemyObjPool.Count > 0)
            {
                currentTime = 0f;
                createTime = Random.Range(minTime, maxTime);

                int ranIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[ranIndex];

                GameObject enemy = enemyObjPool.Dequeue();
                enemy.SetActive(true);

                enemy.transform.position = spawnPoint.position;
            }

            /*if (enemyObjPool.Count > 0)
            {
                int ranIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[ranIndex];

                GameObject enemy = enemyObjPool[0];
                enemy.SetActive(true);

                enemyObjPool.Add(enemy);

                enemy.transform.position = spawnPoint.position;

            }
            /*for (int i = 0;i < poolSize; i++)
            {
                GameObject enemy = enemyObjPool[i];
                if(!enemy.activeSelf)
                {
                    int ranIndex = Random.Range(0, spawnPoints.Count);
                    Transform spawnPoint = spawnPoints[ranIndex];

                    enemy.transform.position = spawnPoint.position;
                    enemy.SetActive(true);

                    break;
                }
            }*/
        }
    }
}
