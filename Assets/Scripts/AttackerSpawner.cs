using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker[] attackerPrefabArray;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 7f;
    Vector3 offset = new Vector3(0, 0.4f, 0);
    bool spawn = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {

            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }
    public void StopSpawning()
    {
        spawn = false;
    }
    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }
   
    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate
           (myAttacker, transform.position + offset, transform.rotation)
           as Attacker;
        newAttacker.transform.parent = transform;
    }
}
