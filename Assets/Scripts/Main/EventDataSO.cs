using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EventDataSO", menuName = "Create EventDataSO")]
public class EventDataSO : ScriptableObject
{
    public List<EventData> eventDatasList = new List<EventData>();   // •¡”‚Ì EventData ‚ğ‚P‚Â‚Ì•Ï”“à‚Å‚Ü‚Æ‚ß‚ÄŠÇ—‚ğs‚¤
}
