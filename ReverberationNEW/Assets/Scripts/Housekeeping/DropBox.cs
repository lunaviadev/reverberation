using System.Collections.Generic;
using System;
using UnityEngine;
using static DropBox;
using Unity.VisualScripting;

public class DropBox : MonoBehaviour
{
    private Command assignedCommand;
    // drag and drop mechanics
    public enum MovementCommands
    {
        MoveUp,
        MoveRight,
        MoveLeft,
        MoveUpRight,
        MoveUpLeft,
        Wait,
    }

    public class Entity
    {
        public float X { get; set; }
        public float Y { get; set; }

        public void Move(MovementCommands command)
        {
            switch (command)
            {
                case MovementCommands.MoveUp:
                    Y += 1;
                    break;
                case MovementCommands.MoveLeft:
                    X -= 1;
                    break;
                case MovementCommands.MoveRight:
                    X += 1;
                    break;
                case MovementCommands.MoveUpRight:
                    X += 1;
                    Y += 1;
                    break;
                case MovementCommands.MoveUpLeft:
                    X -= 1;
                    Y += 1;
                    break;
                default:
                    return;
            }
        }
    }

    //private void OnDragDrop(object sender, IDragAndDropHandler e)
    //{
      //  var command = (MovementCommands)e.Data.GetData(typeof(MovementCommands));
        //Entity.Move(command);
    //}   WHY WONT YOU WORKKKKKKKK


    public class MovementBlock
    {
        public MovementCommands BlockType { get; private set; }

        public MovementBlock(MovementCommands blockType)
        {
            BlockType = blockType;
        }


    }

    public class MovementField
    {
        private List<MovementBlock> _movementBlocks = new List<MovementBlock>();

        public void AddBlock(MovementBlock block)
        {
            _movementBlocks.Add(block);
        }

        public void ExecuteMovementActions()
        {
            foreach (var block in _movementBlocks)
            {
                switch (block.BlockType)
                {
                    case MovementCommands.MoveUp:
                        Console.WriteLine("Moving Up");
                        break;
                    case MovementCommands.MoveLeft:
                        Console.WriteLine("Moving Left");
                        break;
                    case MovementCommands.MoveRight:
                        Console.WriteLine("Moving Right");
                        break;
                    case MovementCommands.MoveUpLeft:
                        Console.WriteLine("Moving Diagonal Up and Left");
                        break;
                    case MovementCommands.MoveUpRight:
                        Console.WriteLine("Moving Diagonal Up and Right");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }



}



