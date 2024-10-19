using UnityEngine;
using JMS.Factories;
using JMS.Components;

namespace JMS.Managers
{
    [CreateAssetMenu(fileName = "PlacementManager", menuName = "Managers/Placement Manager")]
    public class PlacementManager : ScriptableObject
    {
        [SerializeField] private AlbumEntryFactory entryFactory;
        [SerializeField] private AlbumEntryManager entryManager;
        [SerializeField] private GameObject ghostEntryPrefab;
        [SerializeField] private LayerMask placementLayers;

        private GameObject ghostEntry;
        private bool isPlacementMode = false;

        public bool IsPlacementMode => isPlacementMode;
        public LayerMask PlacementLayers => placementLayers;

        public void StartPlacementMode()
        {
            isPlacementMode = true;
            ghostEntry = Instantiate(ghostEntryPrefab);
            
            if (entryManager.SelectedEntry)
            {
                entryManager.SelectEntry(null);
            }
        }
        
        public void UpdateGhostPosition(Vector3 position)
        {
            if (ghostEntry)
            {
                ghostEntry.transform.position = position;
            }
        }

        public async void PlaceEntry(Vector3 position)
        {
            if (!isPlacementMode) return;

            isPlacementMode = false;
            Destroy(ghostEntry);
            ghostEntry = null;

            AlbumEntry newEntry = await entryFactory.CreateAlbumEntry(position);
            if (newEntry)
            {
                entryManager.AddEntry(newEntry);
                entryManager.SelectEntry(newEntry);
                Debug.Log($"Created entry: {newEntry.Title}");
            }
        }

        public void CancelPlacement()
        {
            if (isPlacementMode)
            {
                isPlacementMode = false;
                Destroy(ghostEntry);
                ghostEntry = null;
            }
        }

        public bool IsValidPlacementPosition(Vector3 position)
        {
            return true;
        }
    }
}