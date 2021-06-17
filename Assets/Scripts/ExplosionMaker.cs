using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionMaker : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;

    Vector3 worldPosition;
    [SerializeField] Camera cam;

    [SerializeField] private GameObject explosionPrefab;

    void Start()
    {

    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.nearClipPlane;
        worldPosition = cam.ScreenToWorldPoint(mousePos);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Explode(worldPosition);
        }
    }


    public void Explode(Vector2 point)
    {
        Debug.Log("Explosion");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(point, radius);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody2D rb = colliders[i].GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Instantiate(explosionPrefab, point, Quaternion.identity);
                rb.AddExplosionForce(power, point, radius);
            }
        }

    }

    

}