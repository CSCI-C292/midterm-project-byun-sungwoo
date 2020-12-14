using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;
	public Text timerCounter;
	private TimeSpan timePlaying;
	private bool timerGoing = false;
	private float elapsedTime;

	private void Awake() {
		instance = this;
	}

	void Start()
    {
        timerCounter.text = "00:00.000";
    }

	public void BeginTimer() {
		timerGoing = true;
		elapsedTime = 0f;
		PlayerController.isPaused = false;
		StartCoroutine(UpdateTimer());
	}

	public void PauseTimer() {
		timerGoing = false;
		PlayerController.isPaused = true;
	}
	public void ResumeTimer() {
		timerGoing = true;
		StartCoroutine(UpdateTimer());
		PlayerController.isPaused = false;
	}

	private IEnumerator UpdateTimer() {
		while(timerGoing) {
			elapsedTime += Time.deltaTime;
			timePlaying = TimeSpan.FromSeconds(elapsedTime);
			string timePlayingStr = timePlaying.ToString("mm':'ss'.'fff");
			timerCounter.text = timePlayingStr;
			yield return null;
		}
	}
}
