using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private Vector3 dir;
    public float speed = 5;

    public GameObject explosionFactory;

    private void OnEnable()
    {
        int ranValue = UnityEngine.Random.Range(0, 10);

        if (ranValue < 8) // 80%
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position; // 플레이어를 바라보는 방향 값
            dir.Normalize();
        }
        else // 20%
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        ScoreManager.Instance.Score++;

        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        if(other.gameObject.name.Contains("Bullet"))
        {
            //PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            //player.bulletObjectPool.Add(other.gameObject);
            PlayerFire.Instance.bulletObjectPool.Enqueue(other.gameObject);

            other.gameObject.SetActive(false);
        }
        else
        {
            Destroy(other.gameObject);
        }

        EnemyManager.Instance.enemyObjPool.Enqueue(gameObject);
        gameObject.SetActive(false);
    }
}
