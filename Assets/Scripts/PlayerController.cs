using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4;
    public KeyCode upkey;
    public KeyCode downkey;


    private AudioSource audioClip;
    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        audioClip = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(upkey))
        {
            rigidBody.velocity = new Vector2(0,speed);
        }
        else if(Input.GetKey(downkey))
        {
            rigidBody.velocity = new Vector2(0, -speed);
        }
        else
        {
            rigidBody.velocity = new Vector2(0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ball")
        {
            audioClip.Play();
        }

    }
}
