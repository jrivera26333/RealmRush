using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints <= 0)
        {
            KillEnemy();
        }
        print("I'm hit!");
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity); 
        vfx.Play();

        float destroyDelay = vfx.main.duration;
        Destroy(vfx.gameObject, destroyDelay);
        Destroy(gameObject, destroyDelay);
    }

    private void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
    }
}
