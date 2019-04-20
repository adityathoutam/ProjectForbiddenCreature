using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Basic Player Script//
//controls: 
//A, D, Left, Right to move
//Left Alt to attack
//Space to jump
//Z is to see dead animation

public class Demo : MonoBehaviour {

	//variable for how fast player runs//
	private float speed = 5f;

	private bool facingRight = true;
	private Animator anim;
	public bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	//variable for how high player jumps//
	[SerializeField]
	private float jumpForce = 300f;

	public Rigidbody2D rb { get; set; }

	bool dead = false;
	bool attack = false;


    public GameObject weapon;

    public GameObject blank;
    Animator imganim;

    private Touch touch;

	void Start () {
		GetComponent<Rigidbody2D> ().freezeRotation = true;
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponentInChildren<Animator> ();
        imganim = blank.GetComponent<Animator>();


        weapon.SetActive(false);
    }

	void Update()
	{
		HandleInput ();
        HandleTouchInput();
	}

	//movement//
	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		float horizontal = Input.GetAxis("Horizontal");
		if (!dead && !attack)
		{
			anim.SetFloat ("vSpeed", rb.velocity.y);
			anim.SetFloat ("Speed", Mathf.Abs (horizontal));
			rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);
		}
		if (horizontal > 0 && !facingRight && !dead && !attack) {
			Flip (horizontal);
		}

		else if (horizontal < 0 && facingRight && !dead && !attack){
			Flip (horizontal);
		}
	}

	//attacking and jumping//
	private void HandleInput()
	{
		if (Input.GetKeyDown (KeyCode.LeftControl) && !dead) 
		{
			attack = true;
			anim.SetBool ("Attack", true);
			anim.SetFloat ("Speed", 0);

		}
		if (Input.GetKeyUp(KeyCode.LeftControl))
			{
			attack = false;
			anim.SetBool ("Attack", false);
			}

		if (grounded && Input.GetKeyDown(KeyCode.Space) && !dead)
		{
			anim.SetBool ("Ground", false);
			rb.AddForce (new Vector2 (0,jumpForce));
		}

		////dead animation for testing//
		//if (Input.GetKeyDown (KeyCode.Z)) 
		//{
		//	if (!dead) {
		//		anim.SetBool ("Dead", true);
		//		anim.SetFloat ("Speed", 0);
		//		dead = true;
		//	} else {
		//			anim.SetBool ("Dead", false);
		//			dead = false;
		//		}
		//}
	}

    private void HandleTouchInput()
    {
        float starttime;
        float endtime;

        Vector2 startPos;
        Vector2 endPos;

        bool istationary;


        if (touch.phase == TouchPhase.Began)
        {
            starttime = Time.time;
            startPos = touch.position;
        }
        if(touch.phase == TouchPhase.Stationary)
        {
            istationary = true;

            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
            anim.SetBool("Ground", grounded);

            float horizontal = Input.GetAxis("Horizontal");
            if (!dead && !attack)
            {
                anim.SetFloat("vSpeed", rb.velocity.y);
                anim.SetFloat("Speed", Mathf.Abs(horizontal));
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            }
            if (horizontal > 0 && !facingRight && !dead && !attack)
            {
                Flip(horizontal);
            }

            else if (horizontal < 0 && facingRight && !dead && !attack)
            {
                Flip(horizontal);
            }
        }
        else if(touch.phase == TouchPhase.Ended)
        {
            endtime = Time.time;
            endPos = touch.position;
        }
    }

    IEnumerator Fade()
    {
        imganim.SetBool("FadeIn", true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bat")
        {
            collision.gameObject.SetActive(false);
            weapon.SetActive(true);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fenemy")
        {
            anim.SetBool("Dead", true);
            blank.SetActive(true);
            Scene scene = SceneManager.GetActiveScene();
            StartCoroutine(Fade());
            //SceneManager.LoadScene(0);

        }
        if (collision.gameObject.tag == "Archer")
        {
            anim.SetBool("Dead", true);
            blank.SetActive(true);
            Scene scene = SceneManager.GetActiveScene();
            StartCoroutine(Fade());
            //SceneManager.LoadScene(0);

        }
    }

    private void Flip (float horizontal)
	{
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
	}
}
