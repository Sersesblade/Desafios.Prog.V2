using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private GameObject mochila;
    [SerializeField] private Transform padreObjetivos;

    private Queue<GameObject> objetivos;
    private Stack<GameObject> items;
    private Dictionary<string, GameObject> inventario;

    private Progresion progresionJugador;

    private void Awake()
    {
        objetivos = new Queue<GameObject>();
        items = new Stack<GameObject>();
        inventario = new Dictionary<string, GameObject>();
        CargarObjetivos();
        VerObjetivos();

        progresionJugador = GetComponent<Progresion>();

    }

    private void CargarObjetivos()
    {
        foreach (Transform objetivo in padreObjetivos)
        {
            objetivos.Enqueue(objetivo.gameObject);
        }
    }

    private void VerObjetivos()
    {
        foreach (GameObject objetivo in objetivos)
        {
            ///Muestra en consola los objetivos faltantes en orden.
            Debug.Log(objetivo.name);
        }
    }

    private bool EsObjetivoActual(GameObject objetivoActual, GameObject objetivoReal)
    {
        return objetivoActual == objetivoReal;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Coleccionable")) { return; }
        if (objetivos.Count == 0) { return; }

        GameObject objetivo = objetivos.Peek();

        if (EsObjetivoActual(collision.gameObject, objetivo))
        {
            objetivo.SetActive(false);
            objetivos.Dequeue();
            items.Push(objetivo);
            inventario.Add(objetivo.name, objetivo);
            VerObjetivos();
            objetivo.transform.SetParent(mochila.transform);
            progresionJugador.GanarExperiencia(progresionJugador.PerfilJugador.Exp_Obtenida);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1) && inventario.ContainsKey("Rubi"))
        {
            UsarInventario(inventario["Rubi"]);
            ///Muestra en consola el nivel del personaje al precionar la tecla solicitada.
            Debug.Log(progresionJugador.PerfilJugador.Nivel);
        }

        if (Input.GetKeyDown(KeyCode.F2) && inventario.ContainsKey("Amatista"))
        {
            UsarInventario(inventario["Amatista"]);
            Debug.Log(progresionJugador.PerfilJugador.Nivel);
        }
        if (Input.GetKeyDown(KeyCode.F3) && inventario.ContainsKey("Diamante"))
        {
            UsarInventario(inventario["Diamante"]);
            Debug.Log(progresionJugador.PerfilJugador.Nivel);
        }
        
    }

    private void UsarInventario(GameObject item) {
        item.transform.SetParent(null);
        item.transform.position = transform.position;
        item.SetActive(true);
    }
}
