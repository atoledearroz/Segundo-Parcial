using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MecanicaDos : MonoBehaviour
{
    public GameObject[] mueble = new GameObject[4];
    public Sprite[] imgmueble = new Sprite[4];
    public Image imguno;
    public Image imgdos;
    public Image imgtres;
    public string[] muebleNombre = new string[4];
    public Text nombre;

    private int obj = 0;
    private int imgE = 0;
    private int imgI = 0;
    public int ColorActual;
    public List<Color> colores;


    // Categoría uno
    public string catoUno;
    public Sprite[] imgA = new Sprite[3];
    public string[] objetoUno = new string[3];

    // Categoría dos
    public string catoDos;
    public Sprite[] imgB = new Sprite[3];
    public string[] objetoDos = new string[3];

    // Categoría tres
    public string catoTres;
    public Sprite[] imgC = new Sprite[3];
    public string[] objetoTres = new string[3];

    Vector3 angulos;
    float angY = 0;
    float angX = 0;
    GameObject objetoSeleccionado;
    public Material transparente;
    public GameObject preview; 
    public GameObject[] muebleUno = new GameObject[3];
    public GameObject[] muebleDos = new GameObject[3];
    public GameObject[] muebleTres = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        preview = Instantiate(mueble[obj]);
        preview.GetComponent<MeshRenderer>().material = transparente;
        preview.GetComponent<Collider>().enabled = false;
        Destroy(preview.GetComponent<Rigidbody>());
        nombre.text = catoUno;

        nombre.text = catoUno;
        for (int i = 0; i < 2; i++)
        {
            mueble[i].GetComponent<SpriteRenderer>().sprite = imgA[i];
            nombre.text = objetoUno[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 2 == 0)
        {
            Muebles();
        }
        else
        {
            preview.SetActive(false);
        }
    }

    void Muebles()
    {
        preview.GetComponent<MeshFilter>().mesh = mueble[0].GetComponent<MeshFilter>().sharedMesh;
        preview.transform.localEulerAngles = angulos;
        angulos = new Vector3(angX, angY, 0);
        imguno.sprite = imgmueble[0];
        imgdos.sprite = imgmueble[0];
        imgtres.sprite = imgmueble[0];
        nombre.text = muebleNombre[0];

        if (Input.GetKeyDown(KeyCode.W))
        {
            obj++;
            imgE++;
            imgI++;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            obj--;
            imgE--;
            imgI--;
        }
        if (obj < 0) obj = 3;
        if (obj > 3) obj = 0;
        if (imgE < 0) imgE = 3;
        if (imgE > 3) imgE = 0;
        if (imgI < 0) imgI = 3;
        if (imgI > 3) imgI = 0;

        if (Input.GetKeyDown(KeyCode.D)) angY = angY + 45;
        if (Input.GetKeyDown(KeyCode.A)) angX = angX - 45;
        if (Input.GetKey(KeyCode.G))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) angX = angX + 45;
            if (Input.GetKeyDown(KeyCode.RightArrow)) angX = angX - 45;
        }
        if (Input.GetKey(KeyCode.C))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (objetoSeleccionado != null)
                {
                    objetoSeleccionado.GetComponent<MeshRenderer>().material.color = colores[ColorActual];
                    ColorActual++;
                    if (ColorActual == colores.Count)
                    {
                        ColorActual = 0;
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(0) && objetoSeleccionado == null)
        {
            objetoSeleccionado = Instantiate(mueble[obj]);
            preview.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (objetoSeleccionado.GetComponent<Rigidbody>() == null)
            {
                objetoSeleccionado.AddComponent<Rigidbody>();
            }
            objetoSeleccionado = null;
            angX = 0;
            angY = 0;
            preview.SetActive(true);
        }
        if (objetoSeleccionado != null)
        {
            objetoSeleccionado.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            objetoSeleccionado.transform.localEulerAngles = angulos;
        }
        Vector3 posicionDelMouseEditor = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1000));
        if (Input.GetMouseButtonDown(0))
        {
            Debug.DrawRay(Camera.main.transform.position, posicionDelMouseEditor * 1000, Color.blue);
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.transform.position, posicionDelMouseEditor, out hitInfo, 1000f))
            {
                objetoSeleccionado = hitInfo.collider.gameObject;
            }
        }
        if (objetoSeleccionado != null)
        {
            if (objetoSeleccionado.tag == "vista")
            {
                objetoSeleccionado = null;
            }
        }
        if (objetoSeleccionado != null)
        {
            objetoSeleccionado.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            preview.SetActive(false);
        }
        else
        {
            preview.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            preview.SetActive(true);
        }
    }

    public void BotonUno()
    {
        angulos = new Vector3(angX, angY, 0);
        if (Input.GetKeyDown(KeyCode.X))
        {
            angX = angY + 45;
        }
        if (objetoSeleccionado == null)
        {
            objetoSeleccionado = Instantiate(muebleUno[0]);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (objetoSeleccionado.GetComponent<Rigidbody>() == null)
            {
                objetoSeleccionado.AddComponent<Rigidbody>();
            }
            objetoSeleccionado = null;
            angX = 0;
        }
        if (objetoSeleccionado != null)
        {
            objetoSeleccionado.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1000));
            objetoSeleccionado.transform.localEulerAngles = angulos;
        }
        Vector3 PosMueble = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1000));
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.transform.position, PosMueble, out hitInfo, 1000f))
            {
                objetoSeleccionado = hitInfo.collider.gameObject;
            }
        }
        if (objetoSeleccionado != null)
        {
            if (objetoSeleccionado.tag == "Pared")
            {
                objetoSeleccionado = null;
            }
        }
    }

    void Controlador()
    {
        angulos = new Vector3(angX, 0, 0);
        if (Input.GetKeyDown(KeyCode.X)) angX = angX + 45;
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (objetoSeleccionado.GetComponent<Rigidbody>() == null) 
            {
                objetoSeleccionado.AddComponent<Rigidbody>();
            }
            objetoSeleccionado = null;
            angX = 0;
        }
        Vector3 PosMueble = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1000));
        if (Input.GetMouseButton(0))
        {
            Debug.DrawRay(Camera.main.transform.position, PosMueble * 1000, Color.yellow);
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.transform.position, PosMueble, out hitInfo, 1000f))
            {
                objetoSeleccionado = hitInfo.collider.gameObject;
            }
        }

        if (objetoSeleccionado != null)
        {
            if (objetoSeleccionado.tag == "vista")
            {
                objetoSeleccionado = null;
            }
        }

        if (objetoSeleccionado != null)
        {
            objetoSeleccionado.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 17));
            objetoSeleccionado.transform.localEulerAngles = angulos;

        }

    }

}


