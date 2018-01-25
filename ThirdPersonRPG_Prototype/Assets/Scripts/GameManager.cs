using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public static int obstacleNumber;

    [HideInInspector]
    public float cargoesStolen;

    [HideInInspector]
    public bool isPlayerDie = false;

    [HideInInspector]
    public bool isPlayerInGame = false;

    [HideInInspector]
    public float staminaLevel;

    [HideInInspector]
    public float coolDownLevel;

    [HideInInspector]
    public float playerHealthLevel;

    [HideInInspector]
    public float playerScore; //personal score

    private const string PLAYER_NAME_PREFIX = "Player ";
    private const string OBSTACLE_NAME_PREFIX = "Obstacle";

    private void Awake() {
        if(instance != null) {
            Debug.LogError("More than one Multiplayer Game Manager in the scene!");
        } else {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
}
