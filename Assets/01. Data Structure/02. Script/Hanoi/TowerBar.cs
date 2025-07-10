using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerBar : MonoBehaviour
{
    public enum BarType { LEFT, CENTER, RIGHT }
    public BarType bartype;

    public Stack<GameObject> barStack = new Stack<GameObject>();
    [SerializeField] private HanoiTowerManager hanoiManager;

    void OnMouseDown()
    {
        if (!HanoiTowerManager.isTorusSel)
        {
            HanoiTowerManager.selTorus = PopTorus();
        }
        else
        {
            PushTorus(HanoiTowerManager.selTorus);
        }
    }

    public void PushTorus(GameObject torus)
    {
        if (!CheckHanoiRule(torus))
        {
            StartCoroutine(hanoiManager.TextWarning());
            return;
        }

        HanoiTowerManager.moveCount++;
        HanoiTowerManager.isTorusSel = false;
        HanoiTowerManager.selTorus = null;

        hanoiManager.TextCount();

        torus.transform.position = transform.position + Vector3.up * 2.25f;
        torus.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        torus.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        barStack.Push(torus);
    }

    public GameObject PopTorus()
    {
        if (barStack.Count > 0)
        {
            HanoiTowerManager.currBar = this;
            HanoiTowerManager.isTorusSel = true;
            GameObject torus = barStack.Pop();

            return torus;
        }

        return null;
    }

    private bool CheckHanoiRule(GameObject torus)
    {
        if (barStack.Count > 0 )
        {
            GameObject peekTorus = barStack.Peek();
            
            int pushNum = torus.GetComponent<TorusNumberLabel>().torusNum;
            int peekNum = peekTorus.GetComponent<TorusNumberLabel>().torusNum;

            return pushNum > peekNum ? true : false;    
        }

        return true;
    }
}
