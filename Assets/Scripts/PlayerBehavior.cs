using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBehavior : MonoBehaviour
{
    public Vector2 JumpForce = new Vector2(0, 300);
    public LayerMask BoxcastFilter;
    private float moveSpeed = 8f;
    public Rigidbody2D Player;
    Vector2 movement;
    public float Lives;
    public TMP_Text LivesUI;
    public Transform FirePoint;
    public float KnifeThrow = 20f;
    public SpriteRenderer Reverse;
    public GameObject LoseImage;
    public GameObject Knife;
    public bool OnGround;
    public float BoxcastDistance;

    public bool BeenHit = false;
    public bool Iframes = false;

    private float xMove;
    private float yMove;

    [SerializeField]
    private bool shouldJump;

    private Rigidbody2D rb2d;
    private BoxCollider2D myCollider;
    private Vector2 boxcastSize;

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        Reverse = GetComponent<SpriteRenderer>();
        boxcastSize = new Vector2(myCollider.size.x - 0.5f, myCollider.size.y);
    }


    void Update()
    {
        shouldJump = (Input.GetKeyDown(KeyCode.W));

        if (shouldJump && !BeenHit && OnGround)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(JumpForce);
        }
        Vector2 newposition = transform.position;
        newposition += new Vector2(Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime, 0);
        transform.position = newposition;


       var hit = Physics2D.BoxCast(transform.position, boxcastSize, 0, Vector2.down, BoxcastDistance, BoxcastFilter );
        if(hit.transform == null)
        {
            OnGround = false;
        }
        else
        {
            OnGround = true;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //var Item = Instantiate(Knife, transform.position, Quaternion.identity);
            //Item.GetComponent<Rigidbody2D>().AddForce(transform.right * 3, ForceMode2D.Impulse);

            GameObject Shadow = Instantiate(Knife, FirePoint.position, FirePoint.rotation);
            Rigidbody2D rb = Shadow.GetComponent<Rigidbody2D>();
            if (Reverse.flipX)
            {
                rb.AddForce(FirePoint.up * -KnifeThrow, ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(FirePoint.up * KnifeThrow, ForceMode2D.Impulse);
            }

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Reverse.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Reverse.flipX = false;
        }
    }

    public void LoseGame()
    {
        LoseImage.SetActive(true);
        MoveSpeed = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
     

        if (collision.transform.tag == "KillBox")
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y + 5);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Lives--;
            LivesUI.text = "Lives: " + Lives.ToString();
            if (Lives < 1)
            {
                LoseGame();

            }

        }

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "Enemy" && !Iframes)
        {
            Iframes = true;
            Invoke("iTime", 5);
        }
      
    
    }

    void iTime()
    {
        Iframes = false;
    }
 


    // Update is called once per frame


    /*void FixedUpdate()
    {
        bool shouldJump = (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonDown(0));
        if (shouldJump && (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            rb2d.velocity = Vector2.zero;
        }

        Vector2 movement = new Vector2();
        xMove = Input.GetAxis("Horizontal");
        movement.x += xMove * 1 * Time.deltaTime;
        //Hmovement.x = Mathf.Clamp(Hmovement.x, -12.8f, 11.8f);

        yMove = Input.GetAxis("Vertical");
        movement.y += yMove * 1 * Time.deltaTime;
        //Vmovement.y = Mathf.Clamp(Vmovement.y, -8.4f, 8.8f);
        transform.position = movement;

    }*/
}


