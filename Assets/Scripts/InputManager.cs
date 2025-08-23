using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput mPlayerInput;
    private PlayerInput.OnFootActions mOnFootActions;

    private PlayerController mPlayerController;

    private void Awake()
    {
        mPlayerInput = new PlayerInput();
        mOnFootActions = mPlayerInput.OnFoot;
        mPlayerController = GetComponent<PlayerController>();
        mOnFootActions.Jump.performed += ctx => mPlayerController.Jump();
    }

    private void FixedUpdate()
    {
        mPlayerController.ProcessLook(mOnFootActions.Look.ReadValue<Vector2>());
        mPlayerController.ProcessMove(mOnFootActions.Movement.ReadValue<Vector2>());
        mPlayerController.LookCast();
    }

    private void Update()
    {
        if (mOnFootActions.Interact.triggered)
        {
            Debug.Log("Attempt to trigger");
            if (mPlayerController.mLastObjectLookedAt)
            {
                Interactable interactable = mPlayerController.mLastObjectLookedAt.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }

    private void LateUpdate()
    {

    }

    private void OnEnable()
    {
        mOnFootActions.Enable();
    }

    private void OnDisable()
    {
        mOnFootActions.Disable();
    }
}
