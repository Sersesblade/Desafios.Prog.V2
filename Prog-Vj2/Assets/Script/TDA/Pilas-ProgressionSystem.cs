using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilas_ProgressionSystem : MonoBehaviour
{
    private Stack<string> tasks;

    void Start()
    {
        tasks = new Stack<string>();
        tasks.Push("Task 3: Derrotar al jefe");
        tasks.Push("Task 2: Encontrar la llave");
        tasks.Push("Task 1: Activar el interruptor");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (tasks.Count > 0)
            {
                Debug.Log("Completado: " + tasks.Pop());
            }
            else
            {
                Debug.Log("¡Todas las tareas completadas!");
            }
        }
    }
}