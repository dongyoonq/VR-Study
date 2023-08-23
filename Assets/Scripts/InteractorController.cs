using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class InteractorController : MonoBehaviour
{
    [SerializeField] XRDirectInteractor directInteractor;
    [SerializeField] XRRayInteractor rayInteractor;
    [SerializeField] XRRayInteractor teleportInteractor;

    [SerializeField] InputActionReference teleportModeInput;

    [SerializeField] List<LocomotionProvider> locomotionProviders;

    private void Awake()
    {
        if (rayInteractor != null)
            rayInteractor.gameObject.SetActive(true);

        if (teleportInteractor != null)
            teleportInteractor.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (rayInteractor != null)
        {
            rayInteractor.selectEntered.AddListener(OnRaySelectEnter);
            rayInteractor.selectExited.AddListener(OnRaySelectExit);
            rayInteractor.uiHoverEntered.AddListener(OnUIHoverEnter);
            rayInteractor.uiHoverExited.AddListener(OnUIHoverExit);
        }

        if (teleportModeInput != null)
        {
            InputAction teleportAction = teleportModeInput.action;
            teleportAction.performed += TelePortModeStart;
            teleportAction.canceled += TeleportModeStop;
        }
    }
    private void OnDisable()
    {
        if (rayInteractor != null)
        {
            rayInteractor.selectEntered.RemoveListener(OnRaySelectEnter);
            rayInteractor.selectExited.RemoveListener(OnRaySelectExit);
            rayInteractor.uiHoverEntered.RemoveListener(OnUIHoverEnter);
            rayInteractor.uiHoverExited.RemoveListener(OnUIHoverExit);
        }

        if (teleportModeInput != null)
        {
            InputAction teleportAction = teleportModeInput.action;
            teleportAction.performed -= TelePortModeStart;
            teleportAction.canceled -= TeleportModeStop;
        }
    }

    private void OnRaySelectEnter(SelectEnterEventArgs args)
    {
        foreach (LocomotionProvider provider in locomotionProviders)
        {
            provider.gameObject.SetActive(false);
        }
    }

    private void OnRaySelectExit(SelectExitEventArgs args)
    {
        foreach (LocomotionProvider provider in locomotionProviders)
        {
            provider.gameObject.SetActive(true);
        }
    }

    private void OnUIHoverEnter(UIHoverEventArgs args)
    {
        foreach (LocomotionProvider provider in locomotionProviders)
        {
            provider.gameObject.SetActive(false);
        }
    }

    private void OnUIHoverExit(UIHoverEventArgs args)
    {
        foreach (LocomotionProvider provider in locomotionProviders)
        {
            provider.gameObject.SetActive(true);
        }
    }

    private void TelePortModeStart(InputAction.CallbackContext context)
    {
        if (rayInteractor != null)
            rayInteractor.gameObject.SetActive(false);

        if (teleportModeInput != null)
            teleportInteractor.gameObject.SetActive(true);
    }

    private void TeleportModeStop(InputAction.CallbackContext context)
    {
        if (rayInteractor != null)
            rayInteractor.gameObject.SetActive(true);

        if (teleportModeInput != null)
            teleportInteractor.gameObject.SetActive(false);
    }
}
