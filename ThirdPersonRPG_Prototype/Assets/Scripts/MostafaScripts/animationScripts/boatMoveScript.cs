using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatMoveScript : MonoBehaviour {

    private GameObject rootPlayer;
    private Animator anim;

    private bool hasFinished;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();

        hasFinished = false;
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider coll) {
        if (coll.transform.tag == "Player") {
            rootPlayer = coll.transform.root.gameObject;

            rootPlayer.transform.parent = this.transform;

            Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y + 0.52f, this.transform.position.z);
            coll.transform.position = pos;


            //anim.SetBool("playerOnBoat", true);
            //anim.Play("boat_MovesToDestination");

            anim.Play("newBoatMoveToShore");

            this.gameObject.GetComponent<Collider>().enabled = false;

        }
    }

    void OnTriggerExit(Collider coll) {
        if (coll.transform.tag == "Player") {
            rootPlayer.transform.parent = null;

        }
    }

    void OnTriggerStay(Collider coll) {
        if (hasFinished == false) {

        }
    }
}
