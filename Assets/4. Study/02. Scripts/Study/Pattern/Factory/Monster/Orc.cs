using UnityEngine;

namespace Pattern.Factory
{
    public abstract class Orc : Monster
    {
        void Awake()
        {
            Initialize("Orc", 20, 8);
        }
    }
}