using UnityEngine;

public class HitEvent : MonoBehaviour
{
    public EnemyFSM eFsm;

    public void PlayerHit()
    {
        eFsm.AttackAction();
    }
}
