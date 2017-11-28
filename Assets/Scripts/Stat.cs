using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stat
{
    [SerializeField]
    private BarraVida barra;
    [SerializeField]
    private float maxVal;
    [SerializeField]
    private float currentVal;
    [SerializeField]
    private int numCarga;

    public float CurrentValue
    {
        get 
        { 
            return currentVal; 
        }
        set 
        {
            this.currentVal = Mathf.Clamp(value, 0, MaxValue);
            barra.Vida = currentVal; 
        }
    }
    public float MaxValue
    {
        get 
        {
            return maxVal; 
        }
        set 
        { 
            this.maxVal = value;
            barra.MaxVida = maxVal;
        }

    }
    public void Initialize()
    {
        this.numCarga = 0;
        this.MaxValue = maxVal;
        this.CurrentValue = currentVal;
    }
}
