using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public Queue<Mission> missionQueue = new Queue<Mission>();

    private void Start()
    {
        InitializeMissionQueue();
    }

    private void InitializeMissionQueue()
    {
        missionQueue.Enqueue(new Mission("Mision 1", "Descripcion de la Mision 1"));
        missionQueue.Enqueue(new Mission("Mision 2", "Descripcion de la Mision 2"));
        missionQueue.Enqueue(new Mission("Mision 3", "Descripcion de la Mision 3"));
        // Agrega mas misiones aqui si es necesario
    }

    public void CompleteCurrentMission()
    {
        if (missionQueue.Count > 0)
        {
            Mission completedMission = missionQueue.Dequeue();
            Debug.Log("Mision completada: " + completedMission.Name);
        }
        else
        {
            Debug.Log("Todas las misiones han sido completadas");
        }
    }
}

public class Mission
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    public Mission(string name, string description)
    {
        Name = name;
        Description = description;
    }
}