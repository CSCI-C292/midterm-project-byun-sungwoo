using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
	public GameObject message;
	void Start() {
		message.SetActive(false);
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0;
		message.SetActive(true);
    }
}
