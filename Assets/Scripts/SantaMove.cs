using UnityEngine;

public class SantaMove : MonoBehaviour {
    [SerializeField]
    GameObject fireobject;

   [SerializeField]  float speed;
   [SerializeField]  float jumppower;
   [SerializeField]  Transform groundCheck;
   [SerializeField]  LayerMask whatIsGround;
   [SerializeField]  bool Grounded;
   [SerializeField]  float groundRadius;
   [SerializeField]  Transform firepos;
   [SerializeField]  float speedIncrease;
   [SerializeField]  float timetoincreaseSpeed;
   [SerializeField] AudioSource audio;
   [SerializeField] AudioClip time;
   [SerializeField] AudioClip jump;

    float timetoincreaseSpeedCounter;
    Rigidbody2D rb;
    Animator anim;
    bool doublejump = false;
    public santaDead dead;
    public GameManager GM;
    public ShowAds ads;


    void Start()
    {
       
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
       
        timetoincreaseSpeedCounter = timetoincreaseSpeed;  
    }
    void Update()
    {

        // Grounded = Physics2D.IsTouchingLayers(col, whatIsGround);
        Grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Jump", Grounded);
    } 

    void FixedUpdate()
    {
        if(dead.isDead==false)
        {
            Move();
        }
          
       
    }
  //move the player;
    void Move()
    {
        if (dead.isDead == false)
        {
            if(transform.position.x > timetoincreaseSpeedCounter)
            {
                timetoincreaseSpeedCounter += timetoincreaseSpeed;
                timetoincreaseSpeed = timetoincreaseSpeed * speedIncrease;
                speed = speed * speedIncrease;
            }
            rb.velocity = new Vector2(speed, rb.velocity.y);


            if (( Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1")) && (Grounded || !doublejump))
            {
                
                rb.velocity = new Vector2(rb.velocity.x + 2, jumppower);
                if (!Grounded)
                    doublejump = true;
                audio.PlayOneShot(jump);
            }
            if (Grounded)
                doublejump = false;
        }
       
      
    }

  
    //add score or kill the player depand upon what he collided with;
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="Score")
        {
            GM.TimerIncrease();
            audio.PlayOneShot(time);
            Destroy(col.gameObject);

        }else if(col.gameObject.tag=="Enemy")
        {
           this.rb.velocity = Vector2.zero;
            ads.Show();
            anim.SetTrigger("SantaDead");
           dead.anim.SetTrigger("dead");
           dead.OnDead();
           
          
        }else if(col.gameObject.tag=="gifts")
        {
            int power = 2;
            GM.ScoreIncrease(power);
          
            Destroy(col.gameObject);
        }
    }
    

    
  
}
