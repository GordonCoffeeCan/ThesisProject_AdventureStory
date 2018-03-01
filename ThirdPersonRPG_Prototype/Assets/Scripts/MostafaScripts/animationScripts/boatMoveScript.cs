using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatMoveScript : MonoBehaviour {

    private GameObject rootPlayer;
    private Animator anim;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
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


            anim.Play("boat_MovesToDestination");

        }
    }

    void OnTriggerExit(Collider coll) {
        if (coll.transform.tag == "Player") {
            rootPlayer.transform.parent = null;

        }
    }
}
