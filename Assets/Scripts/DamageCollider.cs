using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<LivesDisplay>().TakeLife();
        Destroy(collision);
        FindObjectOfType<LevelController>().AttackerKilled();
    }
}
