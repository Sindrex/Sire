using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sire
{
    public static class SaveLoadMap
    {
        private static string Postfix = ".map";
        private static string PersistentPath = Application.persistentDataPath;
        private static string SavePath = PersistentPath + "/maps/";
        
        public static bool Save(Map map)
        {
            return SaveLoad.CreateFile(map, map.Name, SavePath, Postfix);
        }
        public static bool Remove(Map map)
        {
            return SaveLoad.RemoveFile(map.Name, SavePath, Postfix);
        }
        public static List<Map> LoadAll()
        {
            return SaveLoad.LoadAll<Map>(SavePath, Postfix);
        }
        public static Map Load(string saveName)
        {
            return SaveLoad.Load<Map>(saveName, SavePath, Postfix);
        }
        public static bool Exists(string saveName)
        {
            return SaveLoad.Exists(saveName, SavePath, Postfix);
        }
    }
}
