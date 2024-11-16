using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class P_Fireball : MonoBehaviour
{
    [SerializeField] float velocidad = 5f;

    [Header("Configuracion de Alcance")]
    [SerializeField]
    [Tooltip("Alcance en Y de vida del objeto.")]
    private float verti_dest = 0f;
    [SerializeField]
    [Tooltip("Alcance en X de vida del objeto")]
    private float horiz_dest = 0f;


    void Update()
    {
        
        transform.position += Vector3.left * velocidad * Time.deltaTime;

        //Destructor en base a la posicion X.
        if (verti_dest != 0f) { if (transform.position.y < verti_dest) { Destroy(gameObject); } }
        if (horiz_dest != 0f) { if (transform.position.x < horiz_dest) { Destroy(gameObject); } }
        

        //Destructor en base al tiempo.
        //Destroy(gameObject, 4f);
    } 
    
}