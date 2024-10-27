using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modificadores : MonoBehaviour
{

    public List<GameObject> paredes;
    public Material[] texturaPared = new Material[3];
    int contadorPared = 0;

    public GameObject piso;
    public Material[] texturaPiso = new Material[3];
    int contadorPiso = 0;

    public GameObject puerta;
    public Color[] colorPuerta = new Color[3];
    int contadorPuerta = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        piso.GetComponent<MeshRenderer>().material = texturaPiso[contadorPiso];
        puerta.GetComponent<MeshRenderer>().material.color = colorPuerta[contadorPuerta];

        for (int i = 0; i <paredes.Count; i++)
        {
            paredes[i].GetComponent<MeshRenderer>().material = texturaPared[contadorPared];
        }

        if(Input.GetKey(KeyCode.Space))
        {
            if(Input.GetMouseButtonDown(0))
            {
                contadorPared++;
            }
        }

        if (contadorPared > 2) contadorPared = 0;

        if(Input.GetKey(KeyCode.E))
        {
            if(Input.GetMouseButtonDown(0))
            {
                contadorPiso++;
            }
        }

        if (contadorPiso > 2) contadorPiso = 0;

        if(Input.GetKey(KeyCode.W))
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                contadorPuerta++;
            }
        }

        if (contadorPuerta > 2) contadorPuerta = 0;

    }
}
