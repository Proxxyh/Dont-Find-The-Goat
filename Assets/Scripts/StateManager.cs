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

    [Header("References")]
    [SerializeField] private GameObject yesOrNoBubble;
    [SerializeField] private GameObject goatObj;
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
        isCurrentStateUsingUpdate = false;  //Bir sonraki state'e geçmeden önce updatei kapatýr.

        StatesExit();                       //Mevcut state'in çýkýþ fonksiyonunu çalýþtýrýr
        currentState = gameState;           //Mevcut State i deðiþtirir
        StatesEnter();                      //Yeni statein giriþini çalýþtýrýr (Yeni state'in update'i bu fonksiyondan sonra çalýþýr)
    }

    void StatesEnter()
    {
        switch (currentState)
        {
            case GameStates.MainMenu:
                for (int i = 0; i < mainMenuObjects.Count; i++)
                {
                    mainMenuObjects[i].SetActive(true);
                }   //Main menü objelerini aktif et
                for (int i = 0; i < inGameObjects.Count; i++)
                {
                    inGameObjects[i].SetActive(false);
                }   //threeDoorPickOne objelerini kapat
                

                isCurrentStateUsingUpdate = false;  //En son çalýþacak
                break;


            case GameStates.ThreeDoorPickOne:
                for (int i = 0;i < inGameObjects.Count; i++)
                {
                    inGameObjects[i].SetActive(true);
                }
                yesOrNoBubble.SetActive(false);
                ChooseWhichDoorHaveGoat();

                LanguageManager.Instance.ingameHeaderText.text = LanguageManager.Instance.currentLanguageSo.ingameHeaderTextThreeDoorPickOne;
                InputManager.Instance.currentChosenDoor = null;
                InputManager.Instance.canPlayerSelectDoor = true;

                isCurrentStateUsingUpdate = true;  //En son çalýþacak
                break;


            case GameStates.AskForTheChange:
                yesOrNoBubble.SetActive(true);
                LanguageManager.Instance.ingameHeaderText.text = LanguageManager.Instance.currentLanguageSo.ingameHeaderTextAskForTheChange;
                RemoveDoor();


                isCurrentStateUsingUpdate = true;  //En son çalýþacak
                break;


            case GameStates.TwoDoorPickOne:
                isCurrentStateUsingUpdate = false;  //En son çalýþacak
                break;


            case GameStates.SeeResult:
                isCurrentStateUsingUpdate = false;  //En son çalýþacak
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
                        if(isPlayerChangeTheDoor == false)
                        {
                            //Oyuncuya sonucu göster
                            print("Oyuncu kapýyý deðiþtirmedi");
                        }
                        else if(isPlayerChangeTheDoor == true)
                        {
                            //Oyuncuya iki kapýdan birini seçtir
                            print("Oyuncu kapýyý deðiþtirdi");
                        }
                    }
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
                yesOrNoBubble.SetActive(false);
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
        goatObj.transform.localPosition = Vector3.zero;
    }

    void RemoveDoor()
    {
        List<GameObject> allDoorObjForThisFunc = new List<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            allDoorObjForThisFunc.Add(allDoors[i]);
        }
        
        allDoorObjForThisFunc.Remove(InputManager.Instance.currentChosenDoor);

        GameObject thisDoorGonnaBeRemove = new GameObject();
        foreach (GameObject item in allDoorObjForThisFunc)
        {
            if (item.GetComponent<Door>().isGoatHere == false)
            {
                thisDoorGonnaBeRemove = item;
            }   
        }
        thisDoorGonnaBeRemove.SetActive(false);


        List<GameObject> lastTwoDoors = new List<GameObject>();
        foreach (GameObject item in allDoors)
        {
            if (item.activeSelf)
            {
                lastTwoDoors.Add(item);
                print(item.name);
            }
        }

        for (int i = 0; i < twoDoorPositions.Count; i++)
        {
            lastTwoDoors[i].transform.position = twoDoorPositions[i].transform.position;
        }



        //Ýki kapýnýn pozisyonunu ayarla
    }
    public void ChangeIsPlayerAnswerTheQuestion(bool isPlayerAnswerTheQuestionn)
    {
        isPlayerAnswerTheQuestion = isPlayerAnswerTheQuestionn;
    }
    public void ChangeIsPlayerChangeTheDoor(bool isPlayerChangeTheDoorr)
    {
        isPlayerChangeTheDoor = isPlayerChangeTheDoorr;
    }
}
