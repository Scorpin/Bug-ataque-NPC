using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum codObjeto
{
    Pocion = 1,
    Pergaminos = 2,
    Monedas = 3,
    Esencia = 4,
    Llaves = 5
}

public class PickableObjectController : MonoBehaviour {

    public codObjeto tipoObjeto;

    void Start()
    {
        // TODO: instanciar el tipo de objeto
    }

    // Update is called once per frame
    void Update() {
        
    }
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Interactuando con el Objeto");

        switch (tipoObjeto)
        {
            case codObjeto.Pocion: usoPocion(); break;
            case codObjeto.Pergaminos: usoPergamino(); break;
            case codObjeto.Monedas: usoMonedas(); break;
            case codObjeto.Esencia: usoEsencia(); break;
            case codObjeto.Llaves: usoLlaves(); break;
        }
    }
    */
    // Metodos Privados para el comportamiento de cada objeto

    private void usoPocion()
    {
        // TODO: Implementar Uso de Pocion (Primero se ha de instanciar un sistema de PV)
    }

    private void usoPergamino()
    {
        // TODO: Implementar Uso de usoPergamino (Por poner)
    }

    private void usoMonedas()
    {
        // TODO: Implementar Uso de Monedas (Por poner)
    }

    private void usoEsencia()
    {
        // TODO: Implementar Uso de Esencia (Por poner)
    }

    private void usoLlaves()
    {
        // TODO: Implementar Uso de Llaves (Por poner) 
    }

}