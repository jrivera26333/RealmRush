using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] Waypoint startWayPoint, endWayPoint;
    List<Waypoint> path = new List<Waypoint>();

    bool isRunning = true;
    Waypoint searchCenter;

    public List<Waypoint> GetPath()
    {
        if(path.Count == 0)
        {
            CalculatePath();
            return path;
        }
        else
            return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
    }

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    private void CreatePath()
    {
        path.Add(endWayPoint);
        Waypoint previous = endWayPoint.exploredFrom;
        while(previous != startWayPoint)
        {
            //Add intermediate waypoints
            path.Add(previous); //This allows us to work backwards
            previous = previous.exploredFrom;
        }

        path.Add(startWayPoint);
        path.Reverse();
        //Add start waypoint
        //Reverse List
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWayPoint);
        while(queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            HaltIfEndFound();
            ExploreNeighbors();
        }
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endWayPoint)
        {
            isRunning = false;
        }

    }

    private void ExploreNeighbors() //Grabs all the surrounding points around the Waypoint
    {
        if (!isRunning) { return; }
        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = searchCenter.GetGridPos() + direction; //Get gridPos is moving by its size which is 10 once its hits that we are settings its point to 1, our direction is 1 based as well

            if(grid.ContainsKey(neighborCoordinates))
            {
                QueueNewNeighbors(neighborCoordinates); //Checks if the Waypoint has been explored
            }
        }
    }

    private void QueueNewNeighbors(Vector2Int neighborCoordinates)
    {
        Waypoint neighbour = grid[neighborCoordinates];

        if(neighbour.isExplored || queue.Contains(neighbour)) //Different positions will recheck some values
        {

        }
        else //If it hasnt been explored change the color and add to Enqueue
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
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
