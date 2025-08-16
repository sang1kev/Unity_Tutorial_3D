using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;

public abstract class AIBoard
{
    protected int player;

    public AIBoard()
    {
        this.player = 1;
    }

    public virtual MoveAI[] GetMoves()
    {
        return new MoveAI[0];
    }

    public abstract AIBoard MakeMove(MoveAI m);

    public virtual bool IsGameOver()
    {
        return CheckWinner() != 0;
    }

    public virtual int GetCurrentPlayer()
    {
        return player;
    }

    public virtual float Evaluate(int forPlayer)
    {
        int winner = CheckWinner();

        if (winner == 0 || winner == 3)
            return 0;
        if (winner == forPlayer)
            return 1;

        return -1;
    }

    public abstract int CheckWinner();
}
