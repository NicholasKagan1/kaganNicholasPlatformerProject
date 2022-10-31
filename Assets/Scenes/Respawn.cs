using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameController gController;

    public void Start()
    {
        gController = GameObject.FindObjectOfType<GameController>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {


        GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody2D>().velocity, 12f);
        GetComponent<Rigidbody2D>().velocity *= 1.1f;




      
    }


}
