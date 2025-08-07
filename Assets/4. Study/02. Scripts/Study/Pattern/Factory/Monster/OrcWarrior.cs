using UnityEngine;

namespace Pattern.Factory
{
    public abstract class OrcWarrior : Monster
    {
        void Awake()
        {
            Initialize("Orc", 30, 14);
        }
    }
}