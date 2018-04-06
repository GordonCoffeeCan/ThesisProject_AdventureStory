using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killScript : MonoBehaviour {

    public checkPointManager chk;

    [SerializeField]
    private GameObject playerChar;
    [SerializeField]
    private GameObject playerRotationPivot;
    [SerializeField]
    private ParticleSystem deathEffect;

    private bool hasDied;

    // Use this for initialization
    void Start() {

        chk = GameObject.Find("GameManager").GetComponent<checkPointManager>();

        playerChar = GameObject.Find("Player");

        playerRotationPivot = playerChar.transform.Find("RotationPivot").gameObject;

        deathEffect = playerChar.transform.Find("DeathEffect").GetComponent<ParticleSystem>();

        //deathEffect.gameObject.SetActive(false);

        hasDied = false;
        

    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter(Collider coll) {
        if (hasDied == false) {
            if (coll.transform.tag == "Player") {

                killPlayer();

            }
        }

    }

    public void killPlayer() {
        playerChar.GetComponent<CharacterController>().enabled = false;
        playerRotationPivot.SetActive(false);

        hasDied=true;

        Invoke("respawn", 1);
        //deathEffect.gameObject.SetActive(true);
        deathEffect.Clear();
        deathEffect.Play();
        Debug.Log("Die");

    }

    public void respawn() {
        playerChar.GetComponent<CharacterController>().enabled = true;
        playerRotationPivot.SetActive(true);
        //deathEffect.gameObject.SetActive(false);
        playerChar.transform.position = chk.checkPointPos;
        
        hasDied = false;

    }
}
