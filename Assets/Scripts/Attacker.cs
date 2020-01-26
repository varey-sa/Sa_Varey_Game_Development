// using System.Net.Http.Headers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Attacker : MonoBehaviour {

	[Range(0f, 5f)]
	float currenSpeed = 1f;
	public ATTACKER_TYPE _type;

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.left * currenSpeed * Time.deltaTime);
	}

	public void SetMovementSpeed (float speed)
	{
		currenSpeed = speed;
	}

	public float getAttackerHealth()
	{
		return GetComponent<Health>().getHealth();
	}

}
