using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
	public SceneFader fader;
    
	public void Back()
    {
		fader.FadeTo("MainMenu");
		PlayerController.reset();
    }

	public void Select(string levelName) {
		fader.FadeTo(levelName);
		PlayerController.reset();
	}
}
