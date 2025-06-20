using System;
using UnityEngine;

[CreateAssetMenu(fileName = "StageLevelOS", menuName = "Scriptable Objects/StageLevelSO")]
public class StageLevelSO : ScriptableObject
{
    public static event Action OnGameAllClearEvent;
    public int InstansKillTrapAddCount;
    public int NomalTrapAddCount;
    public int CollectableAddCount;
    public float AddPower;

    public int minStageLevel = 1;
    public int maxStageLevel = 10;
    public string nowStageLevelUI;
    public int stageLevel;

    public void UpdateStageLevel(int value)
    {
        stageLevel = Mathf.Clamp(value, minStageLevel, maxStageLevel);
        if (stageLevel == minStageLevel)
        {
            OnGameAllClearEvent?.Invoke();
        }
        nowStageLevelUI = $"StageLevel: {stageLevel}/{maxStageLevel}";
    }
}
