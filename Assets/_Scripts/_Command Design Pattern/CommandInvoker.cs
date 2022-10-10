using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CommandInvoker : MonoBehaviour
{
    PlayerAction inputAction;
    static Queue<iCommand> commandBuffer;
    static List<iCommand> commandHistory;

    static int counter;
    // Start is called before the first frame update
    void Start()
    {
        commandBuffer = new Queue<iCommand>();
        commandHistory = new List<iCommand>();

        inputAction = PlayerInputController.controller.inputAction;

        inputAction.Editor.Undo.performed += cntxt => UndoCommand();
    }

    public static void AddCommand(iCommand command)
    {
        while(commandHistory.Count > counter)
        {
            commandHistory.RemoveAt(counter);
        }
        commandBuffer.Enqueue(command);
    }
    public void UndoCommand()
    {
        if(commandBuffer.Count<=0)
        {
            if(counter>0)
            {
                counter--;
                commandHistory[counter].Undo();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(commandBuffer.Count > 0)
        {
            iCommand c = commandBuffer.Dequeue();
            c.Execute();

            commandHistory.Add(c);
            counter++;
            Debug.Log("Command History Length" + commandHistory.Count);
        }
    }
}
