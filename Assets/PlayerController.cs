using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public GameObject collision_particle;
	bool leftHold = false;
	bool rightHold = false;
	public static bool hitBoxFlag1 = false;
	public static bool hitBoxFlag2 = false;
	public GameObject pauseMenu;
	public static bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
		TimerController.instance.BeginTimer();
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		// if(GameOver.isGameOver)
		// 	return;
		if(hitBoxFlag1) {
			// then 2 is forward 
		} else if(hitBoxFlag2) {
			// then 1 is forward
		}
		int rotationCap = 200;
		if(GetComponent<Rigidbody2D>().angularVelocity > rotationCap)
			GetComponent<Rigidbody2D>().angularVelocity = rotationCap;
		if(GetComponent<Rigidbody2D>().angularVelocity < -rotationCap)
			GetComponent<Rigidbody2D>().angularVelocity = -rotationCap;
		if (Input.GetKeyDown(KeyCode.R)) {
			// GetComponent< 
			Time.timeScale = 1;
			GameOver.isGameOver = false;
			SceneManager.LoadScene("SampleScene");
		}
		if(!GameOver.isGameOver) {
			if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
				// GetComponent<
				if(Time.timeScale == 0) {
					Time.timeScale = 1;
					pauseMenu.SetActive(false);
					TimerController.instance.ResumeTimer();
				} else {
					Time.timeScale = 0;
					pauseMenu.SetActive(true);
					TimerController.instance.PauseTimer();
				}
			}
			if(!isPaused) {
				if (Input.GetKeyDown("left")) {
					GetComponent<Rigidbody2D>().angularVelocity = 0;
					leftHold = true;
				}
				if (Input.GetKeyDown("right")) {
					GetComponent<Rigidbody2D>().angularVelocity = 0;
					rightHold = true;
				}
				if(leftHold)
					rotatePlayer("left");
				if(rightHold)
					rotatePlayer("right");
				if (Input.GetKeyUp("left"))
					leftHold = false;
				if (Input.GetKeyUp("right"))
					rightHold = false;
				if (Input.GetKeyDown("space")) {
					GetComponent<Rigidbody2D>().AddForce(transform.up*100);
					SoundManager.PlayJump();
				}
				hitBoxFlag1 = false;
				hitBoxFlag2 = false;
			}
		}
			// transform.Translate(transform.up);
			// GetComponent<Rigidbody2D>().velocity += new Vector2((-Mathf.Cos(transform.eulerAngles.z*180/Mathf.PI)),(Mathf.Sin(transform.eulerAngles.z*180/Mathf.PI)));
			// GetComponent<Rigidbody2D>().velocity += new Vector2((-Mathf.Cos(transform.eulerAngles.z*180/Mathf.PI)),(Mathf.Sin(transform.eulerAngles.z*180/Mathf.PI)));
		// Debug.Log(transform.eulerAngles.z + " " + (-Mathf.Cos(transform.eulerAngles.z*180/Mathf.PI)) + " " + (Mathf.Sin(transform.eulerAngles.z*180/Mathf.PI)));
		// Debug.Log("Angular Velocity : " + GetComponent<Rigidbody2D>().angularVelocity);
		// Debug.Log("Rotation Angle : " + transform.rotation.eulerAngles);
		// Debug.Log("Angle : " + transform.eulerAngles.z);
    }

	void rotatePlayer(string direction) {
		// if(Time.timeScale != 0) {
			GetComponent<Rigidbody2D>().angularVelocity = 0;
			int rotationRate = 1;
			// int cap = 200;
			if(direction.ToLower().Equals("left")) {
				transform.Rotate(Vector3.forward*rotationRate);
				// GetComponent<Rigidbody2D>().angularVelocity += rotationRate;
			} else {
				transform.Rotate(Vector3.forward*-rotationRate);
				// GetComponent<Rigidbody2D>().angularVelocity -= rotationRate;
			}

		// }
	}

	void OnCollisionEnter2D(Collision2D collision) {
		SoundManager.PlayBounce();

		foreach (ContactPoint2D contact in collision.contacts)
        {
        	Debug.DrawRay(contact.point, contact.normal, Color.white);
			GameObject temp_collision_particle = Instantiate(collision_particle, new Vector3(contact.point.x, contact.point.y, 0), Quaternion.identity);
			Destroy(temp_collision_particle, .75f);
        }
		// collision_particle.GetComponent<ParticleSystem>().enableEmission = true;
		// StartCoroutine(stopCollisionParticle());
		// Debug.Log(gameObject.name);
		// GetComponent<Rigidbody2D>().velocity += new Vector2(1,1);
		// GetComponent<Rigidbody2D>().AddForce(transform.up*100 * (hitBoxFlag1 ? 1 : -1));
	}

	IEnumerator stopCollisionParticle() {
		yield return new WaitForSeconds(1F);
		collision_particle.GetComponent<ParticleSystem>().enableEmission = false;
	}
}
