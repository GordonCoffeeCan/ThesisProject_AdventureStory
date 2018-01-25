using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static bool isMenuPanelOn = false;

    [SerializeField]
    private Image reticleUI;

    [SerializeField]
    private Image menuPanel;

    [SerializeField]
    private Image staminaRefill;

    [SerializeField]
    private Image coolDownRefill;

    [SerializeField]
    private Image healthRefill;

    [SerializeField]
    private Text cargoesStolen;

    [SerializeField]
    private float cargoCount;

    [SerializeField]
    private GameObject[] cargoArray=null;
  

    //[SerializeField]
    //private Text timerUI;

	// Use this for initialization
	void Start () {

        if (reticleUI != null) {
            reticleUI.gameObject.SetActive(false);
        }

        if(menuPanel != null) {
            menuPanel.gameObject.SetActive(false);
        }

        isMenuPanelOn = false;

        //count all objects at start

        cargoArray = GameObject.FindGameObjectsWithTag("Cargo");


        foreach (GameObject respawn in cargoArray) {
            cargoCount++;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //Check the current scene is single player mode or multiplayer mode;
        //show reticle when aim;
        if (SceneManager.GetActiveScene().name == "Singleplayer_Level") {
            if (ControllerManager.instance.OnAim() && isMenuPanelOn == false) {
                reticleUI.gameObject.SetActive(true);
            } else {
                reticleUI.gameObject.SetActive(false);
            }
        }else if(SceneManager.GetActiveScene().buildIndex == 1) {
            if (MobileInputManager.instance.isGamepadConnected == false) {
                if (MobileInputManager.instance.isAim && GameManager.instance.isPlayerInGame == true && GameManager.instance.isPlayerDie == false && isMenuPanelOn == false) {
                    reticleUI.gameObject.SetActive(true);
                } else {
                    reticleUI.gameObject.SetActive(false);
                }
            } else {
                if (ControllerManager.instance.OnAim() && GameManager.instance.isPlayerInGame == true && GameManager.instance.isPlayerDie == false && isMenuPanelOn == false) {
                    reticleUI.gameObject.SetActive(true);
                } else {
                    reticleUI.gameObject.SetActive(false);
                }
            }
            
        }

        //Show in game menu;
        if (ControllerManager.instance.OnMenu()) {
            isMenuPanelOn = !menuPanel.gameObject.activeSelf;
            menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
        }

        //timerUI.text = Mathf.Floor(MultiplayerGameManager.instance.gameTime).ToString();

        staminaRefill.fillAmount = GameManager.instance.staminaLevel;
        coolDownRefill.fillAmount = GameManager.instance.coolDownLevel;
        healthRefill.fillAmount = GameManager.instance.playerHealthLevel;

        //count how many cargo crates are in the scene.
     
        

        cargoesStolen.text = GameManager.instance.cargoesStolen.ToString() + " out of " + cargoCount;
       
    }
}
