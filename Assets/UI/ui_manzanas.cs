using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ui_manzanas : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI textManzana;
    //[SerializeField] private GameObject panelFinalStage;
    private int totalManzanas;
    private int totalActualManzanas = 0;
    void Start()
    {

        totalManzanas = GameObject.FindGameObjectsWithTag("manzana").Length;
        textManzana.text = "Total Manzanas: "+ totalActualManzanas+" / "+ totalManzanas;
    }

    public bool addManzana()
    {
        totalActualManzanas++;
        refreshUI();
        if (totalActualManzanas >= totalManzanas)
        {
            //print("etapa terminada");|
            //panelFinalStage.SetActive(true);
            return false;
        }
        return true;
    }

    private void refreshUI()
    {
        textManzana.text = "Total Manzanas: " + totalActualManzanas + " / " + totalManzanas;
    }
}
