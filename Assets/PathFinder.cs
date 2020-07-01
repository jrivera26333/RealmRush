using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint startWayPoint, endWayPoint;

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        ExploreNeighbors();
    }

    private void ExploreNeighbors()
    {
        foreach(Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = startWayPoint.GetGridPos() + direction;
            print("Exploring " + explorationCoordinates);

            try
            {
                grid[explorationCoordinates].SetTopColor(Color.magenta);
            }
            catch
            {

            }
        }
    }

    private void ColorStartAndEnd()
    {
        startWayPoint.SetTopColor(Color.cyan);
        endWayPoint.SetTopColor(Color.blue);
    }

    private void LoadBlocks()
    {
        Waypoint[] wayPoints = FindObjectsOfType<Waypoint>();

        foreach(Waypoint waypoint in wayPoints)
        {
            var gridPos = waypoint.GetGridPos();

            if (grid.ContainsKey(gridPos))
                Debug.LogWarning("Overlapping block!" + waypoint);
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }
}
