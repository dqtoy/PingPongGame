using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private BoxCollider2D rightWall;
    private BoxCollider2D leftWall;
    private BoxCollider2D topWall;
    private BoxCollider2D botWall;
    private int score1;
    private int score2;

    public Text Score1;
    public  Text Score2;

    public Transform player1;
    public Transform player2;

    private static GameManager _instance;
    public  static GameManager Instance{
        get
        {
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        
        WallController();
        RestPlayer();
    }

    void WallController()
    {
        rightWall = transform.Find("rightWall").GetComponent<BoxCollider2D>();
        leftWall = transform.Find("leftWall").GetComponent<BoxCollider2D>();
        topWall = transform.Find("topWall").GetComponent<BoxCollider2D>();
        botWall = transform.Find("botWall").GetComponent<BoxCollider2D>();

        float width = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        float height = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;

        topWall.transform.position =  new Vector3(0,height+ 0.5f,0);
        topWall.size = new Vector2(width*2,1);

        botWall.transform.position = new Vector3(0, -height-0.5f, 0);
        botWall.size = new Vector2(width*2,1);

        rightWall.transform.position =  new Vector3(width+0.5f, 0, 0);
        rightWall.size = new Vector2(1, height*2);

        leftWall.transform.position = new Vector3(-width-0.5f, 0, 0);
        leftWall.size = new Vector2(1, height*2);


    }

    void RestPlayer()
    {
        Vector3 player1Pos = Camera.main.ScreenToWorldPoint(new Vector3(100,Screen.height/2,0));
        player1Pos.z = 0;
        player1.position = player1Pos;
        Vector3 player2Pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width- 100, Screen.height / 2, 0));
        player2Pos.z = 0;
        player2.position = player2Pos;
    }

    public void ChangeScore(string name)
    {
        if(name == "rightWall")
        {
            score1++;
        }
        else if(name == "leftWall")
        {
            score2++;
        }

        Score1.text = score1.ToString();
        Score2.text = score2.ToString();

    }

    public void Reset()
    {
        score1 = score2 = 0;
        Score1.text = score1.ToString();
        Score2.text = score2.ToString();
        GameObject.Find("Ball").SendMessage("Reset");

    }
}

