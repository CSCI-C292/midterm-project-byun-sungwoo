using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerBounce1, playerBounce2, playerBounce3, jump;
    static AudioSource audioSrc;
	static int cap;
	static int prev;

    void Start()
    {
		cap = 3;
		prev = Random.Range(0, cap);
		playerBounce1 = Resources.Load<AudioClip>("tech-ping-C");
		playerBounce2 = Resources.Load<AudioClip>("tech-ping-E");
		playerBounce3 = Resources.Load<AudioClip>("tech-ping-G");
		jump = Resources.Load<AudioClip>("jump");
        audioSrc = GetComponent<AudioSource>();
    }

	public static void PlayJump() {
		audioSrc.PlayOneShot(playerBounce1, 0.1F);
	}

	public static void PlayBounce() {
		// audioSrc.PlayOneShot(playerBounce3, 0.1F);
		// int rand;
		// do {
		// 	rand = Random.Range(0, cap);
		// } while(rand == prev);
		
		float volume = 0.5F;
		audioSrc.PlayOneShot(playerBounce1, volume);
		// switch(rand) {
		// case 1:		audioSrc.PlayOneShot(playerBounce1, volume); break;
		// case 2:		audioSrc.PlayOneShot(playerBounce2, volume); break;
		// default:	audioSrc.PlayOneShot(playerBounce3, volume); break;
		// }
		// prev = rand;
	}
}
