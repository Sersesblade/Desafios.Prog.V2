using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{
    [SerializeField]
    private PerfilJugador perfilJugador;
    public PerfilJugador PerfilJugador { get => perfilJugador; }
    private Animator miAnimator;

    //Eventos del Jugador
    [SerializeField]
    private UnityEvent<int> OnLivesChanged;
    

    private void Start()
    {
        OnLivesChanged.Invoke(perfilJugador.Vida);
    }


    public void ModificarVida(int puntos)
    {
        //Condicional para limitar la curacion del jugador.
        if (perfilJugador.Vida < perfilJugador.VidaMax && puntos > 0 || puntos < 0)
        {
            perfilJugador.Vida += puntos;
            OnLivesChanged.Invoke(perfilJugador.Vida); 
        }
        Debug.Log(EstasVivo());
        if (!EstasVivo()){ Debug.Log("Perdiste"); }
    }


    private bool EstasVivo()
    {
        return perfilJugador.Vida > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Meta")) { return; }

        Debug.Log("GANASTE");
    }
}