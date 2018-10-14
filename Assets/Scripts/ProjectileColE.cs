using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileColE : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ProjectileKiller")
        {
            Destroy(gameObject);
        }
    }
}
