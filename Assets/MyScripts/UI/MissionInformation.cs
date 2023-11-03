using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Information", menuName = "MissionInformation")]
public class MissionInformation : ScriptableObject
{
    public string missionNumber;
    public int missionValue;
    public string missionName;
    public string missionTarget;
    public string missionTime;
    public string missionThreat;
    [TextArea] public string message;
    public string date;
}
