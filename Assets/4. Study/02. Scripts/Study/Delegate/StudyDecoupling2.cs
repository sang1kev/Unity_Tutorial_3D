using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float damage);
}

public class StudyDecoupling2 : MonoBehaviour
{
    public class Player
    {
        public void AttackEnemy(IDamageable target, float damage)
        {
            target.TakeDamage(damage);
        }
    }

    public class Enemy : MonoBehaviour, IDamageable
    {
        public float health = 10;
        
        public void TakeDamage(float damage)
        {
            health -= damage;
        }
    }
}