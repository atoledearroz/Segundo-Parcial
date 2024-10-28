using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscogerCasa : MonoBehaviour
{
    public Sprite[] imagenes; 
    public Image imagenActual; 
    private int indiceActual = 0; 
    public string[] nombreDeEscenas;

    // Start is called before the first frame update
    void Start()
    {
        imagenActual.sprite = imagenes[indiceActual];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarImagen()
    {
        indiceActual = (indiceActual + 1) % imagenes.Length;
        imagenActual.sprite = imagenes[indiceActual];
    }

    public void Regresar()
    {
        indiceActual = (indiceActual - 1 + imagenes.Length) % imagenes.Length;
        imagenActual.sprite = imagenes[indiceActual];
    }



    public void SeleccionarImagen()
    {
        if (indiceActual >= 0 && indiceActual < nombreDeEscenas.Length)
        {
            SceneManager.LoadScene(nombreDeEscenas[indiceActual]);
        }
    }

}
