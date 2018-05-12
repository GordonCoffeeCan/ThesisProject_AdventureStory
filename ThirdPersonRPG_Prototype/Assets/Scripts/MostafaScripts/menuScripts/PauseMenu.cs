using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {

    [SerializeField]
    private bool paused;

    public GameObject pausePanel;

    // Use this for initialization
    void Start () {
        pausePanel = this.transform.GetChild(0).gameObject;
        pausePanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel")) {
            Pause();

        }
	}

    public void Pause() {

        paused = !paused;

        if (paused == true) {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        else {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }

    public void Resume() {
        Pause();
    }

    public void MainMenu() {
        Pause();
        SceneManager.LoadScene("splashScreen");
    }

    public void Restart() {
        Pause();
        int i = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(i);
    }

    public void Quit() {
        Pause();
        Application.Quit();
        //SceneManager.LoadScene(0);
    }
}
