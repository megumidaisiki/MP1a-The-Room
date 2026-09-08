using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchLight : MonoBehaviour
{
    public InputActionReference action;
    public Light light;
    private Color[] colors = {Color.white, Color.red, Color.yellow, Color.blue};
    private int i = 0;

    void Start()
    {
        light = GetComponent<Light>();
        light.color = colors[i];
        action.action.Enable();
        action.action.performed += (context) =>
        {
            i = (i + 1) % colors.Length;
            light.color = colors[i];
        };
    }
}
