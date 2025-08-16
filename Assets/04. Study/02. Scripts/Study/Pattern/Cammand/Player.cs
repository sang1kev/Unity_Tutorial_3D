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
        
        public void Jump()
        {
            Debug.Log("Jump");
        }
        
        public void JumpCancel()
        {
            Debug.Log("Jump Cancel");
        }
        
        public void UseSkill(string skillName)
        {
            Debug.Log($"Use Skill : {skillName}");
        }
        
        public void UseSkillCancel(string skillName)
        {
            Debug.Log($"Use Skill Cancel : {skillName}");
        }
    }
}