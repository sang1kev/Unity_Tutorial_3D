using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerBar : MonoBehaviour
{
    public enum BarType { LEFT, CENTER, RIGHT }
    public BarType bartype;

    public Stack<GameObject> barStack = new Stack<GameObject>();

    void OnMouseDown()
    {
        if (!HanoiTowerManager.isTorusSel)
        {
            HanoiTowerManager.selTorus = PopTorus();
            HanoiTowerManager.isTorusSel = true;
        }
        else
        {
            PushTorus(HanoiTowerManager.selTorus);
        }
    }

    public void PushTorus(GameObject torus)
    {
        if (!CheckHanoiRule(torus))
            return;

        HanoiTowerManager.isTorusSel = false;

        torus.transform.position = transform.position + Vector3.up * 2.25f;
        torus.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        torus.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        barStack.Push(torus);
    }

    public GameObject PopTorus()
    {
        GameObject torus = barStack.Pop();

        return torus;
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
