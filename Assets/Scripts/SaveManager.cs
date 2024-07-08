using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;


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
        LoadGame();
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("playerChangeDoorAllTotal", ResultManager.Instance.playerChangeDoorAllTotal);
        PlayerPrefs.SetInt("playerChangeDoorWinTotal", ResultManager.Instance.playerChangeDoorWinTotal);

        PlayerPrefs.SetInt("playerNotChangeDoorAllTotal", ResultManager.Instance.playerNotChangeDoorAllTotal);
        PlayerPrefs.SetInt("playerNotChangeDoorWinTotal", ResultManager.Instance.playerNotChangeDoorWinTotal);

        PlayerPrefs.SetInt("languageIndex", LanguageManager.Instance.currentLanguageIndex);
    }

    public void LoadGame()
    {
        ResultManager.Instance.playerChangeDoorAllTotal = PlayerPrefs.GetInt("playerChangeDoorAllTotal");
        ResultManager.Instance.playerChangeDoorWinTotal = PlayerPrefs.GetInt("playerChangeDoorWinTotal");
        ResultManager.Instance.playerNotChangeDoorAllTotal = PlayerPrefs.GetInt("playerNotChangeDoorAllTotal");
        ResultManager.Instance.playerNotChangeDoorWinTotal = PlayerPrefs.GetInt("playerNotChangeDoorWinTotal");

        ResultManager.Instance.CalculateAllPercent();



        LanguageManager.Instance.ChangeLanguage(PlayerPrefs.GetInt("languageIndex"));
        
    }

    [ContextMenu("ResetGame")]
    public void ResetAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
