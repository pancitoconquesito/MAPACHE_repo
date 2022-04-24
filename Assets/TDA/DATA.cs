using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DATA : MonoBehaviour
{
    public static DATA instance;
    //[SerializeField]private DATA_flaite dataFlaite;
    [SerializeField] private int intentosDeBusqueda;


    [SerializeField] private TYPE_if_A[] LISTA_IF_A;
    [SerializeField] private float[] LISTA_IF_A_probabilidad;

    [Header("-- A --")]
    [SerializeField] private int cantOpciones_A;


    [SerializeField] private int total_MAX_Facil;
    private int countFacil = 0;





    [Header("-- IF_B --")] 
    [SerializeField] private TYPE_if_B[] LISTA_IF_B;
    [SerializeField] private float[] LISTA_IF_B_probabilidad;





    [SerializeField] private List<int> indicesPreguntasSelect;
    public void addCountFacil() { countFacil++; }
    public bool sePuedeGetFacil() { return countFacil < total_MAX_Facil; }
    private void Awake()
    {
        instance = this;    
    }
   
    void Start()
    {
        //TODO
        //setListaProbabilidades
        indicesPreguntasSelect = new List<int>();
    }

    public int getLength_TIPO_A()
    {
        return LISTA_IF_A.Length;
    }
    public int getCantOPciones_TIPO_A()
    {
        return cantOpciones_A;
    }
    public TYPE_if_A getTipoA()
    {
        TYPE_if_A returnQuestion=null;
        int countIntentos = 0;
        bool complete = false;
        while (!complete)
        {
            int indiceRandom = Random.Range(0, LISTA_IF_A.Length);
            TYPE_if_A currentQuestion = LISTA_IF_A[indiceRandom];
            float probabilidadRandom = Random.Range(0.05f,1f);
            if(LISTA_IF_A_probabilidad[indiceRandom] > probabilidadRandom)
            {//nuevo o muchas malas
                returnQuestion= currentQuestion;
                complete = true;
            }
            else
            {
                countIntentos++;
                if (countIntentos >= intentosDeBusqueda)
                {
                    returnQuestion = currentQuestion;
                    complete = true;
                }
            }
            if(isSelected(currentQuestion._ID)) complete = false;
        }
        addIndice(returnQuestion._ID);
        return returnQuestion;
    }
    private void addIndice(int indice)
    {
        indicesPreguntasSelect.Add(indice);
    }
    private bool isSelected(int idPregunta)
    {
        return indicesPreguntasSelect.Contains(idPregunta);
    }
    public TYPE_if_B getTipoB()
    {
        TYPE_if_B returnQuestion = null;
        int countIntentos = 0;
        bool complete = false;
        while (!complete)
        {
            int indiceRandom = Random.Range(0, LISTA_IF_B.Length);
            TYPE_if_B currentQuestion = LISTA_IF_B[indiceRandom];
            float probabilidadRandom = Random.Range(0.05f, 1f);
            if (LISTA_IF_B_probabilidad[indiceRandom] > probabilidadRandom)
            {//nuevo o muchas malas
                returnQuestion = currentQuestion;
                complete = true;
            }
            else
            {
                countIntentos++;
                if (countIntentos >= intentosDeBusqueda)
                {
                    returnQuestion = currentQuestion;
                    complete = true;
                }
            }
            if (isSelected(currentQuestion._ID)) complete = false;
        }
        addIndice(returnQuestion._ID);
        return returnQuestion;
    }
}
