using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    public int Duration = 3;
    public bool IsFlip = true;
    public int MaxHealth = 90;
    public GameObject WinImage;
    int CurrentHealth;
    // Start is called before the first frame update
    void Start()
    {
        Speed = 3;
        InvokeRepeating("Reverse", Duration, Duration);
        CurrentHealth = MaxHealth;
    }

    public void damage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Death();
        }
            
    }

    void Death()
    {
        Debug.Log("Enemy Killed");
        if(this.name == "King")
        {
            WinImage.SetActive(true);
            PlayerBehavior PB = GameObject.FindObjectOfType<PlayerBehavior>();
            PB.MoveSpeed = 0;
        }
        //GetComponent<KillboxBehavior>().enabled = false;
        //GetComponent<Respawn>().enabled = false;
        Destroy(this.gameObject);
        this.enabled = false;
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
        IsFlip = !IsFlip;


    }
}
