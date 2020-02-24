using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            Move("left");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move("right");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Move("up");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Move("down");
        }
    }

    private void Move(string direction) 
    {
        switch (direction) 
        {
            case "up":
                SetMove(new Vector2Int(0, 1), GridConstructor.PlayerPosition);
                break;
            case "down":
                SetMove(new Vector2Int(0, -1), GridConstructor.PlayerPosition);
                break;
            case "left":
                SetMove(new Vector2Int(-1, 0), GridConstructor.PlayerPosition);
                break;
            case "right":
                SetMove(new Vector2Int(1, 0), GridConstructor.PlayerPosition);
                break;
        }
    }

    private void SetMove(Vector2Int nextPos, Vector2Int currentPos) 
    {
        if (currentPos.x + nextPos.x >= 0 && currentPos.x + nextPos.x < GridConstructor.accessWidth && currentPos.y + nextPos.y >= 0 && currentPos.y + nextPos.y < GridConstructor.accessHeight) 
        {
            if (GridConstructor.Matrix[nextPos.x + currentPos.x, nextPos.y + currentPos.y] == (int)GridConstructor.Cells.Free)
            {
                if (GridConstructor.Matrix[currentPos.x, currentPos.y] == (int)GridConstructor.Cells.PlayerOnPoint)
                {
                    GridConstructor.Matrix[currentPos.x, currentPos.y] = (int)GridConstructor.Cells.Point;
                }
                else 
                {
                    GridConstructor.Matrix[currentPos.x, currentPos.y] = (int)GridConstructor.Cells.Free;
                }
                GridConstructor.Matrix[nextPos.x + currentPos.x, nextPos.y + currentPos.y] = (int)GridConstructor.Cells.Player;
                GridConstructor.PlayerPosition = currentPos + nextPos;
            }
            else if (GridConstructor.Matrix[nextPos.x + currentPos.x, nextPos.y + currentPos.y] == (int)GridConstructor.Cells.OnPoint && GridConstructor.Matrix[nextPos.x + nextPos.x * 1 + currentPos.x, nextPos.y + nextPos.y * 1 + currentPos.y] != (int)GridConstructor.Cells.Wall)
            {
                GridConstructor.Matrix[currentPos.x, currentPos.y] = (int)GridConstructor.Cells.Free;
                GridConstructor.Matrix[nextPos.x + currentPos.x, nextPos.y + currentPos.y] = (int) GridConstructor.Cells.PlayerOnPoint;
                GridConstructor.PlayerPosition = currentPos + nextPos;
                MoveItem(nextPos, nextPos + currentPos);
            }
            else if (GridConstructor.Matrix[nextPos.x + currentPos.x, nextPos.y + currentPos.y] == (int)GridConstructor.Cells.Item && GridConstructor.Matrix[nextPos.x + nextPos.x * 1 + currentPos.x, nextPos.y + nextPos.y * 1 + currentPos.y] != (int) GridConstructor.Cells.Wall)
            {
                MoveItem(nextPos, nextPos + currentPos);
                SetMove(nextPos, currentPos);
            }
            if (GridConstructor.Matrix[nextPos.x + currentPos.x, nextPos.y + currentPos.y] == (int)GridConstructor.Cells.Point)
            {
                if (GridConstructor.Matrix[currentPos.x, currentPos.y] == (int)GridConstructor.Cells.PlayerOnPoint)
                {
                    GridConstructor.Matrix[currentPos.x, currentPos.y] = (int)GridConstructor.Cells.Point;
                }
                else
                {
                    GridConstructor.Matrix[currentPos.x, currentPos.y] = (int)GridConstructor.Cells.Free;
                }
                GridConstructor.Matrix[nextPos.x + currentPos.x, nextPos.y + currentPos.y] = (int)GridConstructor.Cells.PlayerOnPoint;
                GridConstructor.PlayerPosition = currentPos + nextPos;
            }
        }
    }

    private void MoveItem(Vector2Int nextPos, Vector2Int currentPos) 
    {
        if (currentPos.x + nextPos.x >= 0 && currentPos.x + nextPos.x < GridConstructor.accessWidth && currentPos.y + nextPos.y >= 0 && currentPos.y + nextPos.y < GridConstructor.accessHeight) 
        {
            if (GridConstructor.Matrix[nextPos.x + currentPos.x, nextPos.y + currentPos.y] == (int)GridConstructor.Cells.Free)
            {
                if (GridConstructor.Matrix[currentPos.x, currentPos.y] != (int)GridConstructor.Cells.PlayerOnPoint) 
                {
                    GridConstructor.Matrix[currentPos.x, currentPos.y] = (int)GridConstructor.Cells.Free;
                }
                GridConstructor.Matrix[nextPos.x + currentPos.x, nextPos.y + currentPos.y] = (int)GridConstructor.Cells.Item;
            }
            else if (GridConstructor.Matrix[nextPos.x + currentPos.x, nextPos.y + currentPos.y] == (int) GridConstructor.Cells.Point)
            {
                GridConstructor.Matrix[currentPos.x, currentPos.y] = (int)GridConstructor.Cells.Free;
                GridConstructor.Matrix[nextPos.x + currentPos.x, nextPos.y + currentPos.y] = (int)GridConstructor.Cells.OnPoint;
            }
        }
    }
}
