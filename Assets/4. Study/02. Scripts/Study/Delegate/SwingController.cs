using System;
using System.Collections;
using UnityEngine;

public class SwingController : MonoBehaviour
{
    private Animator anim;

    public Action onStartSwing;
    public Action onEndSwing;
    
    private bool isSwing;
    
    void Start()
    {
        anim = GetComponent<Animator>();

        onStartSwing += SwingStart;
        onEndSwing += SwingEnd;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isSwing)
            {
                StartCoroutine(SwingRoutine(onStartSwing, onEndSwing));
            }
        }
    }

    public IEnumerator SwingRoutine(Action aciton1, Action action2)
    {
        isSwing = true;
        anim.SetTrigger("Swing");
        aciton1?.Invoke();

        yield return null;
        Debug.Log(anim.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        float animTime = anim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        
        // float animTime2 = anim.GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSeconds(animTime);
        action2?.Invoke();
        isSwing = false;
    }

    private void SwingStart()
    {
        Debug.Log("스윙 시작");
    }

    private void SwingEnd()
    {
        Debug.Log("스윙 종료");
    }
}