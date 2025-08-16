using System.Collections.Generic;
using UnityEngine;

public class Single_TicTacToe : MonoBehaviour
{
    public int[,] board;
    private const int ROWS = 3, COLS = 3;

    public int player;

    public Single_TicTacToe()
    {
        player = 1;
        board = new int[ROWS, COLS];
    }

    public List<SingleMove> GetMoves()
    {
        var moves = new List<SingleMove>();

        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLS; j++)
            {
                if (board[i, j] == 0)
                {
                    moves.Add(new SingleMove(i, j, player));
                }
            }
        }

        return moves;
    }

    public void MakeMove(SingleMove move)
    {
        if (board[move.y, move.x] != 0)
        {
            return;
        }

        board[move.y, move.x] = move.player;

        this.player = move.player == 1 ? 2 : 1;
    }

    public int CheckWinner()
    {
        for (int i = 0; i < ROWS; i++)
        {
            if (board[i, 0] != 0 && board [i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
            {
                return board[i, 0];
            }
        }

        for (int i = 0; i < COLS; i++)
        {
            if (board[0, i] != 0 && board[0, i] == board[1, i] && board[1, i] == board[2, i])
            {
                return board[0, i];
            }
        }

        if (board[0, 0] != 0 && board[0, 0] == board[1,1] && board[1,1] == board[2,2])
        {
            return board[0, 0];
        }

        if (board[0, 2] != 0 && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
        {
            return board[0, 2];
        }

        if (GetMoves().Count == 0)
        {
            return 3;
        }

        return 0;
    }

    public bool IsGameOver()
    {
        return CheckWinner() != 0;
    }
}
