using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawner : MonoBehaviour {
    public CreepPool _pool;
	bool spawn = true;
	[SerializeField] float minSpawnDelay = 1f;
	[SerializeField] float maxSpawnDelay = 5f;
	[SerializeField] Attacker[] attackerPrefab;

	IEnumerator Start()
	{
		while(spawn)
		{
			yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            int rand = Random.Range(0, 2);
            _pool.InstantPoolObjects(
                attackerPrefab[Random.Range(0, 2)].gameObject,
                (ATTACKER_TYPE)rand,
                transform.position);
        }
	}
}
