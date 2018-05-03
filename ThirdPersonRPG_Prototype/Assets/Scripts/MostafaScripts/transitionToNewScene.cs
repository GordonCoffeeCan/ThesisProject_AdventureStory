using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class transitionToNewScene : MonoBehaviour {
    public GameObject endPanel;
    

	// Use this for initialization
	void Start () {
        endPanel = GameObject.Find("EndPanel");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerEnter(Collider col) {
        if (col.transform.tag == "Player") {
            endPanel.GetComponent<Image>().color = Color.black;
            endPanel.GetComponent<UICrossFade>().m_Fading = !endPanel.GetComponentInChildren<UICrossFade>().m_Fading;
            Invoke("TransitionScene", 2f);
        }
    }

    void TransitionScene() {
        int i = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(i + 1);
    }
}
