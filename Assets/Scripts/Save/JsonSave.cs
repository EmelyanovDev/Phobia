using System.IO;
using UnityEngine;

namespace Save
{
    public static class JsonSave 
    {
        private static readonly string JsonPath = Application.persistentDataPath + "/Save.json";

        public static void SaveData(SaveData saveData)
        {
            string data = JsonUtility.ToJson(saveData);
            File.WriteAllText(JsonPath, data);
        }

        public static SaveData LoadData()
        {
            if (File.Exists(JsonPath) == false)
                return new SaveData();
            string data = File.ReadAllText(JsonPath);
            return JsonUtility.FromJson<SaveData>(data);
        }
    }
}