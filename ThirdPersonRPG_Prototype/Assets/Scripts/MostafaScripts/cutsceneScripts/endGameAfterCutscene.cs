using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class endGameAfterCutscene : MonoBehaviour {

    private int currentScene;
    private int nextScene;
    private bool checkEnd;

	// Use this for initialization
	void Start () {
        checkEnd = false;
        currentScene = SceneManager.GetActiveScene().buildIndex;
        nextScene = currentScene + 1;

        double length = this.GetComponent<VideoPlayer>().clip.length;
     
        
        Invoke("changeScene", (float)length);
	}
	
	// Update is called once per frame
	void Update () {

     

	}

    void changeScene() {
      
            SceneManager.LoadScene(nextScene);
        

    }
}
