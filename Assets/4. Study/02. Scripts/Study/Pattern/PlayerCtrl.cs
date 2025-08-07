using System.Collections.Generic;
using UnityEngine;

namespace Pattern.Command
{
    public class PlayerCtrl : MonoBehaviour
    {
        public Player player;

        private ICommand attackCommand, jumpCommand, skillCommand;

        private Queue<ICommand> commandQueue = new Queue<ICommand>();
        private Stack<ICommand> executeCommand = new Stack<ICommand>();

        void Awake()
        {
            attackCommand = new AttackCommand(player);
            jumpCommand = new JumpCommand(player);
            skillCommand = new SkillCommand(player, "Ice Bolt");
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                attackCommand.Execute();
                executeCommand.Push(attackCommand);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                jumpCommand.Execute();
                executeCommand.Push(jumpCommand);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                skillCommand.Execute();
                executeCommand.Push(skillCommand);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                commandQueue.Enqueue(attackCommand);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                commandQueue.Enqueue(jumpCommand);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                commandQueue.Enqueue(skillCommand);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("턴 종료 및 공격 실행");

                while (commandQueue.Count > 0)
                {
                    ICommand command = commandQueue.Dequeue();
                    command.Execute();
                    executeCommand.Push(command);
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (executeCommand.Count > 0)
                {
                    ICommand lastCommand = executeCommand.Pop();
                    Debug.Log($"Command Undo : {lastCommand.GetType().Name}");

                    lastCommand.Undo();
                }
                else
                {
                    Debug.Log("No Command to Undo");
                }
            }
        }
    }
}
