using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	[SerializeField] float health = 100f;
	[SerializeField] GameObject deathVFX;
	
	public void DealDamage(float damage)
	{
		health -= damage;
		if(health <= 0)
		{
			TriggerDeathVFX();
			// Debug.Log("death == 0");
			// Destroy(gameObject);
		}
	}

	private void TriggerDeathVFX()
	{
		if(!deathVFX)
		{
			Debug.Log("deathVFX");
			return;
		}
		// AudioSystem.Instance().PauseVoiceByName("wolf_run_0");
		// AudioSystem.Instance().PlayVoice("Explosion");
		Debug.Log("Triger death");
		GameObject deathVFXObject = Instantiate(deathVFX, new Vector3(transform.position.x, transform.position.y, -5), Quaternion.identity); // or , transform.rotation
		Destroy(deathVFXObject, 1f);
	}

	public float getHealth()
	{
		return health;
	}

	public void setHealth(float health)
	{
		this.health = health;
	}
}