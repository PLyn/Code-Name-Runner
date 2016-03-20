using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadNextLevel(string SceneName){
        SceneManager.LoadScene(SceneName);
	}

	public void QuitRequest(){
		Application.Quit();
	}

}
