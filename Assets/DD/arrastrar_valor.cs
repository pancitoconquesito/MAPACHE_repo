using UnityEngine;

public class arrastrar_valor : MonoBehaviour
{
    private bool valor;
    public void setValor(bool newValor)
    {
        valor = newValor;
    }
    public bool getValor()
    {
        return valor;
    }
}
