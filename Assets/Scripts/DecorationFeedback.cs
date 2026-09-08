using UnityEngine;
using UnityEngine.InputSystem;

public class DecorationFeedback : MonoBehaviour
{
    public InputActionReference action;
    public Transform decorations;
    public GameObject particleEffectPF;
    public GameObject spawnSoundPF;

    private int i = 0;

    void Start()
    {
        action.action.Enable();
        action.action.performed += (context) =>
        {
            if (decorations.childCount == 0) return;

            Transform decoration = decorations.GetChild(i);

            if (particleEffectPF != null)
                Instantiate(particleEffectPF, decoration.position, Quaternion.identity);

            if (spawnSoundPF != null)
                Instantiate(spawnSoundPF, decoration.position, Quaternion.identity);

            i = (i + 1) % decorations.childCount;
        };
    }
}
