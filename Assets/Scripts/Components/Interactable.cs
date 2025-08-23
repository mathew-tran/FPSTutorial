using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected abstract void Interact();
    public void BaseInteract()
    {
        Interact();
    }
}
