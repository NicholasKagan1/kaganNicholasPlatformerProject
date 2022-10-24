using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public Vector2 JumpForce = new Vector2(0, 300);

    public float moveSpeed = 8f;
    public Rigidbody2D Player;
    Vector2 movement;

    public GameObject Knife;
    public bool OnGround;

    public bool beenHit = false;
    public bool iframes = false;

    private float xMove;
    private float yMove;

    [SerializeField]
    private bool shouldJump;

    private Rigidbody2D Rb2d;
    // Start is called before the first frame update
    void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        shouldJump = (Input.GetKeyDown(KeyCode.W));

        if (shouldJump && !beenHit && OnGround)
        {
            Rb2d.velocity = Vector2.zero;
            Rb2d.AddForce(JumpForce);
        }
        Vector2 newposition = transform.position;
        newposition += new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0);
        transform.position = newposition;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Knife, transform.position, Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "Platform")
        {
            OnGround = true;
        }

        if (collision.transform.tag == "KillBox")
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 5);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "Enemy" && !iframes)
        {
            iframes = true;
            Invoke("iTime", 2);
        }
      
    
    }

    void iTime()
    {
        iframes = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "Platform")
        {
            OnGround = false;
            Debug.Log(true);
        }


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


