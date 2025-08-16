using Pattern.Factory;
using UnityEngine;

public class GoblinFactory : MonsterFactory
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
                Debug.LogError($"Unknown Monster Type : {type}");
                break;
        }

        return null;
    }
}