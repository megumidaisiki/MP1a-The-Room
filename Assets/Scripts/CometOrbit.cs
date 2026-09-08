using UnityEngine;

public class CometOrbit : MonoBehaviour
{
    public float gravity = 20f;
    [HideInInspector] public Vector3 velocity;
    public Transform attractor;

    void Update()
    {
        Vector3 relativePosition = transform.position - attractor.position;
        float distance = relativePosition.magnitude;

        Vector3 acceleration = -gravity * relativePosition / Mathf.Pow(distance, 3);

        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }
}
