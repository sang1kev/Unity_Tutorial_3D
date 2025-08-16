using UnityEngine;

public interface ICommand
{
    void Execute(); // Redo

    void Cancel(); // Undo
}