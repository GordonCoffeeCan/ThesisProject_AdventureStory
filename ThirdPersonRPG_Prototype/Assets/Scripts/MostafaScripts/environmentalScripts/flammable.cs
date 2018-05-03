using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flammable : MonoBehaviour {
    public bool isFlammable;
    private ParticleSystem part;
  
    // Use this for initialization

    public bool canBurnUp;
    public bool canSpreadFire;
    public bool onFire;

    public AudioClip clip;

	void Start () {
        onFire = false;

        part = this.transform.Find("fire").GetComponent<ParticleSystem>();
       
        isFlammable = true;

    
        var em = part.emission;

        em.rateOverTime = 0;

        clip = GameObject.Find("fireAudioHolder").GetComponent<AudioSource>().clip;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Fire") {

            onFire = true;
            Debug.Log("This log is burning");
            Burn();

        }

        if (canSpreadFire == true) {
            
            Invoke("FireSpread", 0.5f);
        }
    }

    public void Burn() {

        var em = part.emission;

        float i = Random.Range(0.01f, 0.02f);
        AudioSource.PlayClipAtPoint(clip, this.transform.position,i);

        em.rateOverTime = 10;
        if (canBurnUp == true) {
            Invoke("BurnUp", 2);
        }
    }

    private void FinishBurn() {
        Destroy(this.gameObject);
     
    }

    private void BurnUp() {
        this.GetComponent<Renderer>().enabled = false;
        var em = part.emission;

        em.rateOverTime = 0;
        Invoke("FinishBurn", 1.25f);
    }

    private void FireSpread() {
        Collider partCollider = part.gameObject.GetComponent<Collider>();
        partCollider.enabled = true;
    }
}
