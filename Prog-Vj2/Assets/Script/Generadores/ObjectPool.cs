using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject o_Prefab;
    [SerializeField] private int p_Size = 5;

    private List<GameObject> p_List;


    private void Start()
    {
           p_List = new List<GameObject>();

        for (int i = 0; i < p_Size; i++)
        {
            GameObject obj = Instantiate(o_Prefab);

            //Al objeto instanciado le asigno el tag Proyectil.
            obj.tag = "Proyectil";
            obj.SetActive(false);
            p_List.Add(obj);
        }

    }

    public GameObject GetPoolObject()
    {
        foreach (GameObject obj in p_List)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null;
    }
}
