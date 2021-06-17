using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int resetTime = 50;
    private int defaultResetTime;

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
