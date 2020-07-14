using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while(true)
        {
            var newEnemy = Instantiate(enemyPrefab,transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
