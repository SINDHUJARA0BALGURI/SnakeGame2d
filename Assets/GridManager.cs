using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : Singleton<GridManager>
{
    [SerializeField] GrridTile gridtileprefab;
    [SerializeField] Transform playarea;
    [SerializeField] int gridsize = 10;
    public int Gridsize
    {
        get { return gridsize; }
    }
    Vector3 startpoint;
    public Vector3 Startpoint
    {
        get { return startpoint; }
    }
    int width, height;
    Transform[,] grid;

    public void InitializeGrid()
    {
        width = Mathf.RoundToInt(playarea.localScale.x * gridsize);
        height = Mathf.RoundToInt(playarea.localScale.y * gridsize);
        grid = new Transform[width, height];
        startpoint = playarea.GetComponent<Renderer>().bounds.min;
        //Debug.Log(startpoint);
        CreateGridTile();
    }
    private void CreateGridTile()
    {
        if (gridtileprefab == null)
        {
            return;
        }
        for (int i = 0; i < width; i++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 worldpos = GetWorldPosition(i, y);
                GrridTile gridTile = Instantiate(gridtileprefab, worldpos, Quaternion.identity);
                gridTile.name = string.Format("Tile({0},{1})", i, y);
                grid[i, y] = gridTile.transform;
            }
        }
    }
    private Vector3 GetWorldPosition(int a, int b)
    {
        float sp = a;
        float ep = b;
        return new Vector3(startpoint.x + (sp / gridsize), startpoint.y + (ep / gridsize), startpoint.z);
    }
    private void Start()
    {
        InitializeGrid();
    }
}