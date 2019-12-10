using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Klasse "Bricks" erstellt

public class Bricks : MonoBehaviour
{
    //Zuweisung von Fields

    public int healthPoints = 3;

    bool c1;
    bool c2;
    bool c3;

    //Funktion zum ändern der Farbe bei Collision mit Ball
    
    private void FixedUpdate()
    {
        if(c1 == true)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(215f, 20f, 20f, 0.5f);
        }
        if (c2 == true)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0f, 245f, 255f, 0.5f);
        }
        if (c3 == true)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(255f, 0f, 255f, 0.5f);
        }
    }

    //Funktion zum zerstören der Bricks und ändern der Farbe bei Collision mit Ball

    private void OnCollisionEnter2D(Collision2D collision)
    {
        healthPoints--;

        if(healthPoints <= 0)
        {
            Destroy(gameObject);
        }

        if(healthPoints == 1)
        {
            c1 = false;
            c2 = false;
            c3 = true;
        }
        else if (healthPoints == 2)
        {
            c1 = false;
            c2 = true;
            c3 = false;
        }
        else if (healthPoints == 3)
        {
            c1 = true;
            c2 = false;
            c3 = false;
        }

    }

    //Funktion zum setzten der Start Farbe der Bricks

    private void Start()
    {
        c1 = true; 
    }

    
   
}
