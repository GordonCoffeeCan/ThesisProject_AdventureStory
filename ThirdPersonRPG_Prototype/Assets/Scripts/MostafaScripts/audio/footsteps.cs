using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour {

    private AudioSource audioPlayer;

    [SerializeField]
    private AudioClip step;

    [SerializeField]
    private AudioClip land;



    // Use this for initialization
    void Start () {
        audioPlayer = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Step() {

        audioPlayer.clip = step;
        audioPlayer.volume = Random.Range(0.8f, 1);
        audioPlayer.pitch = Random.Range(0.8f, 1);
        audioPlayer.Play();
    }

    private void Land() {

        audioPlayer.clip = land;
        audioPlayer.volume = Random.Range(0.8f, 1);
        audioPlayer.pitch = Random.Range(0.8f, 1);
        audioPlayer.Play();
    }

}
