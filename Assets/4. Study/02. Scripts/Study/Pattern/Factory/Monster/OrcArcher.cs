using UnityEngine;

namespace Pattern.Factory
{
    public abstract class OrcArcher : Monster
    {
        void Awake()
        {
            Initialize("Orc", 20, 10);
        }
    }
}