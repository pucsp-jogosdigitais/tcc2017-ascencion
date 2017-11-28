using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaScript : MonoBehaviour {

	public string dialogue;
	private DialogueManager dMan;

	[SerializeField]
	SpriteRenderer renderer;
	[SerializeField]
	Sprite[] idle;

	public bool raActive;
	float timecounter = 0;
	float idleindex = 0;
	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogueManager>();
	}

	// Update is called once per frame
	void Update () {
		IdleAnim ();
	}

	void IdleAnim()
	{
		timecounter += Time.deltaTime; // comeca a contar o tempo
		if (timecounter > 1) // passou 5 seg
		{
			idleindex += Time.deltaTime * 4; // * para acelerar a animação  , incrementa com o indice dos frames
			if (idleindex >= idle.Length) // nao permite o indice estourar o array
			{
				idleindex = 0;
			}
			renderer.sprite = idle[((int)idleindex)]; // troca o sprite dependendo do array
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "perso")
		{	
			raActive = true;
			renderer.sortingOrder = 0;
			dMan.ShowBox (dialogue);
		}
	}
}
