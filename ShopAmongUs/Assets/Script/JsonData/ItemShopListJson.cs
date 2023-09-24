using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using PhEngine.Core;

namespace ShopUIAmongUs.Json
{
    public class ItemShopListJson : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] List<ItemDataJson> itemDatasList = new List<ItemDataJson>();

        [Header("Saving")]
        [SerializeField] string savePath;
        [SerializeField] string onlineLoadPath;
        [Header("UI")] [SerializeField] Transform itemShopParent;
        [SerializeField] UIShopJson uIItemPrefab;
        [SerializeField] List<UIShopJson> uIItemsList = new List<UIShopJson>();

        [ContextMenu(nameof(TestJsonConvert))]
        void TestJsonConvert()
        {
            var itemShopJson = JsonConvert.SerializeObject(itemDatasList);
            Debug.Log(itemShopJson);
        }
        [ContextMenu(nameof(SaveScoreData))]
        void SaveScoreData()
        {
            if (string.IsNullOrEmpty(savePath))
            {
                Debug.LogError("No save path ja");
                return;
            }
            
            var itemShopJson  = JsonConvert.SerializeObject(itemDatasList);
            var dataPath = Application.dataPath;
            var targetFilePath = Path.Combine(dataPath,savePath);

            var directoryPath = Path.GetDirectoryName(targetFilePath);
            if (Directory.Exists(directoryPath) == false)
                Directory.CreateDirectory(directoryPath);
            
            File.WriteAllText(targetFilePath, itemShopJson);
        }
        [ContextMenu(nameof(LoadScoreData))]
        void LoadScoreData()
        {
            var dataPath = Application.dataPath;
            var targetFilePath = Path.Combine(dataPath,savePath);
            
            var directoryPath = Path.GetDirectoryName(targetFilePath);
            if (Directory.Exists(directoryPath) == false)
            {
                Debug.LogError("No save folder at provided path");
                return;
            }

            if (File.Exists(targetFilePath) == false)
            {
                Debug.LogError("No save file at provided path");
                return;
            }

            var scoreJson = File.ReadAllText(targetFilePath);
            itemDatasList = JsonConvert.DeserializeObject<List<ItemDataJson>>(scoreJson);
        }
        [ContextMenu(nameof(LoadScoreFromGoogleDrive))]
        void LoadScoreFromGoogleDrive()
        {
            StartCoroutine(LoadScoreRoutine(onlineLoadPath));
        }

        IEnumerator LoadScoreRoutine(string url)
        {
            var webRequest = UnityWebRequest.Get(url);
            
            // Get download progress
            var progress = webRequest.downloadProgress;
            
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                var downloadedText = webRequest.downloadHandler.text;
                Debug.Log("Receive Data : " + downloadedText);
                itemDatasList = JsonConvert.DeserializeObject<List<ItemDataJson>>(downloadedText);
            }
        }
        IEnumerator LoadPhotoFromUrl(string url, Action<Sprite> onReceivePhoto)
        {
            if (string.IsNullOrEmpty(url))
                yield break;
            
            var webRequest = UnityWebRequest.Get(url);
            yield return webRequest.SendWebRequest();
            
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                byte[] bytes = webRequest.downloadHandler.data;
                Texture2D texture = new Texture2D(100, 100);
                texture.LoadImage(bytes);
                var sprite = SpriteCreator.CreateFromTexture(texture);
                onReceivePhoto?.Invoke(sprite);
            }
        }
        void Awake()
        {
            uIItemPrefab.gameObject.SetActive(false);
            LoadScoreData();
            Refresh();       
        }
        [ContextMenu(nameof(ClearUIs))]
        void ClearUIs()
        {
            foreach (var uiPlayerScore in uIItemsList)
                Destroy(uiPlayerScore.gameObject);
            
            uIItemsList.Clear();
        }
        [ContextMenu(nameof(Refresh))]
        void Refresh()
        {
            ClearUIs();
            for (int i = 0; i < itemDatasList.Count; i++)
            {
                var newUI = Instantiate(uIItemPrefab, itemShopParent, false);
                newUI.gameObject.SetActive(true);
                newUI.SetDataJson(itemDatasList[i]);

                var photoUrl = itemDatasList[i].icon;
                StartCoroutine(LoadPhotoFromUrl(photoUrl, newUI.SetPhoto));
                uIItemsList.Add(newUI);
            }
        }
    }
}