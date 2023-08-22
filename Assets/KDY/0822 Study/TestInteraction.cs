using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace study0822
{
    public class TestInteraction : MonoBehaviour
    {
        [SerializeField] Transform character;
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
        public void Attack(ActivateEventArgs args)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 2f, LayerMask.GetMask("Monster"));

            Debug.Log(colliders.Length);

            foreach (Collider collider in colliders)
            {
                Vector3 dirTarget = (collider.transform.position - transform.position).normalized;

                if (Vector3.Dot(transform.up, dirTarget) >= Mathf.Cos(360f * 0.5f * Mathf.Deg2Rad) &&
                    Vector2.Dot(transform.forward, dirTarget) >= Mathf.Cos(300f * 0.5f * Mathf.Deg2Rad))
                    collider.GetComponent<IHitable>().Hit(30);
            }
        }
    }

}