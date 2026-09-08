using System;
using UnityEngine;

public class OrbitingComet : MonoBehaviour
{
    public float gravity = 20f;
    public Vector3 velocity = new Vector3(0f, 0f, 2f);
    public Transform attractor;

    void Update()
    {
        Vector3 position = transform.position - attractor.position;
        float distance = position.magnitude;
        Vector3 acceleration = -gravity * position / Mathf.Pow(distance, 3);
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }
}
