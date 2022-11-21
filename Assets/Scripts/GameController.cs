using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int Score;
    public int Lives;
    public TMP_Text TextBox;
    public TMP_Text TextBox2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        Score += 10;
        TextBox.text = "" + Score;

    }

    public void UpdateScorePlayer2()
    {
        Lives += 1;
        TextBox2.text = "" + Lives;
        if (Lives < 1)
        {
            //LoseGame();

        }
    }


}
