using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager Instance;

    [Header("Main")]
    [SerializeField] public GameStates currentState;
    [SerializeField] public bool isCurrentStateUsingUpdate;

    [Header("References")]
    [SerializeField] private GameObject goatObj;
    [SerializeField] private List<GameObject> allDoors;
    [SerializeField] private List<Transform> threeDoorPositions;
    [SerializeField] private List<Transform> twoDoorPositions;

    [Header("-----------------------------------------------------------------------------------------------------------------------------------------------------------------"), Space(0)]

    [Header("Gameobject Lists For Activate")]
    [SerializeField] private List<GameObject> mainMenuObjects;
    [SerializeField] private List<GameObject> threeDoorPickOneObjects;




    private void Awake()
    {
        #region InstanceCheck
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
        #endregion
    }

    private void Start()
    {
        ChangeCurrentState(GameStates.ThreeDoorPickOne);
    }

    private void Update()
    {
        StatesUpdate();
    }

    //=========================================================================

    void ChangeCurrentState(GameStates gameState)
    {
        isCurrentStateUsingUpdate = false;  //Bir sonraki state'e ge�meden �nce updatei kapat�r.

        StatesExit();                       //Mevcut state'in ��k�� fonksiyonunu �al��t�r�r
        currentState = gameState;           //Mevcut State i de�i�tirir
        StatesEnter();                      //Yeni statein giri�ini �al��t�r�r (Yeni state'in update'i bu fonksiyondan sonra �al���r)
    }

    void StatesEnter()
    {
        switch (currentState)
        {
            case GameStates.MainMenu:
                for (int i = 0; i < mainMenuObjects.Count; i++)
                {
                    mainMenuObjects[i].SetActive(true);
                }   //Main men� objelerini aktif et

                isCurrentStateUsingUpdate = false;  //En son �al��acak
                break;


            case GameStates.ThreeDoorPickOne:
                ChooseWhichDoorHaveGoat();

                LanguageManager.Instance.ingameHeaderText.text = LanguageManager.Instance.currentLanguageSo.ingameHeaderTextThreeDoorPickOne;
                InputManager.Instance.currentChosenDoor = null;
                InputManager.Instance.canPlayerSelectDoor = true;

                isCurrentStateUsingUpdate = true;  //En son �al��acak
                break;


            case GameStates.AskForTheChange:
                isCurrentStateUsingUpdate = false;  //En son �al��acak
                break;


            case GameStates.TwoDoorPickOne:
                isCurrentStateUsingUpdate = false;  //En son �al��acak
                break;


            case GameStates.SeeResult:
                isCurrentStateUsingUpdate = false;  //En son �al��acak
                break;
        }
    }

    void StatesUpdate()
    {
        if (isCurrentStateUsingUpdate)
        {
            switch (currentState)
            {
                case GameStates.MainMenu:
                    Debug.Log("Updateim Yok");
                    break;


                case GameStates.ThreeDoorPickOne:
                    if(InputManager.Instance.currentChosenDoor != null)
                    {
                        InputManager.Instance.canPlayerSelectDoor = false;

                        ChangeCurrentState(GameStates.AskForTheChange);
                    }
                    break;


                case GameStates.AskForTheChange:
                    Debug.Log("Updateim Yok");
                    break;


                case GameStates.TwoDoorPickOne:
                    Debug.Log("Updateim Yok");
                    break;


                case GameStates.SeeResult:
                    Debug.Log("Updateim Yok");
                    break;
            }
        }
    }

    void StatesExit()
    {
        switch (currentState)
        {
            case GameStates.MainMenu:
                for (int i = 0; i < mainMenuObjects.Count; i++)
                {
                    mainMenuObjects[i].SetActive(false);
                }
                break;


            case GameStates.ThreeDoorPickOne:
                break;


            case GameStates.AskForTheChange:
                break;


            case GameStates.TwoDoorPickOne:
                break;


            case GameStates.SeeResult:
                break;
        }
    }

    //=========================================================================

    void ChooseWhichDoorHaveGoat()
    {
        int choosenDoorIndex = Random.Range(0, 3);
        allDoors[choosenDoorIndex].GetComponent<Door>().isGoatHere = true;

        goatObj.transform.position = allDoors[choosenDoorIndex].transform.position;
        goatObj.transform.parent = allDoors[choosenDoorIndex].transform;
    }
}
