using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    public static ResultManager Instance;

    [SerializeField] public int playerChangeDoorAllTotal;
    [SerializeField] public int playerChangeDoorWinTotal;
    [SerializeField] public float playerChangeDoorPercent;

    [SerializeField] public int playerNotChangeDoorAllTotal;
    [SerializeField] public int playerNotChangeDoorWinTotal;
    [SerializeField] public float playerNotChangeDoorPercent;



    private void Awake()
    {
        #region InstanceCheck
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
        #endregion
    }


    public void CalculateAllPercent()
    {
        if (playerChangeDoorAllTotal != 0)
            playerChangeDoorPercent = (float)playerChangeDoorWinTotal / (float)playerChangeDoorAllTotal * 100;

        if (playerNotChangeDoorAllTotal != 0)
            playerNotChangeDoorPercent = (float)playerNotChangeDoorWinTotal / (float)playerNotChangeDoorAllTotal * 100;
    }

    public void ClearResultManagerVariables()
    {
        playerChangeDoorAllTotal = 0;
        playerChangeDoorWinTotal = 0;
        playerChangeDoorPercent = 0;

        playerNotChangeDoorAllTotal = 0;
        playerNotChangeDoorWinTotal = 0;
        playerNotChangeDoorPercent = 0;
    }


}
