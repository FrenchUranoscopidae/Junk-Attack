using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{

    public void SpawnPattern(string patternName)
    {
        GameObject pattern = GameObject.Find(patternName);


        if (pattern == null)
        {
            Debug.LogWarning("Chaîne de charactere non valide");
            Debug.Break();
        }
        else
        {
            EnemyHolder[] holders = pattern.GetComponentsInChildren<EnemyHolder>();

            foreach (EnemyHolder holder in holders)
            {
                Instantiate(holder.enemyPrefab, holder.transform.position, holder.transform.rotation);
            }
        }
    }
}