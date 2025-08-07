using UnityEngine;
using Pattern.Command;

public class SkillCommand : ICommand
{
    private Player player;
    private string skill;

    public SkillCommand (Player player, string skill)
    {
        this.player = player;
        this.skill = skill;
    }

    public void Execute ()
    {
        player.SkillAttack(skill);
    }

    public void Undo()
    {
        player.SkillCancel(skill);
    }
}
