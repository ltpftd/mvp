using Assets.Enums;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    public List<EnemySpawner> enemySpawners;

    public void OnTriggerEnter(Collider collider)
    {
        enemySpawners = FindObjectsOfType<EnemySpawner>().ToList();

        if (collider.gameObject.tag == ObjectTags.Player.ToString())
        {
            foreach (var enemySpawner in enemySpawners)
            {
                enemySpawner.SpawnEnemenies();
            }
        }
    }
}
