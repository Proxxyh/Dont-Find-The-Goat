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

    [Header("Sprites")]
    [SerializeField] public Sprite doorClosedNormal;
    [SerializeField] public Sprite doorClosedSelected;
    [SerializeField] public Sprite doorOpenedNormal;
    [SerializeField] public Sprite doorOpenedSelected;


    public void Interact()
    {
        InputManager.Instance.currentChosenDoor = null;
        InputManager.Instance.currentChosenDoor = gameObject;

        for (int i = 0; i < StateManager.Instance.allDoors.Count; i++)
        {
            StateManager.Instance.allDoors[i].GetComponent<Door>().isPlayersDoor = false;
            StateManager.Instance.allDoors[i].transform.Find("Door").transform.gameObject.GetComponent<SpriteRenderer>().sprite = doorClosedNormal;
            StateManager.Instance.allDoors[i].transform.Find("DoorOpened").transform.gameObject.GetComponent<SpriteRenderer>().sprite = doorOpenedNormal;
        }
        this.isPlayersDoor = true;
        this.gameObject.transform.Find("Door").transform.gameObject.GetComponent<SpriteRenderer>().sprite = doorClosedSelected;
        
    }
}
