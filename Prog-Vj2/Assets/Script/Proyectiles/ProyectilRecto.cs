using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilRecto : Proyectil
{
    protected override void Movimiento()
    {
        Vector2 direccion = Vector2.down;
        rb.velocity = direccion * speed;
    }
}
