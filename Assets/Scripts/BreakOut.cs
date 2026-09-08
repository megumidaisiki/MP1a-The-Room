using UnityEngine;
using UnityEngine.InputSystem;

public class BreakOut : MonoBehaviour
{
    public InputActionReference action;
    public Transform outsidePoint;
    public Transform insidePoint;
    private bool isOutside = false;

    void Start()
    {

        action.action.Enable();
        action.action.performed += (context) =>
        {
            Transform target = isOutside ? insidePoint : outsidePoint;

            transform.position = target.position;
            transform.rotation = target.rotation;

            isOutside = !isOutside;
        };
    }
}
