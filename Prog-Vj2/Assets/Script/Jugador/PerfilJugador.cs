using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPerfilJugador", menuName = "SO/Perfil_Jugador")]
public class PerfilJugador : ScriptableObject
{

    //Configuracion de Movimiento
    //Variables a configurar desde el editor
    [Header("Configuracion Movimiento")]
    [Range(3, 10)]
    [SerializeField] float velocidad = 5f;
    [SerializeField] private float fuerzaSalto = 5f;
    public float Velocidad { get => velocidad; }
    public float FuerzaSalto { get => fuerzaSalto;}


    // Sistema de Experiencia
    private int nivel;
    /// Es necesario tener set en el nivel para poder aumentarlo en el script progresion.
    ///Experiencia
    private int exp;
    [Header("Configuracion de Experiencia")]
    [SerializeField]
    [Tooltip("Rango de experiencia necesaria para el proximo nivel 10 a 20")]
    [Range(10, 20)]
    private int expProxNivel;
    [SerializeField]
    [Tooltip("Como aumenta la Experiencia nivel a nivel")]
    [Range(10, 1000)]
    private int escalarExp;
    [SerializeField]
    [Tooltip("Experiencia que otorgan agarrar los coleccionables")]
    private int exp_Obtenida;

    public int Nivel { get => nivel; set => nivel = value; }
    public int Exp { get => exp; set => exp = value; }
    public int ExpProxNivel { get => expProxNivel; set => expProxNivel = value; }
    public int EscalarExp { get => escalarExp; set => escalarExp = value; }
    public int Exp_Obtenida { get => exp_Obtenida; }

    //Configuraciones de los stats del personaje.
    [Header("Configuracion de Atributos")]
    [SerializeField]
    [Range(5, 10)]
    private float vida = 5f;
    public float Vida { get => vida; set => vida = value; }

    //Configuraciones de los Sonidos.
    [Header("Configuracion de Sonido")]
    [Tooltip("Sonido que hace el personaje al saltar")]
    [SerializeField] private AudioClip saltoSFX;
    [Tooltip("Sonido que hace el personaje al colisionar")]
    [SerializeField] private AudioClip colisionSFX;

    public AudioClip SaltoSFX { get => saltoSFX; }
    public AudioClip ColisionSFX { get => colisionSFX;}
    
}
