using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    const int gridSize = 10;
    Vector2Int gridPos;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
              Mathf.RoundToInt(transform.position.x / gridSize), //We get a decimal and then round to nearest int to snap
              Mathf.RoundToInt(transform.position.z / gridSize) //We get a decimal and then round to nearest int to snap
            );
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer top = transform.Find("Top").GetComponent<MeshRenderer>();
        top.material.color = color;
    }
}
