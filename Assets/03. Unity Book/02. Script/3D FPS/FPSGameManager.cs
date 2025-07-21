using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class FPSGameManager : Singleton<FPSGameManager>
{
    public enum GameState { READY, RUN, GAMEOVER }
    public GameState gState;

    public GameObject gameLabel;
    private TextMeshProUGUI gameText;

    private FPSPlayerMove player;

    void Start()
    {
        gState = GameState.READY;
        gameText = gameLabel.GetComponent<TextMeshProUGUI>();

        gameText.text = "Ready...";
        gameText.color = new Color32(255, 185, 0, 255);

        player = GameObject.Find("Player").GetComponent<FPSPlayerMove>();

        StartCoroutine(ReadyToStart());
    }

    void Update()
    {
        if (player.hp <= 0)
        {
            gameLabel.SetActive(true);
            gameText.text = "Game Over";
            gameText.color = new Color32(255, 0, 0, 255);

            gState = GameState.GAMEOVER;
        }
    }

    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2f);
        gameText.text = "Go!";

        yield return new WaitForSeconds(0.5f);
        gameLabel.SetActive(false);
        gState = GameState.RUN;
    }
}
