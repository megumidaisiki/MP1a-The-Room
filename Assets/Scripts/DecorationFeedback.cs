using UnityEngine;
using UnityEngine.InputSystem;

public class DecorationFeedback : MonoBehaviour
{
    public InputActionReference action;
    public Transform decorations;
    private int i = 0;

    void Start()
    {
        action.action.Enable();
        action.action.performed += (context) =>
        {
            if (decorations.childCount == 0) return;

            Transform decoration = decorations.GetChild(i);
            DecorationEffect effect = decoration.GetComponent<DecorationEffect>();

            if (effect != null)
            {
                if (effect.particleEffectPF != null)
                    Instantiate(effect.particleEffectPF, decoration.position, Quaternion.identity);

                if (effect.soundEffectPF != null)
                    Instantiate(effect.soundEffectPF, decoration.position, Quaternion.identity);
            }

            i = (i + 1) % decorations.childCount;
        };
    }
}
