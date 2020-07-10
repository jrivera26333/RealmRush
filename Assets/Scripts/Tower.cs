using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        objectToPan.LookAt(targetEnemy);
    }

    IEnumerator StartFiring()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(bullet);
    }
}
