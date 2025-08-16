using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AIBoardCtrl : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab_L;
    [SerializeField] private GameObject cellPrefab_D;
    [SerializeField] private Transform boardPanel;
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private Button restartButton;

    private AIBoardTTT gameBoard;
    private AICell[,] cells = new AICell[3, 3];
    private int AI_PLAYER = 2;

    public static Action startAction;

    void Start()
    {
        restartButton.onClick.AddListener(StartGame);

        startAction += StartGame;
    }

    void StartGame()
    {
        gameBoard = new AIBoardTTT();
        statusText.text = "Player X Turn";
        restartButton.gameObject.SetActive(false);

        foreach (Transform child in boardPanel)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject cellGO;
                if (i + 2 == j || i == j || j + 2 == i)
                {
                    cellGO = Instantiate(cellPrefab_L, boardPanel);
                }
                else
                {
                    cellGO = Instantiate(cellPrefab_D, boardPanel);
                }

                AICell cell = cellGO.GetComponent<AICell>();
                cell.SetUp(j, i, OnCellClicked);
                cells[i, j] = cell;
            }
        }
        UpdateBoardVisuals();
    }

    void OnCellClicked(int x, int y)
    {
        if (gameBoard.GetCurrentPlayer() != 1 || gameBoard.IsGameOver() || gameBoard.GetCell(y, x) != 0)
        {
            return;
        }

        MoveTicTac move = new MoveTicTac(x, y, gameBoard.GetCurrentPlayer());
        gameBoard = (AIBoardTTT)gameBoard.MakeMove(move);

        UpdateBoardVisuals();

        if (CheckForGameOver()) return;

        StartCoroutine(AITurn());
    }

    IEnumerator AITurn()
    {
        statusText.text = "Computer is thinking...";

        yield return new WaitForSeconds(0.5f);

        MoveAI bestMove = null;
        BoardAI.Negamax(gameBoard, 9, 0, ref bestMove);

        if (bestMove != null)
        {
            gameBoard = (AIBoardTTT)gameBoard.MakeMove(bestMove);
        }

        UpdateBoardVisuals();
        CheckForGameOver();
    }

    void UpdateBoardVisuals()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                string symbol = "";
                if (gameBoard.GetCell(i, j) == 1) symbol = "X";
                else if (gameBoard.GetCell(i, j) == 2) symbol = "O";
                cells[i, j].SetText(symbol);
            }
        }
    }

    bool CheckForGameOver()
    {
        int winner = gameBoard.CheckWinner();
        if (winner == 0)
        {
            string nextPlayer = gameBoard.GetCurrentPlayer() == 1 ? "Player X" : "Computer O";
            statusText.text = $"{nextPlayer} Turn";
            return false;
        }

        if (winner == 3) statusText.text = "Draw!";
        else if (winner == 1) statusText.text = "Player X Wins!";
        else statusText.text = "Computer O Wins!";

        restartButton.gameObject.SetActive(true);
        return true;
    }
}
