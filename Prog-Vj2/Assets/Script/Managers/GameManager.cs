using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    private int score;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        GameEvent.onPause += Pausar;
        GameEvent.onResume += Resume;
    }

    private void OnDisable()
    {
        GameEvent.onPause -= Pausar;
        GameEvent.onResume -= Resume;
    }

    private void Pausar()
    {
        Time.timeScale = 0;
        Debug.Log("PAUSA");
    }

    private void Resume()
    {
        Time.timeScale = 1;
        Debug.Log("Reanudado");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale != 0) {
                GameEvent.TriggerPause();
            }
            else
            {
                GameEvent.TriggerResume();
            }
        }
    }

    public void AddScore(int points)
    {
        //Debug.Log(points + " Puntos agregados.");
        score += points;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public int GetScore() 
    { 
        return score;
    }
}
