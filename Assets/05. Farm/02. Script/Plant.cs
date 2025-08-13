using System;
using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private enum PlantState { Lv0, Lv1, Lv2, Lv3 }
    private PlantState plantState;

    private DateTime startTime, germinationTime, growthTime, harvestTime; // 레벨이 변하는 시간 설정

    public int plantIndex;

    public bool isHarvest = false;

    void Awake()
    {
        startTime = DateTime.Now;
        germinationTime = startTime.AddSeconds(5);
        growthTime = startTime.AddSeconds(5);
        harvestTime = startTime.AddSeconds(10);
    }

    IEnumerator Start()
    {
        SetState(PlantState.Lv0);

        while (plantState != PlantState.Lv3)
        {
            if (DateTime.Now >= harvestTime)
            {
                SetState(PlantState.Lv3);
                isHarvest = true;
            }
            else if (DateTime.Now >= growthTime)
            {
                SetState(PlantState.Lv2);
            }
            else if (DateTime.Now >= germinationTime)
            {
                SetState(PlantState.Lv1);
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private void SetState(PlantState newState)
    {
        if (plantState != newState || plantState == PlantState.Lv0)
        {
            plantState = newState;

            for (int i = 0; i < 4; i++)
                transform.GetChild(i).gameObject.SetActive(false);

            transform.GetChild((int)plantState).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
