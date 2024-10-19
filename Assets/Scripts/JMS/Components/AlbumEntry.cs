using JMS.Model;
using JMS.Events;
using TMPro;
using UnityEngine;

namespace JMS.Components
{
    public class AlbumEntry : MonoBehaviour
    {
        public int Id { get; private set; }
        public int AlbumId { get; private set; }
        public string Title { get; private set; }
        public string Url { get; private set; }
        public string ThumbnailUrl { get; private set; }

        [SerializeField] private Renderer entryRenderer;
        [SerializeField] private Color selectedColor = Color.yellow;
        [SerializeField] private Color deselectedColor = Color.white;
        [SerializeField] private AlbumEvents albumEvents;
        [SerializeField] private TMP_Text txtAlbumId;

        public void Initialize(PhotoData data)
        {
            Id = data.id;
            AlbumId = data.albumId;
            Title = data.title;
            Url = data.url;
            ThumbnailUrl = data.thumbnailUrl;
            txtAlbumId.text = data.id.ToString();
        }

        public void SetSelected(bool isSelected)
        {
            entryRenderer.material.color = isSelected ? selectedColor : deselectedColor;
        }

        private void OnMouseDown()
        {
            Debug.Log($"Selected Entry: Id: {Id}, AlbumId: {AlbumId}, Title: {Title}, Url: {Url}, Thumbnail: {ThumbnailUrl}");
            albumEvents.onEntryClicked.Invoke(this);
        }
    }
}