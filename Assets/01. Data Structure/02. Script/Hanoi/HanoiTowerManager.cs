using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HanoiTowerManager : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2 = 4, Lv3 = 5 };
    public HanoiLevel hanoiLevel;

    public GameObject[] torusObj;
    public TowerBar[] bars;

    public static GameObject selTorus;
    public static TowerBar currBar;
    public TextMeshProUGUI textCount;
    public TextMeshProUGUI textWarning;
    public Button hintButton;
    
    public static bool isTorusSel;
    public static int moveCount;

    void Awake()
    {
        hintButton.onClick.AddListener(Hint);
    }

    IEnumerator Start()
    {
        textWarning.text = $"";
        moveCount = 0;
        
        for (int i = 0; i < (int)hanoiLevel; i++)
        {
            GameObject torus = Instantiate(torusObj[i]);

            torus.transform.position = new Vector3 (-3f, 5f, 0);

            bars[0].PushTorus(torus);

            yield return new WaitForSeconds(0.75f);    // 순차 생성
        }
        
        TextCount();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            currBar.barStack.Push(selTorus);

            isTorusSel = false;
            selTorus = null;
        }
    }

    public void TextCount()
    {
        textCount.text = $"Move Count : {moveCount}";
    }

    public IEnumerator TextWarning()
    {
        textWarning.text = $"Wrong Move";

        yield return new WaitForSeconds(1f);

        textWarning.text = $"";
    }

    public void Hint()
    {
        if(bars[0].barStack.Count <= 0 && bars[1].barStack.Count <= 0)
        {
            HanoiHint((int)hanoiLevel, 0, 1, 2 );
        }
    }

    public void HanoiHint(int n, int from, int temp, int goal)
    {
        if (n == 0)
            return;

        if (n == 1)
            Debug.Log($"{n}번 도넛을 {from}에서 {goal}로 이동");
        else
        {
            HanoiHint(n - 1, from, goal, temp);
            Debug.Log($"{n}번 도넛을 {from}에서 {goal}로 이동");

            HanoiHint(n - 1, temp, from, goal);
        }
    }
}
