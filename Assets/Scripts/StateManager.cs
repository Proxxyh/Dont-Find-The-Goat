using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class StateManager : MonoBehaviour
{
    public static StateManager Instance;

    [Header("Main")]
    [SerializeField] public GameStates currentState;
    [SerializeField] public bool isCurrentStateUsingUpdate;
    [SerializeField] public bool isPlayerChangeTheDoor;
    [SerializeField] public bool isPlayerAnswerTheQuestion;
    [SerializeField] public bool isPlayerWon;

    [Header("References")]
    [SerializeField] private GameObject yesOrNoBubble;
    [SerializeField] private GameObject goatObj;
    [SerializeField] private GameObject reStartButton;
    [SerializeField] public List<GameObject> allDoors;
    [SerializeField] private List<Transform> threeDoorPositions;
    [SerializeField] private List<Transform> twoDoorPositions;

    [Header("-----------------------------------------------------------------------------------------------------------------------------------------------------------------"), Space(0)]

    [Header("Gameobject Lists For Activate")]
    [SerializeField] private List<GameObject> mainMenuObjects;
    [SerializeField] private List<GameObject> inGameObjects;




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

    }

    private void Update()
    {
        StatesUpdate();
    }

    //=========================================================================

    public void ChangeCurrentState(GameStates gameState)
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
                for (int i = 0; i < inGameObjects.Count; i++)
                {
                    inGameObjects[i].SetActive(false);
                }   //threeDoorPickOne objelerini kapat
                

                isCurrentStateUsingUpdate = false;  //En son �al��acak
                break;


            case GameStates.ThreeDoorPickOne:
                for (int i = 0;i < inGameObjects.Count; i++)
                {
                    inGameObjects[i].SetActive(true);
                }
                yesOrNoBubble.SetActive(false);
                ChooseWhichDoorHaveGoat();
                SetDoorsPosition();
                SetDoorClosed();
                SetDoorSetActive();


                LanguageManager.Instance.ingameHeaderText.text = LanguageManager.Instance.currentLanguageSo.ingameHeaderTextThreeDoorPickOne;
                InputManager.Instance.currentChosenDoor = null;
                InputManager.Instance.canPlayerSelectDoor = true;

                isCurrentStateUsingUpdate = true;  //En son �al��acak
                break;


            case GameStates.AskForTheChange:
                
                LanguageManager.Instance.ingameHeaderText.text = LanguageManager.Instance.currentLanguageSo.ingameHeaderTextAskForTheChange;
                RemoveDoor();
                yesOrNoBubble.SetActive(true);


                isCurrentStateUsingUpdate = true;  //En son �al��acak
                break;


            case GameStates.PlayerChangedDoor:
                ChangePlayerDoorWhenLastTwoDoorRemairing();

                ChangeCurrentState(GameStates.SeeResult);
                isCurrentStateUsingUpdate = false;  //En son �al��acak
                break;


            case GameStates.SeeResult:
                #region TumKapilariAc
                foreach (GameObject item in allDoors)
                {
                    item.GetComponent<Door>().doorClosed.SetActive(false);
                    item.GetComponent<Door>().doorOpened.SetActive(true);
                }
                #endregion

                if(InputManager.Instance.currentChosenDoor.GetComponent<Door>().isGoatHere == true)
                {
                    //Oyuncunun se�ti�i kap�da ke�i varsa
                    LanguageManager.Instance.ingameHeaderText.text = LanguageManager.Instance.currentLanguageSo.ingameHeaderTextWinText;
                    print("Kazand�");
                    isPlayerWon = true;
                }
                else
                {
                    //Oyuncu yanl�� tercih yapt�ysa
                    LanguageManager.Instance.ingameHeaderText.text = LanguageManager.Instance.currentLanguageSo.ingameHeaderTextLoseText;
                    print("Kaybetti");
                    isPlayerWon = false;
                }

                if (isPlayerChangeTheDoor)
                {
                    //Oyuncu se�imini de�i�tirdiyse �al��
                    print("De�i�ti");
                    if (isPlayerWon)
                    {
                        ResultManager.Instance.playerChangeDoorAllTotal++;
                        ResultManager.Instance.playerChangeDoorWinTotal++;
                        ResultManager.Instance.CalculateAllPercent();
                    }
                    else
                    {
                        ResultManager.Instance.playerChangeDoorAllTotal++;
                        ResultManager.Instance.CalculateAllPercent();
                    }

                }
                else if (!isPlayerChangeTheDoor)
                {
                    //Oyuncu se�imini de�i�tirmediyse �al��
                    print("De�i�medi");
                    if (isPlayerWon)
                    {
                        ResultManager.Instance.playerNotChangeDoorAllTotal++;
                        ResultManager.Instance.playerNotChangeDoorWinTotal++;
                        ResultManager.Instance.CalculateAllPercent();
                    }
                    else
                    {
                        ResultManager.Instance.playerNotChangeDoorAllTotal++;
                        ResultManager.Instance.CalculateAllPercent();
                    }
                }

                reStartButton.SetActive(true);


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
                    if (isPlayerAnswerTheQuestion)
                    {
                        yesOrNoBubble.SetActive(false);
                        if (isPlayerChangeTheDoor == false)
                        {
                            ChangeCurrentState(GameStates.SeeResult);
                        }
                        else if(isPlayerChangeTheDoor == true)
                        {
                            ChangeCurrentState(GameStates.PlayerChangedDoor);
                        }
                    }
                    break;


                case GameStates.PlayerChangedDoor:
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
                yesOrNoBubble.SetActive(false);
                break;


            case GameStates.PlayerChangedDoor:
                break;


            case GameStates.SeeResult:
                reStartButton.SetActive(false);
                ResetAllForStartGameAgain();
                break;
        }
    }

    //=========================================================================


    void ChooseWhichDoorHaveGoat()
    {
        int choosenDoorIndex = Random.Range(0, 3);
        allDoors[choosenDoorIndex].GetComponent<Door>().isGoatHere = true;

        goatObj.transform.position = allDoors[choosenDoorIndex].transform.position;
        goatObj.transform.parent = allDoors[choosenDoorIndex].transform.GetChild(0).transform;
        goatObj.transform.localPosition = Vector3.zero;
        goatObj.transform.parent = allDoors[choosenDoorIndex].transform;
    }
    void SetDoorsPosition()
    {
        for (int i = 0; i < allDoors.Count; i++)
        {
            allDoors[i].transform.position = threeDoorPositions[i].position;
        }
    }
    void SetDoorClosed()
    {
        foreach (GameObject item in allDoors)
        {
            item.GetComponent<Door>().doorClosed.SetActive(true);
            item.GetComponent<Door>().doorOpened.SetActive(false);
        }
    }
    void SetDoorSetActive()
    {
        for (int i = 0; i < allDoors.Count; i++)
        {
            allDoors[i].SetActive(true);
        }
    }


    void RemoveDoor()
    {
        //T�m kap�lar� bir listeye ekle
        //mevcut kap�y� listeden ��kar
        //Geriye kalan iki kap�dan ke�i olmayan bir kap�y� ��kar
        //En son kalan se�ilen kap� ve di�er kap�y� uygun konumlara s�rala

        List<GameObject> allDoorCopy = new List<GameObject>();
        allDoors.ForEach(item => { allDoorCopy.Add(item);}) ;
        allDoorCopy.Remove(InputManager.Instance.currentChosenDoor);
        foreach (GameObject item in allDoorCopy)
        {
            if (item.GetComponent<Door>().isGoatHere == false)
            {
                item.SetActive(false);
                break;
            }
        }

        allDoorCopy.Clear();
        foreach (var item in allDoors)
        {
            if (item.activeSelf)
            {
                allDoorCopy.Add(item);
            }
        }

        for (int i = 0; i < allDoorCopy.Count; i++)
        {
            allDoorCopy[i].transform.position = twoDoorPositions[i].position;
        }

    }
    public void ChangeIsPlayerAnswerTheQuestion(bool isPlayerAnswerTheQuestionn)
    {
        isPlayerAnswerTheQuestion = isPlayerAnswerTheQuestionn;
    }
    public void ChangeIsPlayerChangeTheDoor(bool isPlayerChangeTheDoorr)
    {
        isPlayerChangeTheDoor = isPlayerChangeTheDoorr;
    }


    void ChangePlayerDoorWhenLastTwoDoorRemairing()
    {
        List<GameObject> lastDoor = new List<GameObject>();
        foreach (GameObject item in allDoors)
        {
            if (item.activeSelf)
            {
                lastDoor.Add(item);
            }     
        }
        lastDoor.Remove(InputManager.Instance.currentChosenDoor);
        InputManager.Instance.currentChosenDoor = lastDoor[0];
    }

    void ResetAllForStartGameAgain()
    {
        isPlayerChangeTheDoor = false;
        isPlayerWon = false;
        isPlayerAnswerTheQuestion = false;

        InputManager.Instance.currentChosenDoor = null;
        InputManager.Instance.canPlayerSelectDoor = false;

        foreach (GameObject item in allDoors)
        {
            item.GetComponent<Door>().isGoatHere = false;
        }
    }
    public void ReStartButton()
    {
        ChangeCurrentState(GameStates.ThreeDoorPickOne);
    }
}
