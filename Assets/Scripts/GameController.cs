using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject life1, life2, life3, life4, gameOver;
    public static int lifeCount, lifeMax = 4;

    // Start is called before the first frame update
    void Start()
    {
        lifeCount = 3;
        life1.gameObject.SetActive(true);
        life2.gameObject.SetActive(true);
        life3.gameObject.SetActive(true);
        life4.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
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
            gameOver.gameObject.SetActive(true);
        }
    }
}
