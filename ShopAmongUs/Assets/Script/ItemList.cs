using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
namespace ShopUIAmongUs
{
    public class ItemList : MonoBehaviour
    {
        public ItemData[] Items => itemList.ToArray();
        public List<Sprite> allphoto;
        public int Lenght { get; internal set; }

        [SerializeField] List<ItemData> itemList = new List<ItemData>();

        public ItemData[] GetItemByType(CategoryType targetType)
        {
            var resultList = new List<ItemData>();
            foreach (var itemData in itemList)
            {
                if (itemData.type == targetType)
                    resultList.Add(itemData);
            }
            return resultList.ToArray();
        }
        void Start()
        {

        }

        [Header("Saving")]
        [SerializeField] string savePath;
        [SerializeField] string onlineLoadPath;
        public void SetPhoto()
        {
            int i = 0;
            foreach (var icon in allphoto)
            {
                Items[i].icon = icon;
                i++;
            }
        }
        public void LoadScoreFromGoogleDrive()
        {
            StartCoroutine(MyCoroutine(onlineLoadPath));
        }

        IEnumerator MyCoroutine(string url)
        {
            Debug.Log("Coroutine started");
            yield return LoadScoreRoutine(url);
            SetPhoto();
            Debug.Log("Coroutine finished");
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
                itemList = JsonConvert.DeserializeObject<List<ItemData>>(downloadedText);
            }
        }
    }

    [Serializable]
    public class ItemData
    {
        public string displayName;
        public string displayDescription;
        public Sprite icon;
        public int price;
        public CategoryType type;
    }
    public enum CategoryType
    {
        Hats = 1,
        Skins = 2,
        Pets = 3,
        Visors = 4,
        Nameplates = 5
    }
}