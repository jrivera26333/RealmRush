using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 10;
    [SerializeField] ParticleSystem projectileParticle;

    public Waypoint baseWayPoint; //What the tower is standing on

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();

        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
            Shoot(false);
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>(); //Grabs all the enemies
        if(sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform; //Grabbing the first enemy which we will assume its the first

        foreach(EnemyDamage testEnemy in sceneEnemies) //We are checking amongst other enemies
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);
        var distToB = Vector3.Distance(transform.position, transformB.position);

        if (distToA < distToB)
            return transformA;
        return transformB;
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
            Shoot(false);
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
