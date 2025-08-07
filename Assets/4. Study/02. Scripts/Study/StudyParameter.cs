using System.Collections.Generic;
using UnityEngine;

public class StudyParameter : MonoBehaviour
{
    public int number = 1;
    public int number2;

    public GameObject player;
    public GameObject enemy;
    public GameObject item;
    
    public List<GameObject> objs = new List<GameObject>();

    void Start()
    {
        NomalParameter(number);
        ReferenceParameter(ref number);
        OutParameter(10, 10f, out number, out number2);

        // int[] intArray = new int[3] { 10, 20, 30 };
        List<int> intList = new List<int>() { 10, 20, 30 };
        intList.Add(40);
        intList.Add(50);
        
        // ArrayParameter(intArray);
        ArrayParameter(intList);
        
        ParamsParameter(10, 20, 30, 40, 50);
        
        // objs.Add(player);
        // objs.Add(enemy);
        // objs.Add(item);
        
        GameObjectActivate2(false, player, item);
    }
    
    
    // 선택적 매개변수 (Default 매개변수)
    private void DefaultParameter(int num = 3)
    {
        
    }
    
    // 오버로딩 : 매개변수를 다르게해서 다른 기능을 구현하는 방법
    private void OverloadingMethod() { Debug.Log("기능 A"); } 
    
    private void OverloadingMethod(int num) { Debug.Log("기능 B"); }
    
    private void OverloadingMethod(float num) { Debug.Log("기능 C"); }
    
    private void OverloadingMethod(bool isNum) { Debug.Log("기능 D"); }
    
    private void OverloadingMethod(int num1, int num2) { Debug.Log("기능 E"); }
    
    // 매개변수 -> Call by Value
    private void NomalParameter(int num)
    {
       
    }
    
    // 참조 방식의 매개변수 -> Call by Reference / 수정의 개념
    private void ReferenceParameter(ref int num)
    {
        num = 20;
    }

    // 반환의 개념
    // 초기화하지 않아도 사용 가능
    private void OutParameter(int number, float number2, out int num, out int num2)
    {
        num = 30;
        num2 = 50;
    }
    
    // Collection을 매개변수로 넣은 경우
    private void ArrayParameter(List<int> numbers)
    {
        foreach (var n in numbers)
        {
            Debug.Log(n);
        }
    }

    // params를 활용한 매개변수 -> 인자를 직접 넣어서 사용 가능
    private void ParamsParameter(params int[] numbers)
    {
        foreach (var n in numbers)
        {
            Debug.Log(n);
        }
    }
    
    private void GameObjectActivate()
    {
        // player.SetActive(false);
        // enemy.SetActive(false);
        // item.SetActive(false);
        
        foreach (var o in objs)
        {
            o.SetActive(false);
        }
    }

    private void GameObjectActivate2(bool isActive, params GameObject[] objs)
    {
        foreach (var o in objs)
            o.SetActive(isActive);
    }
}