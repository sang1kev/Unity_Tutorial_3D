using Pattern.Command;
using UnityEngine;

public class SkillCommand : ICommand
{
    private Player player;
    private string skillName;
    
    public SkillCommand(Player player, string skillName)
    {
        this.player = player;
        this.skillName = skillName;
    }
    
    public void Execute()
    {
        player.UseSkill(skillName);
    }

    public void Cancel()
    {
        player.UseSkillCancel(skillName);
    }
}