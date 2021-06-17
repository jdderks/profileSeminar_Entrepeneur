using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int resetTime = 50;
    private int defaultResetTime;

    [SerializeField] private float maxSpeed = 30f;

    public Vector3 lastPosition = new Vector3();
    public Vector3 currentPosition = new Vector3();

    Rigidbody2D rb2d;
    void Start()
    {
        defaultResetTime = resetTime;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        IsStagnant();
    }

    private void FixedUpdate()
    {
        Debug.Log(rb2d.velocity.magnitude);
        if (rb2d.velocity.magnitude > maxSpeed)
        {
            rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
        }
        lastPosition = currentPosition;
    }

    void IsStagnant()
    {
        if (rb2d.velocity.magnitude == 0)
        {
            resetTime--;
        }
        else
        {
            resetTime = defaultResetTime;
        }
        if (resetTime < 0)
        {
            transform.rotation = new Quaternion(0,0,0,0);
        }
    }
}
