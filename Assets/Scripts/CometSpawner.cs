using UnityEngine;
using UnityEngine.InputSystem;

public class CometSpawner : MonoBehaviour
{
    public InputActionReference action;
    public GameObject cometPF;
    public GameObject particleEffectPF;
    public GameObject spawnSoundPF;
    public Transform spawnPoint;
    public Transform attractor;
    public float gravity = 20f;

    void Start()
    {
        action.action.Enable();
        action.action.performed += (context) =>
        {
            SpawnComet();
        };
    }

    void SpawnComet()
    {
        GameObject comet = Instantiate(cometPF, spawnPoint.position, Quaternion.identity);
        CometOrbit orbit = comet.GetComponent<CometOrbit>();
        orbit.attractor = attractor;
        orbit.gravity = gravity;

        Vector3 relativePosition = spawnPoint.position - attractor.position;
        float distance = relativePosition.magnitude;
        Vector3 radialDirection = relativePosition.normalized;

        Vector3 controllerDirection = spawnPoint.forward;
        Vector3 adjustedDirection = (controllerDirection - Vector3.Dot(controllerDirection, radialDirection) * radialDirection).normalized;

        float speed = Mathf.Sqrt(gravity / distance);
        orbit.velocity = adjustedDirection * speed;

        if (particleEffectPF != null)
            Instantiate(particleEffectPF, spawnPoint.position, Quaternion.identity);

        if (spawnSoundPF != null)
            Instantiate(spawnSoundPF, spawnPoint.position, Quaternion.identity);
    }
}
