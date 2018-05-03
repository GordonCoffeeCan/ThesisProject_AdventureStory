using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerPlayAudio : MonoBehaviour {

    private bool hasTriggered = false;
    public AudioSource audio;

   
    public string subtitleText;

    private Text targetSubtitleText;




	// Use this for initialization
	void Start () {
        GameObject playerCam = GameObject.Find("PlayerCamera").gameObject;

        audio = playerCam.GetComponent<AudioSource>();

        targetSubtitleText = GameObject.Find("SubtitleText").GetComponent<Text>();

        
    }
	
	// Update is called once per frame
	void Update () {
        if (hasTriggered == true) {
            if (audio.isPlaying == false) {
                targetSubtitleText.text = "";
            }
        }
       
	}

    private void OnTriggerStay(Collider _col) {
        if (hasTriggered == false) {
            if (_col.transform.tag == "Player") {

                

                audio.clip = this.GetComponent<AudioSource>().clip;

                

                audio.Play();


                hasTriggered = true;

                ParticleSystem part = this.transform.Find("fireFlyEffect").GetComponent<ParticleSystem>();
                var em = part.emission;

                em.rateOverTime = 0;

               
                targetSubtitleText.text = "";
                targetSubtitleText.text += subtitleText;

                


            }
        }
    }

}
