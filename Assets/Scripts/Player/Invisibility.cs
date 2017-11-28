using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Invisibility : MonoBehaviour
{
    public bool invisible = false;

    private SpriteRenderer spriteRenderer;

    private SpriteControl spritecontrol;
    public int cargas;
    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spritecontrol = GetComponent<SpriteControl>();
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E)  && cargas > 0)
        {
            Invisivel();
            cargas--;
            spritecontrol.cargas[0].SetActive(false);
        }


    }

    void Invisivel()
    {

        if (!invisible)
        {
            invisible = true;
            gameObject.layer = 14;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            Invoke("Reset", 5);
            StartCoroutine(IndicaFim());

        }
    }

    void Reset()
    {
        invisible = false;
        gameObject.layer = 0;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }

    private IEnumerator IndicaFim()
    {
        yield return new WaitForSeconds(4f);
        for (var n = 0; n < 5; n++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(.07f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(.07f);
        }

    }


    /*  private IEnumerator IndicaFim()
   
      {
          while (invisible)
          {
              spriteRenderer.enabled = false;
              yield return new WaitForSeconds(.1f);
              spriteRenderer.enabled = true;
              yield return new WaitForSeconds(.1f);
          }
      }  */

}


