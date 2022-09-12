using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingBehavior : MonoBehaviour
{
    public RectTransform aimPosition;
    [SerializeField] Transform aimtarget;
    [SerializeField] Transform gunObject;
    [SerializeField] ParticleSystem shootParticleSystem;

    private void Awake()
    {
        MainInputActions mainInputActions = new MainInputActions();
        mainInputActions.MainMap.Enable();
        mainInputActions.MainMap.AimPosition.performed += Aim;
        mainInputActions.MainMap.TouchMain.started += Shoot;
        mainInputActions.MainMap.TouchMain.canceled += StopShooting;
        mainInputActions.MainMap.TouchPosition.performed += GetTouchPosition;
        
    }


    private void Aim(InputAction.CallbackContext context)
    {
        Vector2 deltaPos = context.ReadValue<Vector2>();
        float changeX = deltaPos.x * 0.1f;
        float changeY = deltaPos.y * 0.1f;
        aimtarget.position += new Vector3(changeX, changeY, 0);
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        shootParticleSystem.Play();
    }

    private void StopShooting(InputAction.CallbackContext context)
    {
        shootParticleSystem.Stop();
    }

    private void GetTouchPosition(InputAction.CallbackContext context)
    {
        Vector3 touchPos = context.ReadValue<Vector2>();
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(touchPos);

    }


}
