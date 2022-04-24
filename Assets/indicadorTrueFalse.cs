using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicadorTrueFalse : MonoBehaviour
{
    [SerializeField]private bool valor;
    public void setBool(bool _valor)
    {
        valor = _valor;
    }
    public bool getValor()
    {
        return valor;
    }
}
