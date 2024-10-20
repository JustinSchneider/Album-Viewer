using UnityEngine;
using UnityEngine.UI;
using JMS.Managers;
using JMS.Components;

namespace JMS.UI
{
    public class AlbumUI : MonoBehaviour
    {
        [SerializeField] private AlbumEntryManager entryManager;
        [SerializeField] private PlacementManager placementManager;
        [SerializeField] private Button btnAddEntry;
        [SerializeField] private Button btnDeleteEntry;
        [SerializeField] private ImageViewer imageViewer;

        private void Start()
        {
            btnAddEntry.onClick.AddListener(placementManager.StartPlacementMode);
            btnDeleteEntry.onClick.AddListener(entryManager.DeleteSelectedEntry);
            
            entryManager.onEntrySelected.AddListener(UpdateSelectedImage);
            entryManager.onEntryAdded.AddListener(UpdateButtonStates);
            entryManager.onEntryDeleted.AddListener(UpdateButtonStates);

            UpdateButtonStates(null);
        }

        private void Update()
        {
            if (placementManager.IsPlacementMode)
            {
                HandlePlacementMode();
            }
        }

        private void HandlePlacementMode()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, placementManager.PlacementLayers))
            {
                if (placementManager.IsValidPlacementPosition(hit.point))
                {
                    placementManager.UpdateGhostPosition(hit.point);

                    if (Input.GetMouseButtonDown(0))
                    {
                        placementManager.PlaceEntry(hit.point);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
            {
                placementManager.CancelPlacement();
            }
        }

        private void UpdateButtonStates(AlbumEntry entry)
        {
            btnAddEntry.gameObject.SetActive(true);
            btnDeleteEntry.gameObject.SetActive(entryManager.SelectedEntry);
        }

        private void UpdateSelectedImage(AlbumEntry selectedEntry)
        {
            if (selectedEntry)
            {
                imageViewer.LoadImage(selectedEntry.Url);
            }
            else
            {
                imageViewer.Clear();
            }
            UpdateButtonStates(selectedEntry);
        }
        
        private void OnDestroy()
        {
            if (entryManager)
            {
                entryManager.onEntrySelected.RemoveListener(UpdateSelectedImage);
                entryManager.onEntryAdded.RemoveListener(UpdateButtonStates);
                entryManager.onEntryDeleted.RemoveListener(UpdateButtonStates);
            }
        }
    }
}