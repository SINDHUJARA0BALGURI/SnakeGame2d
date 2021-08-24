using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
   [SerializeField] SnakeTile SnakeTilePrefab;

    private List<SnakeTile> snakePeices;
    public List<SnakeTile> SnakePeices { get { return snakePeices; } }

    public void Start()
    {
        snakePeices = new List<SnakeTile>();
        transform.position = GridManager.Instance.GetRandomTile(5).transform.positioin;
        SnakeTile snakeTile = Instantiate(SnakeTilePrefab, transform.position, Quaternion.identity);
        snakeTile.transform.parent = transform;
    }





}
