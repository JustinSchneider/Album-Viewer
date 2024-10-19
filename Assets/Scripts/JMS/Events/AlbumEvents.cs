using UnityEngine;
using JMS.Components;

namespace JMS.Events
{
    [CreateAssetMenu(fileName = "AlbumEvents", menuName = "Events/Album Events")]
    public class AlbumEvents : ScriptableObject
    {
        public AlbumEntryEvent onEntryClicked = new AlbumEntryEvent();
    }

    [System.Serializable]
    public class AlbumEntryEvent : UnityEngine.Events.UnityEvent<AlbumEntry> { }
}