using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : Singleton<PlayerFire>
{
    public GameObject bulletFactory;
    public GameObject firePosition;

    public int poolSize = 10;
    //public GameObject[] bulletObjectPool;
    //public List<GameObject> bulletObjectPool;
    public Queue<GameObject> bulletObjectPool;

    void Start()
    {
        //bulletObjectPool = new GameObject[poolSize];
        //bulletObjectPool = new List<GameObject>();
        bulletObjectPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);

            //bulletObjectPool[i] = bullet;
            //bulletObjectPool.Add(bullet);
            bulletObjectPool.Enqueue(bullet);

            bullet.SetActive(false);
        }
    }

    void Update()
    {
#if UNITY_STANDARDALONE || UNITY_EDITOR || DEBUG_TEST
        if (Input.GetButtonDown("Fire1"))
        {
            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);

                bullet.transform.position = firePosition.transform.position;
            }
            /*if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool[0];
                bullet.SetActive(true);

                bulletObjectPool.Remove(bullet);

                bullet.transform.position = firePosition.transform.position;
            }

            /*for (int i = 0; i < poolSize; i++)
            {
                GameObject bullet = bulletObjectPool[i];

                if (!bullet.activeSelf)
                {
                    bullet.SetActive(true); 
                    bullet.transform.position = firePosition.transform.position; 

                    break; 
                }
            }*/
        }
    }
#endif
}
