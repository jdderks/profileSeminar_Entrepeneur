using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothing;
    [SerializeField] private Vector3 offset;

    [SerializeField]
    private float minZoom = 2f;

    [SerializeField]
    private float maxZoom = 5f;

    private float zoomStep = 0.1f;

    private Vector3 velocity;
    private Vector3 desiredPos;
    private Vector3 smoothedPos;

    float speed;

    Camera cam;

    [SerializeField]
    private Rigidbody2D playerRigidBody2d;

    public Transform Target { get => target; set => target = value; }

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        speed = playerRigidBody2d.velocity.magnitude;

        transform.position = smoothedPos;
        float timePassed = Time.deltaTime;
    }

    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }

    private void Update()
    {
        desiredPos = new Vector3(target.transform.position.x + offset.x, target.transform.position.y + offset.y, target.transform.position.z + offset.z);
        smoothedPos = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothing * Time.deltaTime);
    }
}