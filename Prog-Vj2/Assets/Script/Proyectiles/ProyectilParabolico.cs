using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilParabolico : Proyectil
{
    [SerializeField]
    [Range(0f, 90f)]
    private float angulo_Lanzamiento = 45f;
    protected override void Movimiento()
    {
        //Calcula la velocidad inicial basada en el angulo y la fuerza de lanzamiento.
        float lanzamiento_Radianes = angulo_Lanzamiento * Mathf.Deg2Rad;
        Vector2 lanzamiento_Velocidad = new Vector2(Mathf.Cos(lanzamiento_Radianes) * speed, Mathf.Sin(lanzamiento_Radianes) * speed);

        //Aplica la velocidad al proyectil.
        rb.velocity = lanzamiento_Velocidad;
    }
}
