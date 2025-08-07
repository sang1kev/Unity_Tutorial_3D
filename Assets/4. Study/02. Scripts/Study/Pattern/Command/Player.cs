using UnityEngine;

namespace Pattern.Command
{
    public class Player : MonoBehaviour
    {
        public void Attack()
        {
            Debug.Log("Attack");
        }

        public void AttackCancel()
        {
            Debug.Log("Attack Cancel");
        }

        public void JumpAttack()
        {
            Debug.Log("Jump Attack");
        }
        public void JumpAttackCancel()
        {
            Debug.Log("Jump Attack Cancel");
        }

        public void SkillAttack(string skillName)
        {
            Debug.Log($"Skill Attack {skillName}");
        }

        public void SkillCancel(string skillName)
        {
            Debug.Log($"Skill Attack {skillName} Cancel");
        }
    }
}
