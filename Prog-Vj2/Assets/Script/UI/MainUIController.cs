using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIController : MonoBehaviour
{
   public void CargarSiguienteEscena()
    {
        ApplicacionManager.Instance.GoToNextScene();
    }

    public void SalirDelJuego()
    {

    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif

    }
}

