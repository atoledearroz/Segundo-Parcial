using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenados : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);

    }

    public void Instrucciones()
    {
        SceneManager.LoadScene(1);

    }

    public void Juego()
    {
        SceneManager.LoadScene(2);

    }
}