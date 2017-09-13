using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public float moveSpeed;
	private float moveVelocity;
	public float jumpHeight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	private bool doubleJumped;

	private Animator anim;

	private Rigidbody2D myRigidbody;

    public int curHealth;
    public int maxHealth = 100;
    //private LevelManager dead;

	public Transform firePoint;
	public GameObject pencil;


	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();

		myRigidbody = GetComponent<Rigidbody2D> ();

        curHealth = maxHealth;
	}

	//Occurs a certain amount of times per second
	void FixedUpdate (){

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (grounded)
        {
			doubleJumped = false;
		}

		anim.SetBool ("Grounded", grounded);

		//jumping and moving
		if(Input.GetKeyDown (KeyCode.Space) && grounded)
		{
			Jump();
		}

		if (Input.GetKeyDown (KeyCode.Space) && !doubleJumped && !grounded)
        {
			Jump ();
			doubleJumped = true;
		}

		moveVelocity = 0f;

		if(Input.GetKey (KeyCode.D))
		{
			moveVelocity = moveSpeed;
		}

		if(Input.GetKey (KeyCode.A))
		{
			moveVelocity = -moveSpeed;
		}

		if (Input.GetKeyDown (KeyCode.LeftShift)) 
		{
            StartCoroutine("ShootingCo");
        }

        myRigidbody.velocity = new Vector2 (moveVelocity, myRigidbody.velocity.y);

		anim.SetFloat ("Speed", Mathf.Abs(myRigidbody.velocity.x));

		if (myRigidbody.velocity.x > 0.1)
			transform.localScale = new Vector3 (1f, 1f, 1f);
		else if (myRigidbody.velocity.x < -0.1)
			transform.localScale = new Vector3 (-1f, 1f, 1f);
	
        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if(curHealth <= 0)
        {
            //dead.RespawnPlayer();
        }

	}

       public void Jump()
	{
		myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpHeight);
	}

    public void Damage(int dmg)
    {
        curHealth -= dmg;
    }

    public IEnumerator ShootingCo()
    {
        anim.SetBool("Shoot", true);
        yield return new WaitForSeconds(0.3f);
        Instantiate(pencil, firePoint.position, firePoint.rotation);
        anim.SetBool("Shoot", false);
    }
}
