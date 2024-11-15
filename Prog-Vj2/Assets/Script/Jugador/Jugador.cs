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

    [SerializeField]
    private UnityEvent<string> OnTextChange;
    

    private void Start()
    {
        OnLivesChanged.Invoke(perfilJugador.Vida);
        OnTextChange.Invoke(GameManager.Instance.GetScore().ToString());
    }


    public void ModificarVida(int puntos)
    {
        //Condicional para limitar la curacion del jugador.
        if (perfilJugador.Vida < perfilJugador.VidaMax && puntos > 0 || puntos < 0)
        {
            perfilJugador.Vida += puntos;
            OnLivesChanged.Invoke(perfilJugador.Vida);

            
        }

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

    //Funcion que es llamada para actualizar el puntaje en pantalla.
    public void ActualizarScore()
    {
        OnTextChange.Invoke(GameManager.Instance.GetScore().ToString());
    }
}