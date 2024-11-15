using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilRecto : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 30f)]
    private float speed = 10f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Movimiento();
    }

    private void Movimiento()
    {
        Vector2 direccion = Vector2.down;
        rb.velocity = direccion * speed;
    }
}
