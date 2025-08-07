using UnityEngine;

//ScriptableObject는 Component로 직접 집어 넣지 못함 Asset(Data) 상태로 존재 runtime 이후에도 데이터가 남음
//MonoBehavior는 runtime 도중 변경 시 종료 후 초기화 
[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public int attackDamage;
    public int attackRange;
}
