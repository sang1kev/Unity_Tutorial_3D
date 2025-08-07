using UnityEngine;

namespace Pattern.Factory
{
    public abstract class Goblin : Monster
    {
        void Awake()
        {
            Initialize("Goblin", 10, 3);
        }
    }
}