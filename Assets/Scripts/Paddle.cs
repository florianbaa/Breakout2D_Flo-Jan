using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Klasse "Paddle" erstellt

public class Paddle : MonoBehaviour
{
    //Zuweisung der Fields

    public string inputAxisName = "";
    public float speed = 2;

    Rigidbody2D rigidbody2D;

    //Zuweisung des Rigidbody Komponente

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    //Funktion zum bewegen des Paddles

    private void FixedUpdate()
    {
        rigidbody2D.velocity = Vector3.right * speed * Input.GetAxis(inputAxisName);
    }
}
