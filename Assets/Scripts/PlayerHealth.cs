using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playersHealth = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip enemyTakingDamage;

    private void Start()
    {
        healthText.text = playersHealth.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        playersHealth -= healthDecrease;
        healthText.text = playersHealth.ToString();
        GetComponent<AudioSource>().PlayOneShot(enemyTakingDamage);
    }
}
