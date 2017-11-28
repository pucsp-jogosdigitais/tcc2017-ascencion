using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ESTADOANIM {IDLE=1,WALK=2,JUMP=3,ATTACK=5,DEAD=6};
	

public class SpriteControl : MonoBehaviour
{
    [SerializeField]
    private Stat atributos;
    [SerializeField]
    SpriteRenderer renderer;
    [SerializeField]
    Sprite idle; //permite a unity exibir a variavel 
    [SerializeField]
    Sprite[] boring; // ao inves de usar public
    [SerializeField]
    Sprite[] walk;
    [SerializeField]
    Sprite[] run;
    [SerializeField]
    Sprite[] jumpanim;
	[SerializeField]
	Sprite[] attack;
	[SerializeField]
	private GameObject gameOverUI;
	public ESTADOANIM estadoAnim = ESTADOANIM.IDLE;

    public GameObject[] cargas;

    public Invisibility invisivel;

    float timecounter = 0;
    float boringindex = 0;
    float walkindex = 0;
    float runindex = 0;
    float jumpindex = 0;
	public float attackindex = 0;
    //[SerializeField] 
    public float velocidadeX = 0;
    float jumpForce = 0;
    public bool jump = false;

    public Rigidbody2D rdb;


    // Use this for initialization
    void Start()
    {
		ESTADOANIM estadoAnim = ESTADOANIM.IDLE;
    }

    // Update is called once per frame
    void Update()
    {

        Turn();

        if (Mathf.Abs(rdb.velocity.x) > 0.01f) // se velocidade for menor q...  se personagem parado 
        {
			estadoAnim = ESTADOANIM.WALK;
           // if (Mathf.Abs(rdb.velocity.x) > 6)
           // {
           //     RunAnim();
           // }

           // else
           // {
                WalkAnim();
           // }
        }

        else  // se personagem andou
        {
			if(estadoAnim == ESTADOANIM.JUMP || estadoAnim == ESTADOANIM.WALK) estadoAnim = ESTADOANIM.IDLE;
        }

		IdleAnim();

        if (jump)
        {
			estadoAnim = ESTADOANIM.JUMP;
            JumpAnim();
            rdb.AddForce(new Vector2(0, jumpForce) * 15);
            jumpForce = Mathf.Lerp(jumpForce, 0, 0.5f);
        }
	
    }

    void FixedUpdate()
    {
        rdb.AddForce(new Vector2(velocidadeX * 10, 0));

        

    }

    void Awake()
    {
        invisivel = GetComponent<Invisibility>();
        invisivel.cargas = 0;
        atributos.Initialize();
    }

    public void SetVelocity(float vel)
    {
        velocidadeX = vel;
    }

    public void SetJump()
    {
        if (!jump)
        {
            jumpForce = 10;
            jump = true;

        }

    }

    void OnCollisionEnter2D(Collision2D col) // se colidir 
    {
        jump = false;
        if (col.gameObject.name.Contains("Enemy") && atributos.CurrentValue > 0)
        {
            atributos.CurrentValue -= 20;
            rdb.AddForce(new Vector2(-500, 0));
        }
        if (atributos.CurrentValue == 0)
        {
            Invoke("Morto", 1);
        }
        if(col.gameObject.name.Contains("Carga"))
        {
            if (invisivel.cargas <= 0)
            {
                invisivel.cargas++;
                cargas[0].SetActive(true);
            }
            Destroy(col.gameObject);
        }
		if (col.gameObject.name.Contains ("spike")) 
		{
			Invoke ("Morto",0);
		}

    }

    void Morto()
    {      
		this.rdb.constraints = RigidbodyConstraints2D.FreezeAll;
		gameOverUI.SetActive (true);
    }


    /// <summary>
    /// Essa funcao anima o perso dependendo da velocidade
    /// </summary>

    void WalkAnim()
    {
		if (estadoAnim != ESTADOANIM.WALK)
			return;
		
        timecounter = 0; // zera o contador de boring
        walkindex += Mathf.Abs(velocidadeX * 0.20f); // incrementa o indice da troca de animacao pela velocidade
        if (walkindex >= walk.Length) // nao permite estourar o array
        {

            walkindex = 0;
        }
        renderer.sprite = walk[((int)walkindex)]; // troca o sprite dependendo do array 

    }



   /* void RunAnim()
    {
        timecounter = 0; // zera o contador de boring
        runindex += Mathf.Abs(velocidadeX * 0.20f); // incrementa o indice da troca de animacao pela velocidade
        if (runindex >= run.Length) // nao permite estourar o array
        {
            runindex = 0;
        }
        renderer.sprite = run[((int)runindex)]; // troca o sprite dependendo do array 

    }*/




    /// <summary>
    /// essa funcao anima o idle e coloca o personagem em espera
    /// </summary>

    void IdleAnim()
    {
		if (estadoAnim != ESTADOANIM.IDLE)
			return;
		
        timecounter += Time.deltaTime; // comeca a contar o tempo
        if (timecounter > 1) // passou 5 seg
        {
            boringindex += Time.deltaTime * 4; // * para acelerar a animação  , incrementa com o indice dos frames
            if (boringindex >= boring.Length) // nao permite o indice estourar o array
            {
                boringindex = 0;
            }
            renderer.sprite = boring[((int)boringindex)]; // troca o sprite dependendo do array
        }

        else
        {
            renderer.sprite = idle; // chama o sprite padrao

        }
    }


    /// <summary>
    /// essa funcao é responsavel pelo flip de direta e esquerda
    /// </summary>

    void Turn()
    {
        if (velocidadeX > 0)
        {
            renderer.flipX = false;
        }

        if (velocidadeX < 0)
        {
            renderer.flipX = true;
        }
    }


    void JumpAnim()
    {
		if (estadoAnim != ESTADOANIM.JUMP)
			return;
        jumpindex += Time.deltaTime * 10;
        if (jumpindex >= jumpanim.Length) jumpindex = 0;
        renderer.sprite = jumpanim[(int)jumpindex];
    }
	int contanimacoes =0;
	public void AttackAnim()
	{
		if (estadoAnim != ESTADOANIM.ATTACK)
			return;
		
		attackindex += Time.deltaTime * 10;
		if (attackindex >= attack.Length) 
		{
			attackindex = attack.Length-1;
		}
		print ("animando ataque contagem="+contanimacoes++ + "  indiceAtaque="+attackindex + " !" );
		renderer.sprite = attack [(int)attackindex];
	

	}
}
