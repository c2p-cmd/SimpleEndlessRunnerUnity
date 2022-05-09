using UnityEngine;

public class SceneLoad : MonoBehaviour {
	public void startGame() => UnityEngine.SceneManagement.SceneManager.LoadScene("Game");

	public void loadMenu() => UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
}
