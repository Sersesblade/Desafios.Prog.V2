using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjetoRepetidoConPool : MonoBehaviour
{

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoEspera;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoIntervalo;

    private ObjectPool objectPool;

    private void Awake()
    {
        objectPool = GetComponent<ObjectPool>();
    }


    void Start()
    {
        InvokeRepeating(nameof(GenerarObjetoLoop), tiempoEspera, tiempoIntervalo);
    }

    void GenerarObjetoLoop()
    {
        GameObject poolObject = objectPool.GetPoolObject();


        if (poolObject != null) {
            poolObject.transform.position = transform.position;
            poolObject.transform.rotation = Quaternion.identity;
            poolObject.SetActive(true);
        }

    }
}