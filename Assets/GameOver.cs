using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
	public static bool isGameOver = false;
	public GameObject message;
	void Start() {
		message.SetActive(false);
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
		isGameOver = true;
        Time.timeScale = 0;
		message.SetActive(true);
		TimerController.instance.PauseTimer();
    }
}
