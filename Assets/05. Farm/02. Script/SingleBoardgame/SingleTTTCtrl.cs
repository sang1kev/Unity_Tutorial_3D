using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SingleTTTCtrl : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab_L;
    [SerializeField] private GameObject cellPrefab_D;
    [SerializeField] private Transform cellGroup;
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private Button restartButton;

    private Single_TicTacToe gameTTT;
    private Single_Cell[,] cells = new Single_Cell[3, 3];

    public static Action startAction;

    void Awake()
    {
        restartButton.onClick.AddListener(StartGame);
        startAction += StartGame;
    }

    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        gameTTT = new Single_TicTacToe();

        statusText.text = "Player X Turn";
        restartButton.gameObject.SetActive(false);

        for (int i  = 0; i < cellGroup.childCount; i++)
        {
            Destroy(cellGroup.GetChild(i).gameObject);
        }
        for (int i = 0; i < 3;  i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject cellObj;

                if (i + 2 == j || i == j || j + 2 == i)
                {
                    cellObj = Instantiate(cellPrefab_L, cellGroup);
                }
                else
                {
                    cellObj = Instantiate(cellPrefab_D, cellGroup);
                }
                Single_Cell cell = cellObj.GetComponent<Single_Cell>();

                cell.SetButton(j, i, OnCellClicked);
                cells[i, j] = cell;
            }
        }
        UpdateBoardVisual();
    }

    private void OnCellClicked(int x, int y)
    {
        if ( gameTTT.IsGameOver() || gameTTT.board[y, x] != 0)
        {
            return;
        }

        SingleMove move = new SingleMove(x, y, gameTTT.player);
        gameTTT.MakeMove(move);

        UpdateBoardVisual();
        CheckForGameOver();
    }

    private void UpdateBoardVisual()
    {
        for (int i = 0;i < 3;i++)
        {
            for (int j = 0;j < 3;j++)
            {
                string str = "";
                if (gameTTT.board[i, j] == 1)
                {
                    str = "X";
                }
                else if (gameTTT.board[i, j] == 2)
                {
                    str = "O";
                }
                cells[i, j].SetText(str);
            }
        }
    }

    private void CheckForGameOver()
    {
        int winner = gameTTT.CheckWinner();
        if (winner == 0)
        {
            string nextPlayer = gameTTT.player == 1 ? "X" : "O";
            statusText.text = $"Player : {nextPlayer} Turn";
            return;
        }

        if (winner == 3)
            statusText.text = "Draw";
        else
        {
            string result = winner == 1 ? "X" : "O";
            statusText.text = $"Player {result} Win";
        }

        restartButton.gameObject.SetActive(true);
    }

}

