using UnityEngine;
using System.Collections;

public class Pickups : MonoBehaviour {

	public int pointsToAdd;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.GetComponent<player> () == null)
			return;

		ScoreManager.AddPoints (pointsToAdd);

		Destroy (gameObject);
	}
}