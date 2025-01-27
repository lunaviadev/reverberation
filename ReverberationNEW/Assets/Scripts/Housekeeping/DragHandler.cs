using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPosition; // Reset position if not dropped on a valid target
        //If the command is dropped into a command square for the clone, add logic here
    }

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

