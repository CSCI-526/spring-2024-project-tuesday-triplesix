using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class ObstablesCollider : MonoBehaviour
{
    [System.Serializable]
    public class SerializableDictionary
    {
        public List<SerializableKeyValuePair> keyValuePairs = new List<SerializableKeyValuePair>();

        public SerializableDictionary(Dictionary<string, int> dictionary)
        {
            foreach (var kvp in dictionary)
            {
                keyValuePairs.Add(new SerializableKeyValuePair(kvp.Key, kvp.Value));
            }
        }
    }

    [System.Serializable]
    public class SerializableKeyValuePair
    {
        public string key;
        public int value;

        public SerializableKeyValuePair(string key, int value)
        {
            this.key = key;
            this.value = value;
        }
    }

    // Start is called before the first frame update
    private static Dictionary<string, int> dictionary = new Dictionary<string, int>();
    SerializableDictionary dict = new SerializableDictionary(dictionary);
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector2 spawnPoint = GameManager.Instance.respawnPoint;
            if (dictionary.ContainsKey(spawnPoint.ToString()))
            {
                dictionary[spawnPoint.ToString()] += 1;
            }
            else
            {
                dictionary.Add(spawnPoint.ToString(), 1);
            }
            other.transform.position = spawnPoint;
        }
    }
    
    private void OnApplicationQuit()
    {
        foreach (var kvp in dictionary)
        {
            Debug.Log("Key: " + kvp.Key + ", Value: " + kvp.Value);
        }
        SerializableDictionary serializableDictionary = new SerializableDictionary(dictionary);
        File.WriteAllText("death.json", JsonUtility.ToJson(serializableDictionary));
        Debug.Log("quit!!");
    }

}