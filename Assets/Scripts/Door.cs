using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Door : MonoBehaviour, IInteractable
{
    [Header("Door Settings")]
    [SerializeField] public int doorIndex;
    [SerializeField] public bool isOpen;
    [SerializeField] public bool isCarHere;
    [SerializeField] public bool isPlayersDoor;

    [Header("References")]
    [SerializeField] public GameObject doorClosed;
    [SerializeField] public GameObject doorOpened;


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
