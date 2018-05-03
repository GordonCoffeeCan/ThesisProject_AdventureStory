using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICrossFade : MonoBehaviour {

    public float fadeInTime;
    public float fadeOutTime;

    //Attach an Image you want to fade in the GameObject's Inspector
    public Image m_Image;
    //Use this to tell if the toggle returns true or false
    public bool m_Fading;

    void Start() {
        fadeInTime = 2.0f;
        fadeOutTime = 2.0f;

        Invoke("shorten", 3f);

    }

    void Update() {
        //If the toggle returns true, fade in the Image
        if (m_Fading == true) {
            //Fully fade in Image (1) with the duration of 2
            m_Image.CrossFadeAlpha(1, fadeInTime, false);
        }
        //If the toggle is false, fade out to nothing (0) the Image with a duration of 2
        if (m_Fading == false) {
            m_Image.CrossFadeAlpha(0, fadeOutTime, false);
        }
    }

    void OnGUI() {
        //Fetch the Toggle's state
        //m_Fading = GUI.Toggle(new Rect(0, 0, 100, 30), m_Fading, "Fade In/Out");
    }

    void shorten() {
        fadeInTime = 0.5f;
        fadeOutTime = 0.5f;

    }

    void lengthen() {
        fadeInTime = 1f;
        fadeOutTime = 2f;
    }
}
