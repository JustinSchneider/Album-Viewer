using System.Collections.Generic;
using JMS.Components;
using JMS.Events;
using UnityEngine;
using UnityEngine.Events;

namespace JMS.Managers
{
    [CreateAssetMenu(fileName = "AlbumEntryManager", menuName = "Managers/Album Entry Manager")]
    public class AlbumEntryManager : ScriptableObject
    {
        public List<AlbumEntry> AlbumEntries { get; private set; } = new List<AlbumEntry>();
        public AlbumEntry SelectedEntry { get; private set; }

        [SerializeField] private AlbumEvents albumEvents;

        [System.Serializable] public class AlbumEntryEvent : UnityEvent<AlbumEntry> { }
    
        public AlbumEntryEvent onEntrySelected = new AlbumEntryEvent();
        public AlbumEntryEvent onEntryAdded = new AlbumEntryEvent();
        public AlbumEntryEvent onEntryDeleted = new AlbumEntryEvent();

        public int NextId { get; private set; }
        
        private void OnEnable()
        {
            NextId = 1;
            
            if (albumEvents == null) return;
            
            albumEvents.onEntryClicked.AddListener(SelectEntry);
        }

        private void OnDisable()
        {
            albumEvents.onEntryClicked.RemoveListener(SelectEntry);
        }

        public void AddEntry(AlbumEntry entry)
        {
            NextId = entry.Id + 1;
            AlbumEntries.Add(entry);
            onEntryAdded.Invoke(entry);
        }

        public void RemoveEntry(AlbumEntry entry)
        {
            if (AlbumEntries.Remove(entry))
            {
                if (NextId == entry.Id + 1)
                {
                    NextId = entry.Id;
                }
                
                if (SelectedEntry == entry)
                {
                    SelectEntry(null);
                }
                onEntryDeleted.Invoke(entry);
                Object.Destroy(entry.gameObject);
                Debug.Log($"Deleted entry: {entry.Title}");
            }
        }

        public void SelectEntry(AlbumEntry entry)
        {
            if (SelectedEntry)
            {
                SelectedEntry.SetSelected(false);
            }
        
            SelectedEntry = entry;
        
            if (SelectedEntry)
            {
                SelectedEntry.SetSelected(true);
            }
            onEntrySelected.Invoke(SelectedEntry);
        }

        public void DeleteSelectedEntry()
        {
            if (SelectedEntry)
            {
                RemoveEntry(SelectedEntry);
            }
        }
    }
}