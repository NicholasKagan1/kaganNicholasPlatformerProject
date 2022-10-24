using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    public int Duration = 3;
    // Start is called before the first frame update
    void Start()
    {
        Speed = 3;
        InvokeRepeating("Reverse", Duration, Duration);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + Speed * Time.deltaTime, transform.position.y);
    }

    void Reverse()
    {
        Speed *= -1;
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    }
}
