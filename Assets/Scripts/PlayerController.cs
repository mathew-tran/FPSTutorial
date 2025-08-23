using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private CharacterController mController;
    private Vector3 mVelocity;
    public float mSpeed;

    private bool bIsGrounded = true;
    public float mGravity = -9.8f;
    public float mJumpStrength = 10.0f;

    public Camera mCamera;
    private float mXRotation = 0f;
    public float mXSensitivity = 30.0f;
    public float mYSensitivity = 30.0f;

    public UnityEvent<GameObject> OnObjectLookedAt;
    public GameObject mLastObjectLookedAt = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        bIsGrounded = mController.isGrounded;
    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        mXRotation -= (mouseY * Time.deltaTime) * mYSensitivity;
        mXRotation = Mathf.Clamp(mXRotation, -60.0f, 60.0f);

        mCamera.transform.localRotation = Quaternion.Euler(mXRotation, 0, 0);

        Vector3 newLookRotation = Vector3.up * (mouseX * Time.deltaTime) * mXSensitivity;

        transform.Rotate(newLookRotation);
    }

    public void LookCast()
    {
        RaycastHit hit;
        Ray landingRay = new Ray(mCamera.transform.position, mCamera.transform.forward);
        if (Physics.Raycast(landingRay, out hit, 3))
        {
            if (hit.collider.GetComponent<Interactable>())
            {
                if (hit.collider.gameObject != mLastObjectLookedAt)
                {
                    mLastObjectLookedAt = hit.collider.gameObject;
                    OnObjectLookedAt.Invoke(mLastObjectLookedAt);

                }
              
            }
            else
            {
              
                ClearLookTarget();
            }

        }
        else
        {
            ClearLookTarget();
        }

    }

    private void ClearLookTarget()
    {
        if (mLastObjectLookedAt != null)
        {
            mLastObjectLookedAt = null;
            OnObjectLookedAt.Invoke(mLastObjectLookedAt);
        }
    }
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        mController.Move(transform.TransformDirection(moveDirection) * mSpeed * Time.deltaTime);
        mVelocity.y += mGravity * Time.deltaTime;
        if (bIsGrounded && mVelocity.y < 0)
        {
            mVelocity.y = -2f;
        }
        mController.Move(mVelocity * Time.deltaTime);

    }

    public void Jump()
    {
        if (bIsGrounded)
        {
            mVelocity.y = Mathf.Sqrt(mJumpStrength * -1 * mGravity);
        }
    }
}
