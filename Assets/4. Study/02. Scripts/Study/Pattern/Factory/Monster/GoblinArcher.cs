using UnityEngine;

namespace Pattern.Factory
{
    public abstract class GoblinArcher : Monster
    {
        void Awake()
        {
            Initialize("GoblinArcher", 10, 3);
        }
    }
}