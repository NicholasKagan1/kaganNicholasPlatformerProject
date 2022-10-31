using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public float Score;
    public TMP_Text ScoreUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Coin")
        {
            Score++;
            ScoreUI.text = "Score: " + Score.ToString();
            Destroy(collision.gameObject);

        }
    }
}
