using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lista_ProgressionSystem : MonoBehaviour
{
    public List<GameObject> unlockableObjects;
    private List<bool> unlockedObjects;

    void Start()
    {
        unlockedObjects = new List<bool>(new bool[unlockableObjects.Count]);

        for (int i = 0; i < unlockableObjects.Count; i++)
        {
            unlockableObjects[i].SetActive(false);
        }
    }

    public void UnlockObject(int index)
    {
        if (index >= 0 && index < unlockableObjects.Count)
        {
            unlockableObjects[index].SetActive(true);
            unlockedObjects[index] = true;
        }
    }

    public bool IsObjectUnlocked(int index)
    {
        if (index >= 0 && index < unlockedObjects.Count)
        {
            return unlockedObjects[index];
        }
        return false;
    }
}
