using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] MovewithMouse paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 10f;
    
    AudioSource myAudioSouce;
    Vector2 paddleToBallVector;
    bool hasStarted = false;
    
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSouce = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        
    }

    private  void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            //AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSouce.Play();
        }
    }
}
