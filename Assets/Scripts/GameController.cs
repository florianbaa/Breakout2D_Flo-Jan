using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Klasse GameController erstellt

public class GameController : MonoBehaviour
{

    //Zuweisung der Fields

    public Ball ball;
    public int lives;
    public Text livesText;


    public int loseCondition = 0;

    bool playing = false;
    public bool Isplaying { get { return playing; } }

    public delegate void gameStateChangeDelegate(bool playing);
    public event gameStateChangeDelegate OnGameStateChanged;

    //Funktionen der "Spielregeln"

    private void Awake()
    {
        if(ball == null)
        {

            enabled = false;
        }
        else
        {
            ball.OnLifeChanged += Ball_OnLifeChanged;
        }
    }


    private void Ball_OnLifeChanged(int newLife)
    {
        if(newLife <= loseCondition)
        {
            playing = false;
            OnGameStateChanged?.Invoke(playing);   
        }
    }

    //Funktion zum Anzeigen der Leben

    private void Start()
    {
        livesText.text = "Lives: " + lives;
        OnGameStateChanged?.Invoke(playing);
    }

    //Funktion zum starten des Spiels

    private void Update()
    {
        if (!playing)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                playing = true;
                OnGameStateChanged?.Invoke(playing);
            }   
        }
    }
}
