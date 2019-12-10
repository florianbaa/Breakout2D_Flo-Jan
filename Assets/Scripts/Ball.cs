using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Klasse für den Ball erstellt

public class Ball : MonoBehaviour
{
    //Verbindung zu anderen Scripts

    public GameController gC;
    public SceneReload newScene;
    Rigidbody2D rigidbody2D;
    GameController gameController;

   //Fields der Klasse "Ball"

    public float initialSpeed;
    public int life = 3;

    [Range(1.01f, 1.25f)]
    public float speedMultiplier = 1.01f;
    [Range(0, 3f)]
    public float deviationFactor = 2;
    
    //Event: Sendet Information wenn sich "Life" ändert

    public event System.Action<int> OnLifeChanged;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        gameController = GameController.FindObjectOfType<GameController>();
        if(gameController != null)
        {
            gameController.OnGameStateChanged += GameController_OnGameStateChanged;
        }
        
    }
    public int Life
    {
        get
        {
            return Life;
        }
    }
    private void GameController_OnGameStateChanged(bool playing)
    {
        if (playing)
        {
            ResetLife();
            StartBall();
        }
        else
        {
            ResetBall();
        }
    }
    void ResetLife()
    {
        life = 3;
        OnLifeChanged?.Invoke(life);
    }

    //Collision Funktion / Reaktion auf Collision (Ball mit Abyss)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            ResetBall();
            StartBall();

        }

        life--;
        OnLifeChanged?.Invoke(life);
    }

    //Collision Funktion / Collision Ball mit Paddle

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 ballPos = transform.position;
            Vector3 paddlePos = collision.transform.position;

            float deltaPos = ballPos.x - paddlePos.x;
            if (deltaPos > 0)
            {
                deltaPos -= collision.otherCollider.bounds.extents.x;
            }
            else if (deltaPos < 0)
            {
                deltaPos -= collision.otherCollider.bounds.extents.y;
            }
            

            float paddleWidth = collision.transform.localScale.x * collision.collider.bounds.size.x;
           

            float normalizedDeltaPos = deltaPos / paddleWidth;
            

            float vTemp = rigidbody2D.velocity.magnitude;

            float newX = rigidbody2D.velocity.x;
            newX += normalizedDeltaPos * deviationFactor;
            rigidbody2D.velocity = new Vector2(newX, rigidbody2D.velocity.y);
            
            rigidbody2D.velocity = rigidbody2D.velocity.normalized * vTemp;

            rigidbody2D.velocity *= speedMultiplier;
        }
       
    }

    void OnTrigger2D(Collider2D col) 
    {
        if (col.tag == "Brick")
        {
            Destroy(col.gameObject);
            
        }
    }

    //Funktionen um Ball zu Reseten bzw. zu starten

    private void ResetBall()
    {
        // reset ball position
        transform.position = Vector3.zero;

        // remove ball speed
        rigidbody2D.velocity = Vector2.zero;
    }

    private void StartBall()
    {
        // set initial speed
        rigidbody2D.velocity = initialSpeed * Vector3.down.normalized;
    }

    //Funktion zum starten des Spiels beim drücken der Return Taste

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartBall();
            
        }
        
    }
}
