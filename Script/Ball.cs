using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rb2d;
    public float maxInitialAngle = 0.67f;
    public float moveSpeed = 1f;
    private float startX = 0f;
    public float maxStartY = 4f;
    public float speedMultiplier = 1.1f;



    private void Start()
    {

        GameManager.instance.onReset += ResetBall;
        GameManager.instance.gameUI.onStartGame += ResetBall;
    }

    private void ResetBall()
    {
        ResetBallPosition();
        InitialPush();
    }
    private void InitialPush()
    {
        Vector2 dir = Random.value < 0.5f ? Vector2.left : Vector2.right;
        dir.y = Random.Range(-maxInitialAngle, maxInitialAngle);
        rb2d.velocity = dir * moveSpeed;

    }
    private void ResetBallPosition()
    {
        float posY = Random.Range(-maxStartY, maxStartY);
        Vector2 position = new Vector2(startX, posY);
        transform.position = position;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();
        if (scoreZone != null)
        {
            gameManager.OnScoreZoneReached(scoreZone.id);
            GameManager.instance.screenshake.StartShake(0.33f, 0.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Paddle paddle = collision.collider.GetComponent<Paddle>();
        GameManager.instance.gameAudio.PlayPaddleSound();
        if (paddle != null)
        {
            rb2d.velocity *= speedMultiplier;
            GameManager.instance.screenshake.StartShake(Mathf.Sqrt(rb2d.velocity.magnitude) * 0.02f, 0.075f);
        }
        Wall wall = collision.collider.GetComponent<Wall>();
        if (wall)
        {
            GameManager.instance.gameAudio.PlayWallSound();
            GameManager.instance.screenshake.StartShake(0.033f, 0.033f);
        }


    }
}
