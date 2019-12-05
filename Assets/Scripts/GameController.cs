using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject life1, life2, life3, life4, gameOver, uiCanvas, Player;
    public static int lifeCount, lifeMax = 4;
    public Button PlayAgainButton,MainMenuButton;


    // Start is called before the first frame update
    void Start()
    {
        lifeCount = 3;
        life1.gameObject.SetActive(true);
        life2.gameObject.SetActive(true);
        life3.gameObject.SetActive(true);
        life4.gameObject.SetActive(false);
        uiCanvas.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        Player.gameObject.SetActive(true);

        MainMenuButton.onClick.AddListener(goToMainMenu);
        PlayAgainButton.onClick.AddListener(PlayAgain);
    }

    private void goToMainMenu()
    {
        // Debug.Log("Main Menu Clicked !");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeCount == 4)
        {
            life1.gameObject.SetActive(true);
            life2.gameObject.SetActive(true);
            life3.gameObject.SetActive(true);
            life4.gameObject.SetActive(true);
        }
        if (lifeCount == 3)
        {
            life1.gameObject.SetActive(true);
            life2.gameObject.SetActive(true);
            life3.gameObject.SetActive(true);
            life4.gameObject.SetActive(false);
        }
        if (lifeCount == 2)
        {
            life1.gameObject.SetActive(true);
            life2.gameObject.SetActive(true);
            life3.gameObject.SetActive(false);
            life4.gameObject.SetActive(false);
        }
        if (lifeCount == 1)
        {
            life1.gameObject.SetActive(true);
            life2.gameObject.SetActive(false);
            life3.gameObject.SetActive(false);
            life4.gameObject.SetActive(false);
        }
        if (lifeCount == 0)
        {
            life1.gameObject.SetActive(false);
            life2.gameObject.SetActive(false);
            life3.gameObject.SetActive(false);
            life4.gameObject.SetActive(false);
            uiCanvas.gameObject.SetActive(true);
            gameOver.gameObject.SetActive(true);
            Player.gameObject.SetActive(false);
        }
    }

    void PlayAgain()
    {
        SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
    }
}
