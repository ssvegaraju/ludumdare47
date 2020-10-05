using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class MainMenuButton : MonoBehaviour
{
    public UnityEvent OnPressed;
    public UnityEvent OnHover;

    private Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Hover() {
        anim.SetTrigger("Hover");
        OnHover?.Invoke();
    }

    public void Press() {
        anim.SetTrigger("Press");
        OnPressed?.Invoke();
    }

    public void Deselect() {
        anim.SetTrigger("Deselect");
    }
}
