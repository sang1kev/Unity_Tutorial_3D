using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] private Transform centerPivot;

    [SerializeField] private Animator[] charAnim;

    [SerializeField] private Button[] turnButtons;
    [SerializeField] private Button selectButton;

    private bool isTurn;

    public int CharIndex { get; private set; }

    void Start()
    {
        turnButtons[0].onClick.AddListener(() => Turn(true));
        turnButtons[1].onClick.AddListener(() => Turn(false));

        selectButton.onClick.AddListener(() => StartCoroutine(Select()));

        CharIndex = 0;
        isTurn = false;
    }

    private void Turn(bool isLeft)
    {
        if (isTurn)
            return;

        isTurn = true;

        float trunValue = isLeft ? 90f : -90f;
        Quaternion targetrot = centerPivot.rotation * Quaternion.Euler(0, trunValue, 0);

        ChangeIndex(isLeft);
        StartCoroutine(TurnRotation(targetrot));
    }

    IEnumerator TurnRotation(Quaternion targetrot)
    {
        while (true)
        {
            yield return null;

            centerPivot.rotation = Quaternion.Slerp(centerPivot.rotation, targetrot, 5f * Time.deltaTime);

            var angle = Quaternion.Angle(centerPivot.rotation, targetrot);
            if (angle <= 0.1f)
            {
                centerPivot.rotation = targetrot;
                isTurn = false;

                yield break;
            }
        }
    }

    private void ChangeIndex(bool isLeft)
    {
        int changeIndex = isLeft ? -1 : 1;

        CharIndex -= changeIndex;

        if (CharIndex < 0)
        {
            CharIndex = 3;
        }
        else if (CharIndex > 3)
        {
            CharIndex = 0;
        }
    }

    IEnumerator Select()
    {
        charAnim[CharIndex].SetTrigger("Select");

        yield return new WaitForSeconds(1f);

        Fade.onFadeAct?.Invoke(1f, Color.black, true, null);

        yield return new WaitForSeconds(1.5f);
    }
}

