using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mover : MonoBehaviour
{
    
    // Variables de uso interno en el script
    private float moverHorizontal;
    private Vector2 direccion;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private SpriteRenderer miSprite;
    private BoxCollider2D miCollider2D;
    private Jugador jugador;

    private int saltoMask;

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
        miCollider2D = GetComponent<BoxCollider2D>();
        saltoMask = LayerMask.GetMask("Pisos", "Plataformas");

        jugador = GetComponent<Jugador>();
        
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
        direccion = new Vector2(moverHorizontal, 0f);

        int velocidadX = (int)miRigidbody2D.velocity.x;
        miSprite.flipX = velocidadX < 0;
        miAnimator.SetInteger("Velocidad", velocidadX);


        miAnimator.SetBool("EnAire", miRigidbody2D.velocity.y != 0 && !EnContactoConPlataforma());


        //Tecla para volver a la escena anterior o reiniciar el mismo nivel.
        if (Input.GetKey(KeyCode.F5)) {
            //Para cargar la escena Nivel 1 al presionar "F5".
            //SceneManager.LoadScene("Nivel 1");

            //Para volver a la escena anterior.
            ApplicacionManager.Instance.GoToPreviousScene();
        }
        
    }
    private void FixedUpdate()
    {
        miRigidbody2D.AddForce(direccion * jugador.PerfilJugador.Velocidad);
    }

    private bool EnContactoConPlataforma()
    {
        return miCollider2D.IsTouchingLayers(saltoMask);
    }
}