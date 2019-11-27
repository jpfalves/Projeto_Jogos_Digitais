using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameSettings")]
public class GameSettings : ScriptableObject
{

    public float menuFadeTime = .5f;
    public Color sceneChangeFadeColor = Color.black;
    [Header("Leave this at zero to start game in same scene as menu, otherwise set to scene index")]
    public int nextSceneIndex = 0;

    [Header("Add your menu music here")]
    public AudioClip mainMenuMusicLoop;
    [Header("Player Death Music")]
    public AudioClip musicPlayerDeath;

}
