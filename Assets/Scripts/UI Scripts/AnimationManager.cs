using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public void MainMenuButtonEnterAnimation(GameObject obj)
    {
        obj.GetComponent<RectTransform>().DOScale(1.1f, 0.5f);
    }
    public void MainMenuButtonExitAnimation(GameObject obj)
    {
        obj.GetComponent<RectTransform>().DOScale(1f, 0.5f);
    }
}
