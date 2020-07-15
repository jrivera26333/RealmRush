using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

    [SerializeField] AudioClip takingDamageSFX;
    [SerializeField] AudioClip death;

    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
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

        Destroy(vfx.gameObject, vfx.main.duration);
        AudioSource.PlayClipAtPoint(death, Camera.main.transform.position);
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
        myAudioSource.PlayOneShot(takingDamageSFX);
    }
}
