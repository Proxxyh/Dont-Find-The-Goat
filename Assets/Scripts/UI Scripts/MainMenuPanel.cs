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

    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
