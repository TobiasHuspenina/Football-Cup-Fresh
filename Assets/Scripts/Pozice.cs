using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pozice : MonoBehaviour
{
    private Vector3 Position;

    void Start()
    {
        Position = transform.position;
    }

    public void ResetToDefaultPosition()
    {
        transform.position = Position;
    }

    public enum Direction
    {
        Left,
        Right
    }

    public Direction currentDirection = Direction.Right; // Výchozí směr

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal"); // Předpokládá, že používáte standardní osu Horizontal

        if (moveInput > 0)
        {
            currentDirection = Direction.Right;
        }
        else if (moveInput < 0)
        {
            currentDirection = Direction.Left;
        }
    }
}
