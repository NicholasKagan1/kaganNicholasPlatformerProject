using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KnifeDelete : MonoBehaviour
{
    public int AttackEnemy = 30;
    public Transform Hit;
    public float AttackRange = 0.5f;
    public LayerMask EnemyLayers;
    public float Score;
    public TMP_Text ScoreUI;
    // Start is called before the first frame update
    void Update()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Hit.position, AttackRange, EnemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().damage(AttackEnemy);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Score++;
            //ScoreUI.text = "Score: " + Score.ToString();
            Debug.Log("this worked");
            Destroy(gameObject);


        }
        if (collision.gameObject.tag == "Platform")
        {
            //Score++;
            //ScoreUI.text = "Score: " + Score.ToString();
            Debug.Log("this worked");
            Destroy(gameObject);
        }
    }
}