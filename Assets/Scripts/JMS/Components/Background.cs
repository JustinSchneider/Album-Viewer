using JMS.Events;
using UnityEngine;

namespace JMS.Components
{
    public class Background : MonoBehaviour
    {
        [SerializeField] private AlbumEvents albumEvents;
    
        private void OnMouseDown()
        {
            albumEvents.onEntryClicked.Invoke(null);
        }
    }
}
