using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamX : MonoBehaviour {
	private float length_x, length_y, startpos_x, startpos_y;
	public GameObject cam;
	public float scrollSpeed_x;
	public float scrollSpeed_y;

	void Start() {
		startpos_x = transform.position.x;
		startpos_y = transform.position.y;
		length_x = GetComponent<SpriteRenderer>().bounds.size.x;
		length_y = GetComponent<SpriteRenderer>().bounds.size.y;
	}

	void LateUpdate() {
		float temp_x = (cam.transform.position.x * (1-scrollSpeed_x));
		float distance_x = (cam.transform.position.x * scrollSpeed_x);
		float temp_y = (cam.transform.position.y * (1-scrollSpeed_y));
		float distance_y = (cam.transform.position.y * scrollSpeed_y);
		transform.position = new Vector3(startpos_x + distance_x, startpos_y + distance_y, transform.position.z);
	}
}
