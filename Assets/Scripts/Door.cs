using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Door : MonoBehaviour, IInteractable
{
    [Header("Door Settings")]
    [SerializeField] public int doorIndex;
    [SerializeField] public bool isOpen;
    [SerializeField] public bool isGoatHere;

    [Header("Sprites")]
    [SerializeField] private Sprite doorClosed;
    [SerializeField] private Sprite doorOpened;

    public void Interact()
    {
        InputManager.Instance.currentChosenDoor = gameObject;
    }
}
