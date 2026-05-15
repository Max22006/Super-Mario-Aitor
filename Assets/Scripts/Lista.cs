using UnityEngine;
using System.Collections.Generic;

public class Lista : MonoBehaviour
{
    private List<int> listaDeNumeros = new List<int> {7, 8, 10, 45};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         listaDeNumeros.Add(9); //añade elemento al final de la lista
        listaDeNumeros.Remove(7); //elimina el elemento que esta entre los parentesis
        listaDeNumeros.RemoveAt(0); //elimina el elemento en esa posicion, el 0 elimina el primer elemnto el 1 el segundo ...
        listaDeNumeros.Clear(); //elimina todos los elementos de la lista
        listaDeNumeros.Reverse(); // invierte el orden de la lista
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
