using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TestInteraction : MonoBehaviour
{
    [SerializeField] Transform hand;

    private XRGrabInteractable interactable;
    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
    }
    private void OnEnable()
    {
        interactable.selectEntered.AddListener((arg) => Equiped(arg));
    }
    private void Equiped(SelectEnterEventArgs args)
    {
        transform.SetParent(hand);
    }
}
