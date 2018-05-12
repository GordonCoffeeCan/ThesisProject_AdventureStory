using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireLight : MonoBehaviour {
    private ParticleSystem part;


    private float luminosity;

    // Use this for initialization
    void Start () {

        luminosity = this.GetComponent<Light>().intensity;
        this.GetComponent<Light>().intensity = 0;

        part = this.transform.parent.GetComponent<ParticleSystem>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (part.transform.parent.GetComponent<flammable>().onFire == true) {

            lightUp();
        }



    }

    void lightUp() {

        while(this.GetComponent<Light>().intensity < luminosity) {
            this.GetComponent<Light>().intensity = this.GetComponent<Light>().intensity + (Time.deltaTime*1);

            //this.GetComponent<Light>().intensity = Mathf.Lerp(this.GetComponent<Light>().intensity, luminosity, Time.deltaTime);
        }
         
    }
}
