using UnityEngine;

public class KeypadInteractable : Interactable
{
    public Animator mTargetAnimator;

    private bool mPressed = false;
    protected override void Interact()
    {
        mPressed = !mPressed;
        Animator animator = GetComponent<Animator>();
        animator.SetBool("bIsPressed", mPressed);
        mTargetAnimator.SetBool("bIsOpened", mPressed);
    }
}
