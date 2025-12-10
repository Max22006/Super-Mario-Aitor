using UnityEngine;

public class PrimerScript : MonoBehaviour
{
    private int numeroEntero = 5;
    private float numeroDecimal = 7.5f;
    private double decimalLargo = 8.4;
    private bool verdaderoFalso = true; 
    private string cadenaTexto = "Hola";
    private char letra = 'a';
    //comentarios
     
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numeroEntero = 37;

        cadenaTexto = "Hola Mundo";

        Debug.Log(cadenaTexto);
        Debug.Log(numeroEntero);

        Calculo();
    }
    void Calculo()
    {
        numeroEntero = 7 + 5;
        numeroEntero = 2 - 7;
        numeroEntero = 4 * 9;
        numeroEntero = 4 / 3;

        numeroEntero = numeroEntero + 2;
        numeroEntero += 2;
        numeroEntero++;//= numeroEntero += 1;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
