using System.Threading.Tasks;
using JMS.Model;
using UnityEngine;
using UnityEngine.Networking;

namespace JMS.Services
{
    [CreateAssetMenu(fileName = "APIService", menuName = "Services/API Service")]
    public class APIService : ScriptableObject
    {
        private const string BASE_URL = "https://jsonplaceholder.typicode.com";

        public async Task<PhotoData> GetPhotoData(int id)
        {
            string url = $"{BASE_URL}/photos/{id}";
        
            using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
                var operation = webRequest.SendWebRequest();

                while (!operation.isDone)
                    await Task.Yield();

                if (webRequest.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"Error: {webRequest.error}");
                    return null;
                }

                string jsonResult = webRequest.downloadHandler.text;
                return JsonUtility.FromJson<PhotoData>(jsonResult);
            }
        }
    }
}