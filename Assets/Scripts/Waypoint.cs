using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint exploredFrom;
    [SerializeField] Tower towerPrefab;
    public bool isExplored;
    public bool isPlaceable = true;

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

    private void OnMouseOver() //Must have GO on it
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                print(gameObject.name + " tower placement");
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
            }

            else
                print("Cant place here");
        }
    }
}
