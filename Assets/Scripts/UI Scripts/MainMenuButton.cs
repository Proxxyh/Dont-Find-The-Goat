using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }
}
