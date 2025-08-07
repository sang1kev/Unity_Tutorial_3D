using System;
using UnityEngine;

namespace Pattern.Factory
{
    public abstract class OrcFactory : MonsterFactory
    {
        protected override Monster CreateMonster(string type)
        {
            switch (type)
            {
                case "Normal":
                    return new GameObject("Orc").AddComponent<Orc>();
                    break;
                case "Warrior":
                    return new GameObject("Orc Warrior").AddComponent<OrcWarrior>();
                    break;
                case "Archer":
                    return new GameObject("Orc Archer").AddComponent<OrcArcher>();
                    break;
                default:
                    Debug.Log($"Unknown Monster Type : {type}");
                    break;
            }

            return null;
        }
    }

}
