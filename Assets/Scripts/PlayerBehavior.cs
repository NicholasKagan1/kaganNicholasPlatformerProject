using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public Vector2 jumpForce = new Vector2(0, 300);

    public float moveSpeed = 8f;
    public Rigidbody2D Player;
    Vector2 movement;

    public bool OnGround;

    private bool beenhit = false;

    private float xMove;
    private float yMove;

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        bool shouldJump = (Input.GetKeyDown(KeyCode.Space));

        if (shouldJump && !beenhit && OnGround)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(jumpForce);
        }
        Vector2 newposition = transform.position;
        newposition += new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0);
        transform.position = newposition;
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


