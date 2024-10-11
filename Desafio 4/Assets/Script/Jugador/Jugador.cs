using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float vida = 5f;

    private Animator miAnimator;

    public void ModificarVida(float puntos)
    {
        vida += puntos;
        Debug.Log(EstasVivo());
        if (!EstasVivo())
        {
            Debug.Log("Perdiste");
        }
    }


    private bool EstasVivo()
    {
        return vida > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Meta")) { return; }

        Debug.Log("GANASTE");
    }
}