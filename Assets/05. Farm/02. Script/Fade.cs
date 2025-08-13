using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Image fadeImage;

    public static Action<float, Color, bool, Action> onFadeAct;

    void Awake()
    {
        fadeImage = GetComponent<Image>();

    }

    void OnEnable()
    {
        onFadeAct += OnFade;
    }

    void OnDisable()
    {
        onFadeAct -= OnFade;
    }

    private void OnFade(float t, Color c, bool isFade, Action fadeEvent = null)
    {
        StartCoroutine(FadeRout(t, c, isFade));
    }

    IEnumerator FadeRout(float t, Color c, bool isFade, Action fadeEvent = null)
    {
        fadeImage.raycastTarget = true;

        float timer = 0f;
        float percent = 0f;
        while (percent < 1f)
        {
            timer += Time.deltaTime;
            percent = timer / t;

            float fadeValue = isFade ? percent : 1 - percent;

            fadeImage.color = new Color(c.r, c.g, c.b, fadeValue);

            yield return null;
        }

        fadeEvent?.Invoke();
        fadeImage.raycastTarget = false;
    }
}
