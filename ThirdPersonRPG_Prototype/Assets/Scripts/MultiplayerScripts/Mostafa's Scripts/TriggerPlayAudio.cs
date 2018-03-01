using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayAudio : MonoBehaviour {

    private bool hasTriggered = false;
    public AudioSource audio;

	// Use this for initialization
	void Start () {
        GameObject playerCam = GameObject.Find("PlayerCamera").gameObject;

        audio = playerCam.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider _col) {
        if (hasTriggered == false) {
            if (_col.transform.tag == "Player") {
                Debug.Log("Player ENtered");
                
                audio.clip = this.GetComponent<AudioSource>().clip;
                audio.Play();
                hasTriggered = true;

                ParticleSystem part = this.transform.Find("fireFlyEffect").GetComponent<ParticleSystem>();
                var em = part.emission;

                em.rateOverTime = 0;

                
                
            }
        }
    }
}
