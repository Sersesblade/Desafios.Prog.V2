using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progresion : MonoBehaviour
{
    [SerializeField]
    private PerfilJugador perfilJugador;
    public PerfilJugador PerfilJugador { get => perfilJugador; }

    public void GanarExperiencia(int nueva_Exp)
    {
        perfilJugador.Exp += nueva_Exp;

        if(perfilJugador.Exp >= perfilJugador.ExpProxNivel)
        {
            SubirNivel();
        }
    }

    private void SubirNivel()
    {
        perfilJugador.Nivel++;
        perfilJugador.Exp -= perfilJugador.ExpProxNivel;
        perfilJugador.ExpProxNivel += perfilJugador.EscalarExp;
    }
}
