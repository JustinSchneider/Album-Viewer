using System.Threading.Tasks;
using JMS.Components;
using JMS.Managers;
using JMS.Model;
using JMS.Services;
using UnityEngine;

namespace JMS.Factories
{
    [CreateAssetMenu(fileName = "AlbumEntryFactory", menuName = "Factories/Album Entry Factory")]
    public class AlbumEntryFactory : ScriptableObject
    {
        [SerializeField] private APIService apiService;
        [SerializeField] private GameObject albumEntryPrefab;
        [SerializeField] private AlbumEntryManager albumEntryManager;

        public async Task<AlbumEntry> CreateAlbumEntry(Vector3 position)
        {
            int id = albumEntryManager.NextId;
            
            PhotoData photoData = await apiService.GetPhotoData(id);
        
            if (photoData == null)
            {
                Debug.LogError("Failed to fetch photo data");
                return null;
            }

            GameObject entryObject = Instantiate(albumEntryPrefab, position, Quaternion.identity);
            AlbumEntry albumEntry = entryObject.GetComponent<AlbumEntry>();
            albumEntry.Initialize(photoData);

            return albumEntry;
        }
    }
}