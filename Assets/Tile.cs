using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    protected Vector2Int gridPos;

    protected Vector2Int GridPos { get { return gridPos;  } }
    public void MoveToGrid(int x,int y)
    {
        float xf = x;
        float yf = y;
        transform.position = new Vector3(GridManager.Instance.Startpoint.x + (xf / GridManager.Instance.Gridsize),
             GridManager.Instance.Startpoint.y + (yf / GridManager.Instance.Gridsize), transform.position.z);
        gridPos = new Vector2Int(x, y);
    }
}
