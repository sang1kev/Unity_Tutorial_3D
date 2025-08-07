using UnityEngine;
using Pattern.Command;

public class JumpCommand : ICommand
{
    private Player player;

    public JumpCommand(Player player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.JumpAttack();
    }

    public void Undo()
    {
        player.JumpAttackCancel();
    }
}
