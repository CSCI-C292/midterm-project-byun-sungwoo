using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

    public AudioSource[] tracks;
	int cap;
	int prev;
    void Start()
    {
        cap = tracks.Length;
		prev = Random.Range(0, cap);
		playTrack();
    }
    void Update()
    {
        playTrack();
    }

	void playTrack() {
		int rand;
		do {
			rand = Random.Range(0, cap);
		} while(rand == prev);
		
		tracks[rand].Play();
		prev = rand;
	}
}
