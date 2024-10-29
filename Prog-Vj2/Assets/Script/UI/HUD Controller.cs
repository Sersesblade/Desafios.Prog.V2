using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI texto;

    public void ActualizarTextoHUD(string n_texto)
    {
        Debug.Log("La vida es: " + n_texto);
        texto.text = n_texto;
    }

}
