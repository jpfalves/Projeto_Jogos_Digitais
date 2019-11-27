using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour {

    public GameSettings GameSettingsData;
    public float jumpForce;
	public Animator Anim;
    public Rigidbody2D rb;
    public BoxCollider2D cxcolisao;
	public char direcaotiro;
    private PlayMusic playMusic;                                        //Reference to PlayMusic script
    private float fastFadeIn = .02f;									//Very short fade time (10 milliseconds) to start playing music immediately without a click/glitch


    // Parâmetros da Animação
    public static int chao = Animator.StringToHash("chao");
	public static int move = Animator.StringToHash("move");
	public static int atk = Animator.StringToHash("atk");
    public static int damage = Animator.StringToHash("death");


    //Shoting

    public Transform spawnBullet;
    public GameObject bullet;

	//IsGround verify
	public Transform groundCheck;

	//[SerializeField]
	//public Vector3 offset = Vector2.zero;

	[SerializeField]
	public float radious = 12.0f;
	[SerializeField]
	public LayerMask mask;
	[SerializeField]
	public bool isGrounded;


	void Start()
    {
        Anim.SetBool(chao, true);
        Anim.SetBool(move, false);
        Anim.SetBool(atk, false);
        Anim.SetBool(damage, false);
        direcaotiro = 'D';
    }

    // Update is called once per frame
    void Update()
    {

		if (Input.GetButtonDown("Fire1"))
        {
            Anim.SetBool(atk, true);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            Anim.SetBool(atk, false);
        }

		if (isGrounded)
		{
			
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
		}
        Anim.SetBool(chao, isGrounded);
        Move(1.2f);
    }

	private void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, radious);
	}
	public void NoMove()
    {
        Anim.SetBool(move, false);
    }
    public void Move(float vel)
    {
        Anim.SetBool(move, false);
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * vel * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
            Anim.SetBool(move, true);
			direcaotiro= 'D';
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.right * vel * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
            Anim.SetBool(move, true);
			direcaotiro= 'E';
		}
    }

    public void Jump()
    {
		//Anim.SetBool(chao, false);
		rb.AddForce(new Vector2(0, jumpForce));
	}

    /*
	 * private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(groundCheck.position, radious);
	}
	*/

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Void")
        {
            Anim.SetBool(damage, true);
            GameController.lifeCount = 0;
        }

        if (colisor.gameObject.tag == "Enemyes")
        {
            Anim.SetBool(damage, true);
            GameController.lifeCount -= 1;
            PlayPlayerDeathSound();

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemyes")
        {
            Anim.SetBool(damage, false);
        }
    }

    public void PlayPlayerDeathSound()
    {
        //Fade up music nearly instantly without a click 
      //  playMusic.FadeUp(fastFadeIn);
        //Play second music clip from MenuSettings
      //  playMusic.PlaySelectedMusic(GameSettingsData.musicPlayerDeath);
    }

    public void SimpleAtk()
    {
        Vector3 direction = (direcaotiro == 'D') ? this.transform.localScale :
                                                   -this.transform.localScale;
        ObjectPull.GetInstance().Create(spawnBullet.position, Quaternion.identity,
                                                                       direction);

        //if (bullet != null)
        //{

        //    //if (direcaotiro == 'D')
        //    //{          
        //    //    var cloneBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);
        //    //    cloneBullet.transform.localScale = this.transform.localScale;
        //    //}
        //    //else
        //    //{
        //    //    var cloneBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);
        //    //    cloneBullet.transform.localScale = -this.transform.localScale;
        //    //}
        //}
    }

}
