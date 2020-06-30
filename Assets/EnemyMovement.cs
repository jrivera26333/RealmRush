using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        Debug.Log("Starting the patrol!");
        foreach (Waypoint wayPoint in path)
        {
            Debug.Log("Visiting block: " + wayPoint.name);
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(1f);
        }

        Debug.Log("Ending Patrol!");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
