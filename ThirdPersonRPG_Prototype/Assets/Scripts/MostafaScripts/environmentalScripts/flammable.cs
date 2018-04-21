using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flammable : MonoBehaviour {
    public bool isFlammable;
    private ParticleSystem part;
    // Use this for initialization

    public bool canBurnUp;
    public bool canSpreadFire;

	void Start () {

        part = this.transform.Find("fire").GetComponent<ParticleSystem>();
        isFlammable = true;

        var em = part.emission;

        em.rateOverTime = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Fire") {
            Debug.Log("This log is burning");
            Burn();

        }

        if (canSpreadFire == true) {
            
            Invoke("FireSpread", 2);
        }
    }

    public void Burn() {

        var em = part.emission;

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
        Invoke("FinishBurn", 0.5f);
    }

    private void FireSpread() {
        Collider partCollider = part.gameObject.GetComponent<Collider>();
        partCollider.enabled = true;
    }
}
