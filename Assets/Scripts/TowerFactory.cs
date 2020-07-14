using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit = 5;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint baseWayPoint)
    {
        // TODO change to queue size
        int numTowers = towerQueue.Count;

        if(numTowers < towerLimit)
        {
            InstantiatingNewTower(baseWayPoint);
        }
        else
        {
            MoveExistingTower(baseWayPoint);
        }
    }

    private void InstantiatingNewTower(Waypoint baseWayPoint)
    {
        var newTower = Instantiate(towerPrefab, baseWayPoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform;
        baseWayPoint.isPlaceable = false;

        //Set the baseWayPoins
        newTower.baseWayPoint = baseWayPoint;
        baseWayPoint.isPlaceable = false;

        towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower(Waypoint newBaseWayPoint)
    {
        // Take bottom tower off queue. This will take the earliest tower added.
        var oldTower = towerQueue.Dequeue();
        oldTower.baseWayPoint.isPlaceable = true; //Freeing up the baseWayPoint

        newBaseWayPoint.isPlaceable = false; //Filling up the new one

        oldTower.baseWayPoint = newBaseWayPoint; //We are updating the oldTowerBaseWayPoint to the new position. We need a reference to the baseWayPoint which remember is a script which we can then access its properties without using getcomponent
        oldTower.transform.position = newBaseWayPoint.transform.position; //Then moving the entire tower to the newBaseWayPoint
        towerQueue.Enqueue(oldTower);
        // Set the placeable flags

        //Set the baseWayPoins

        //Put the old tower on top of the queue
    }
}
