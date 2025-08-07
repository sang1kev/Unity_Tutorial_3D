using UnityEngine;

public class StudyDecoupling : MonoBehaviour
{
    public class Player
    {
        public Enemy enemy;

        public void AttackEnemy()
        {
            enemy.TakeDamage(10);
        }
    }

    public class Enemy
    {
        public float health = 10;
        
        public void TakeDamage(float damage)
        {
            health -= damage;
            Debug.Log("damage만큼 공격 받음");
        }
    }
}