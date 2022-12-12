using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillboxBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public Enemy EnemyBehavior;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyBehavior.IsFlip != true)
        {
            GetComponent<BoxCollider2D>().offset = new Vector2(0.65f, 0);

        }
        else 
        {
            GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);
        }
    }
}
