using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed = 30;

    private Rigidbody2D rigidBody;

    private AudioSource audioSouce;

	// Use this for initialization
	void Start () {

        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * speed;
	}

     void OnCollisionEnter2D(Collision2D col)
    {
        //leftPaddle or RihtPaddle
        if((col.gameObject.name == "LeftPaddle") || 
            col.gameObject.name == "RightPaddle")
        {
            HandlePaddleHit(col);
        }

        //WallBottom oy WallTop
        if ((col.gameObject.name == "WallBottom") ||
            col.gameObject.name == "WallTop")
        {

            SoundManager.Instace.PlayOneShot(SoundManager.Instace.wallBloop);
        }
        //LeftGoal or RightGoal
        if ((col.gameObject.name == "leftGoal") ||
            col.gameObject.name == "RightGoal")
        {
            SoundManager.Instace.PlayOneShot(SoundManager.Instace.goalBloop);

            // TODO upadate Score UI

            transform.position = new Vector2(0,0);
        }
    }

    void HandlePaddleHit(Collision2D col)
    {

        float y = BallHitPaddleWhere(transform.position,
            col.transform.position,
            col.collider.bounds.size.y);

        Vector2 dir = new Vector2();

        if(col.gameObject.name == "LeftPaddle")
        {
            dir = new Vector2(1, y).normalized;
        }
        if (col.gameObject.name == "RightPaddle")
        {
            dir = new Vector2(-1, y).normalized;
        }

        rigidBody.velocity = dir * speed;

        SoundManager.Instace.PlayOneShot(SoundManager.Instace.hitPaddleBloop);
    }

    float BallHitPaddleWhere(Vector2 ball, Vector2 paddle, float paddleHeight)
    {
        return (ball.y = paddle.y / paddleHeight);
    }
}
