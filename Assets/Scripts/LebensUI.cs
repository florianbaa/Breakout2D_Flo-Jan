using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Klasse LebensUI erstellt

public class LebensUI : MonoBehaviour
{
    //Zuweisung der Fields

    Text textRef;

    public Ball ballRef;
    public GameController gameController;

    //Funktion zum überprüfen und beschaffung einer Text Komponente

    private void Awake()
    {
        textRef = GetComponent<Text>();
        if (textRef == null)
        {
            enabled = false;
        }
        if (ballRef == null)
        {
            enabled = false;
        }
        else
        {
            ballRef.OnLifeChanged += BallRef_OnLifeChanged;
        }
    }

    //Erhalten von Event Informationen und ändern der Lebens Anzeige

    private void BallRef_OnLifeChanged(int newLife)
    {
        
        textRef.text = "Lives: " + newLife;

    }

    //Funktion zum festlegne der Start Leben

    void Start()
    {
        textRef.text = "Leben: 3";
    }

    //Funktion zum zerstören von Objekten

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }

}
    
