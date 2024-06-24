using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    Vector2 mousePosition = new Vector2();
    RaycastHit2D hit2D = new RaycastHit2D();

    [Header("Interact Settings")]
    [SerializeField] private LayerMask interactableLayers;

    [Header("Door Settings")]
    [SerializeField] public bool canPlayerSelectDoor;
    [SerializeField] public GameObject currentChosenDoor;

    private void Awake()
    {
        #region InstanceCheck
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
        #endregion
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            #region GetMousePosition&SendRay
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit2D = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity,interactableLayers);
            #endregion

            #region CheckIsInteractable
            if (hit2D.collider == null) //Etkileþimsiz obje ise çalýþýr.
            {
                //Debug.Log("Interact: Collidersýz Ýtem Ýþlem Gerçekleþtirilemiyor");
            }
            else //Etkileþimli obje ise çalýþýr.
            {
                //Debug.Log("Interact: " + hit2D.collider.gameObject.name);

                if (hit2D.collider.gameObject.TryGetComponent<IInteractable>(out IInteractable interatableObject) && canPlayerSelectDoor)
                {
                    interatableObject.Interact();
                }
            }
            #endregion
        }
    }
}
