using System;
using UnityEngine;

public class StudyFunc3 : MonoBehaviour
{
    public int hp = 100;

    public Func<int> GetHp;
    
    public Func<float, float> GetRemainHp;

    public Func<string> GetAction;

    void Start()
    {
        // 현재 체력
        GetHp = () => hp;
        
        // 데미지 받은 이후의 체력
        GetRemainHp = (dmg) => hp - dmg;

        GetAction = () =>
        {
            if (GetHp() > 50)
                return "돌진";
            else if (GetHp() > 20)
                return "공격";
            else if (GetHp() > 0)
                return "도망";
            else
                return "죽음";
        };
    }
}