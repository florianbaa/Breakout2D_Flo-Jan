using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//Klasse "SceneReload" erstellt

public class SceneReload : MonoBehaviour
{
    
    //Funktion zum neustarten der Szene beim drücken der Space Taste

    public void SceneRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneRestart();
        }
    }


}

        
   

