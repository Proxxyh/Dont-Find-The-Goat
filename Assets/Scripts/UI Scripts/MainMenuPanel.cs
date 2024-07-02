using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanel : MonoBehaviour
{
    public void PlayButton()
    {
        StateManager.Instance.ChangeCurrentState(GameStates.ThreeDoorPickOne);
    }

    public void HelpButton()
    {
        transform.Find("HelpSection").gameObject.SetActive(true);

        transform.Find("MainButtons").gameObject.SetActive(false);
        transform.Find("DeveloperTextGameObject").gameObject.SetActive(false);
        transform.Find("PixelArtistTextGameObject").gameObject.SetActive(false);
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
        transform.Find("MainButtons").gameObject.SetActive(true);
        transform.Find("HelpSection").gameObject.SetActive(false);
        transform.Find("DeveloperTextGameObject").gameObject.SetActive(true);
        transform.Find("PixelArtistTextGameObject").gameObject.SetActive(true);

    }
}
