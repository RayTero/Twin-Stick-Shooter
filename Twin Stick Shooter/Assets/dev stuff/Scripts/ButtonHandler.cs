using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   

public class ButtonHandler : MonoBehaviour {

    [SerializeField]
    private string SceneToBeLoaded;
    [SerializeField]
    private Animator CameraAnimator;
    [SerializeField]
    private GameObject PauseScreen;

	// Use this for initialization
	void Start () {
        CameraAnimator.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
	}

    public void StartGame()
    {
        SceneManager.LoadScene("Jelle Player");       
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartScreen (proto)");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Credits()
    {
        CameraAnimator.SetBool("GoToCredits", true);
        CameraAnimator.SetBool("GoToMenu", false);
    }
    public void Menu()
    {
        CameraAnimator.SetBool("GoToCredits", false);
        CameraAnimator.SetBool("GoToMenu", true);
    }
    public void Resume()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
