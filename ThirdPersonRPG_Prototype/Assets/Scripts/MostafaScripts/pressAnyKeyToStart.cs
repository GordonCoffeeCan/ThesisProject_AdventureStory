using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pressAnyKeyToStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey) {
            sceneChange();
        }
    }

    public void sceneChange() {
        int i = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(i + 1);

        this.GetComponent<UICrossFade>().m_Fading = true;
    }
}
