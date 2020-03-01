using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GoToMainMenu() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("main_menu");
	}
    
    public void GoToGameScene() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("game_scene");
	}
	
	public void GoToWinScene() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("win_scene");
	}
	
	public void GoToLoseScene() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("lose_scene");
	}
}
