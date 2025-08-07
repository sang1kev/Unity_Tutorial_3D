using UnityEngine;

namespace Pattern.Factory
{
    public abstract class GoblinWarrior : Monster
    {
        void Awake()
        {
            Initialize("GoblinWarrior", 12, 6);
        }
    }
}