using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour {
   
    private float fillAmount;

    [SerializeField]
    private float lerpSpeed;

    [SerializeField]
    private Image vida;
    [SerializeField]
    private Text valueText;

    public float MaxVida { get; set; }

    public float Vida
    {
        set
        {
            string[] temp = valueText.text.Split(':');
            valueText.text = temp[0] + ": " + value;
            fillAmount = Map(value, 0, MaxVida, 0, 1);
        } 
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        HandleBar();
	}

    private void HandleBar()
    {
        if (fillAmount != vida.fillAmount)
        {
            vida.fillAmount = Mathf.Lerp(vida.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
        }
    }

    /// <summary>
    /// Faz o calculo da vida atual e transforma pra escala de 0~1 do unity
    /// ex
    /// (78-0) * (1-0) / (230-0) + 0
    /// 78*1/230 = 0,339
    /// </summary>
    /// <param name="vidaAtual"></param>
    /// <param name="vidaMin"></param>
    /// <param name="vidaMax"></param>
    /// <param name="outMin"></param>
    /// <param name="outMax"></param>
    /// <returns></returns>

    private float Map(float vidaAtual, float vidaMin, float vidaMax, float outMin, float outMax)
    {
        return (vidaAtual - vidaMin) * (outMax - outMin) / (vidaMax - vidaMin) + outMin;
        


    }
}
