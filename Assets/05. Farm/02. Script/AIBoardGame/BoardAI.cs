using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;

public class BoardAI
{
    public static float Negamax(AIBoard board, int maxDepth, int currentDepth, ref MoveAI bestMove)
    {
        if (board.IsGameOver() || currentDepth == maxDepth)
        {
            return board.Evaluate(board.GetCurrentPlayer());
        }

        float bestScore = Mathf.NegativeInfinity;

        foreach (MoveAI m in board.GetMoves())
        {
            AIBoard b = board.MakeMove(m);
            MoveAI currentMove = null;

            float recursedScore = Negamax(b, maxDepth, currentDepth + 1, ref currentMove);
            float currentScore = -recursedScore;

            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bestMove = m;
            }
        }
        return bestScore;
    }
}
