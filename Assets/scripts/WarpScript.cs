using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpScript : MonoBehaviour
{
	public GameObject warpA;
	public GameObject warpB;

	private float timeRemaining = 0;
	private bool canTeleport = true;

    void Update()
    {
		if(!canTeleport) {
			if(timeRemaining <= 0) {
				canTeleport = true;
			} else {
				timeRemaining -= Time.deltaTime;
			}
		}
    }

	void StartTimer() {
		timeRemaining = 1;
		canTeleport = false;
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.gameObject.name.Equals("Player") && canTeleport) {
			StartTimer();
			var posA = warpA.transform.position;
			var posB = warpB.transform.position;
			var posC = collision.transform.position;
			if(Vector3.Distance(posA, posC) < Vector3.Distance(posB, posC)) {
				collision.transform.position = posB;
			} else {
				collision.transform.position = posA;
			}
		}
	}
}
