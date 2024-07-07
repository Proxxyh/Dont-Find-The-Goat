using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private List<GameObject> inMenuObjects = new List<GameObject>();


    #region SettingsButton
    public void OnClickSettingsButton()
    {
        TogglePanel();
    }
    private void TogglePanel()
    {
        if (inMenuObjects[0].activeSelf)    //Men�y� Kapat
        {
            foreach (GameObject item in inMenuObjects)
            {
                item.SetActive(false);
            }
        }
        else    //Men�y� A�
        {
            foreach (GameObject item in inMenuObjects)
            {
                item.SetActive(true);
            }
        }


    }


    #endregion

    #region MenuItems
    #endregion

}
