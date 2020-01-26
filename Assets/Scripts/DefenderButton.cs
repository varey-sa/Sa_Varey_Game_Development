using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour {

	
	[SerializeField] Defender defenderPrefab; 
	private void OnMouseDrag() {
		var buttons = FindObjectsOfType<DefenderButton>();
		foreach(DefenderButton button in buttons)
		{
			button.GetComponent<SpriteRenderer>().color = new Color32(226, 80, 80, 255);
		}
		GetComponent<SpriteRenderer>().color = Color.white;
		FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
	}
	
}
