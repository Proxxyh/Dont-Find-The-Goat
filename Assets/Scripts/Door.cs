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
    [SerializeField] public bool isPlayersDoor;

    [Header("Sprites")]
    [SerializeField] private Sprite doorClosed;
    [SerializeField] private Sprite doorOpened;

    public void Interact()
    {
        InputManager.Instance.currentChosenDoor = null;
        InputManager.Instance.currentChosenDoor = gameObject;

        for (int i = 0; i < StateManager.Instance.allDoors.Count; i++)
        {
            StateManager.Instance.allDoors[i].GetComponent<Door>().isPlayersDoor = false;
        }
        this.isPlayersDoor = true;
    }
}
