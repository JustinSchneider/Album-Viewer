using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace JMS.Components
{
    public class ImageViewer : MonoBehaviour
    {
        [SerializeField] private Image imgAlbumEntryImage;
        [SerializeField] private Image imgLoadingSpinner;
        [SerializeField] private TMP_Text txtErrorMessage;
        [SerializeField] private float spinSpeed = 360f;
        
        private Coroutine loadingCoroutine;
        private bool isLoading = false;

        private void Awake()
        {
            imgAlbumEntryImage.gameObject.SetActive(false);
            imgLoadingSpinner.gameObject.SetActive(false);
            txtErrorMessage.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (isLoading)
            {
                imgLoadingSpinner.transform.Rotate(0, 0, -spinSpeed * Time.deltaTime);
            }
        }

        public void LoadImage(string url)
        {
            // Clear previous state
            imgAlbumEntryImage.sprite = null;
            imgAlbumEntryImage.color = Color.clear;
            txtErrorMessage.text = string.Empty;

            // Show loading spinner
            imgLoadingSpinner.gameObject.SetActive(true);
            isLoading = true;

            // Stop any ongoing loading coroutine
            if (loadingCoroutine != null)
            {
                StopCoroutine(loadingCoroutine);
            }

            // Start new loading coroutine
            loadingCoroutine = StartCoroutine(LoadImageCoroutine(url));
        }

        private IEnumerator LoadImageCoroutine(string url)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
            yield return request.SendWebRequest();
            
            isLoading = false;

            // Hide loading spinner
            imgLoadingSpinner.gameObject.SetActive(false);

            if (request.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                imgAlbumEntryImage.sprite = sprite;
                imgAlbumEntryImage.color = Color.white;
                imgAlbumEntryImage.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogError($"Failed to load image: {request.error}");
                txtErrorMessage.text = $"Failed to load image: {request.error}";
                imgAlbumEntryImage.gameObject.SetActive(false);
            }

            loadingCoroutine = null;
        }

        public void Clear()
        {
            imgAlbumEntryImage.sprite = null;
            imgAlbumEntryImage.color = Color.clear;
            imgAlbumEntryImage.gameObject.SetActive(false);
            imgLoadingSpinner.gameObject.SetActive(false);
            txtErrorMessage.text = string.Empty;

            if (loadingCoroutine != null)
            {
                StopCoroutine(loadingCoroutine);
                loadingCoroutine = null;
            }
        }
    }
}