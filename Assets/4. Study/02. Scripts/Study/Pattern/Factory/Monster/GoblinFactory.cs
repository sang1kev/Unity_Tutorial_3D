using System;
using UnityEngine;

namespace Pattern.Factory
{
    public abstract class GoblinFactory : MonsterFactory
    {
        protected override Monster CreateMonster(string type)
        {
            switch (type)
            {
                case "Normal":
                    return new GameObject("Goblin").AddComponent<Goblin>();
                    break;
                case "Warrior":
                    return new GameObject("Goblin Warrior").AddComponent<GoblinWarrior>();
                    break;
                case "Archer":
                    return new GameObject("Goblin Archer").AddComponent<GoblinArcher>();
                    break;
                default:
                    Debug.Log($"Unknown Monster Type : {type}");
                    break;
            }

            return null;
        }
    }

}
