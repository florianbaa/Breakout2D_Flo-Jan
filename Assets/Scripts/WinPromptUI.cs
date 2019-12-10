using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Klasse WinPrompt erstellt

public class WinPromptUI : MonoBehaviour
{


    Text textComponent;
    GameController gameController;

    public Ball lifeRef;
    
    //Erhalten von Event Informationen

    private void Awake()
    {
        textComponent = GetComponent<Text>();

        gameController = GameObject.FindObjectOfType<GameController>();
        if(gameController != null)
        {
            gameController.OnGameStateChanged += GameController_OnGameStateChanged;
        }

        HidePrompt();
    }

    private void GameController_OnGameStateChanged(bool playing)
    {
        if (playing)
        {
            HidePrompt();
        }
        else if (lifeRef.life == 0)
        {
            lifeRef.OnLifeChanged += LifeRef_OnLifeChanged;
            ShowPrompt("You lost!!!");
        }
    }

    private void LifeRef_OnLifeChanged(int life)
    {

    }

    // Bei Niederlage wird Text angezeigt, während des spielens versteckt

    void ShowPrompt(string loose)
    {
        textComponent.enabled = true;
    }

    void HidePrompt()
    {
        textComponent.enabled = false;
    }
}
