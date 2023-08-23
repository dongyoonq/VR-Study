using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace study0822
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] public int damage;
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
            //GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}