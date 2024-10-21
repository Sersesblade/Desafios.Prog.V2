using System.Collections.Generic;
using UnityEngine;

public class LevelProgressionManager : MonoBehaviour
{
    public Queue<string> levelQueue = new Queue<string>();

    private void Start()
    {
        InitializeLevelQueue();
    }

    private void InitializeLevelQueue()
    {
        levelQueue.Enqueue("Level1");
        levelQueue.Enqueue("Level2");
        levelQueue.Enqueue("Level3");
        // Agrega más niveles aquí si es necesario
    }

    public void CompleteCurrentLevel()
    {
        if (levelQueue.Count > 0)
        {
            string completedLevel = levelQueue.Dequeue();
            Debug.Log("Nivel completado: " + completedLevel);
        }
        else
        {
            Debug.Log("Todos los niveles han sido completados");
        }
    }
}