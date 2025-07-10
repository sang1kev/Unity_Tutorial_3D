using System.Collections;
using TMPro;
using UnityEngine;

public class HanoiTowerManager : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2 = 4, Lv3 = 5 };
    public HanoiLevel hanoiLevel;

    public GameObject[] torusObj;
    public TowerBar[] bars;

    public static GameObject selTorus;
    public static TowerBar currBar;
    public  TextMeshProUGUI textCount;
    public  TextMeshProUGUI textWarning;
    
    public static bool isTorusSel;
    public static int moveCount;

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
}
