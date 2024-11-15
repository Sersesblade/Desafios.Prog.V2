using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI texto;
    [SerializeField] GameObject iconoVida;
    [SerializeField] GameObject contenedorVida;

    public void ActualizarTextoHUD(string n_texto)
    {
        //Mensaje de Puntuacion en pantalla.
        texto.text = "Puntuacion: " + n_texto;
        
    }

    public void ActualizarVidasHUD(int vidas)
    {

        if (ContenedorVacio())
        {
            CargarContenedor(vidas);
            return;
        }

        if(CantidadDeVidas() > vidas)
        {
            EliminarUltimoIcono();
        }
        else
        {
            CrearIcono();
        }
    }

    private bool ContenedorVacio()
    {
        return contenedorVida.transform.childCount == 0;
    }

    private void CargarContenedor(int cantidadVidas)
    {
        for (int i = 0; i< cantidadVidas; i++)
        {
            CrearIcono();
        }
    }

    private int CantidadDeVidas()
    {
        return contenedorVida.transform.childCount;
    }

    private void EliminarUltimoIcono()
    {
        
        Transform contenedor = contenedorVida.transform;
        GameObject.Destroy(contenedor.GetChild(contenedor.childCount - 1).gameObject);
    }

    private void CrearIcono()
    {
        Instantiate(iconoVida, contenedorVida.transform);
    }
}
