using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void Execute();
    
    // Patr�n Memento
    //void Undo();
}
