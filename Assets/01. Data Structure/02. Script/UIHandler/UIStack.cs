using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStack : MonoBehaviour
{
    public Stack<GameObject> uiStack = new Stack<GameObject>();

    public Button[] buttons;
    public GameObject[] popupUIs;

    void Start()
    {
        buttons[0].onClick.AddListener(PopupOn0);
        buttons[1].onClick.AddListener(PopupOn1);
        buttons[2].onClick.AddListener(PopupOn2);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GameObject currUI = uiStack.Pop();
            currUI.SetActive(false);
        }
    }

    private void PopupOn0()
    {
        popupUIs[0].transform.SetAsLastSibling();
        popupUIs[0].SetActive(true);
        uiStack.Push(popupUIs[0]);
    }

    private void PopupOn1()
    {
        popupUIs[1].transform.SetAsLastSibling();
        popupUIs[1].SetActive(true);
        uiStack.Push(popupUIs[1]);
    }

    private void PopupOn2()
    {
        popupUIs[2].transform.SetAsLastSibling();
        popupUIs[2].SetActive(true);
        uiStack.Push(popupUIs[2]);
    }
}
