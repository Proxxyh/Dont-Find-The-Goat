using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanel : MonoBehaviour
{
    [SerializeField] private List<GameObject> mainMenuObjects;
    [SerializeField] private List<GameObject> helpObjects;

    public void PlayButton()
    {
        StateManager.Instance.ChangeCurrentState(GameStates.ThreeDoorPickOne);
    }

    public void HelpButton()
    {
        for (int i = 0; i < mainMenuObjects.Count; i++)
        {
            mainMenuObjects[i].SetActive(false);
        }
        for (int i = 0; i < helpObjects.Count; i++)
        {
            helpObjects[i].SetActive(true);
        }

        transform.Find("StatsPanel").GetChild(0).gameObject.SetActive(false);

        //transform.Find("HelpSection").gameObject.SetActive(true);

        //transform.Find("MainButtons").gameObject.SetActive(false);
        //transform.Find("DeveloperTextGameObject").gameObject.SetActive(false);
        //transform.Find("PixelArtistTextGameObject").gameObject.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }


    public void HomeButton()
    {
        StateManager.Instance.ResetAllForStartGameAgain();
        StateManager.Instance.reStartButton.SetActive(false);
        StateManager.Instance.ChangeCurrentState(GameStates.None);
        StateManager.Instance.ChangeCurrentState(GameStates.MainMenu);

        for (int i = 0; i < helpObjects.Count; i++)
        {
            helpObjects[i].SetActive(false);
        }
        for (int i = 0; i < mainMenuObjects.Count; i++)
        {
            mainMenuObjects[i].SetActive(true);
        }

        transform.Find("StatsPanel").GetChild(0).gameObject.SetActive(false);
        //transform.Find("MainButtons").gameObject.SetActive(true);
        //transform.Find("HelpSection").gameObject.SetActive(false);
        //transform.Find("DeveloperTextGameObject").gameObject.SetActive(true);
        //transform.Find("PixelArtistTextGameObject").gameObject.SetActive(true);

    }
}
