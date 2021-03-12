using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

namespace Sire
{
    public static class SaveLoad
    {
        public static bool CreateFile(object save, string saveName, string path, string postfix) //Save 1 savefile
        {
            Debug.Log($"Creating new file as: {path + saveName + postfix}");
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Create(path + saveName + postfix);
                bf.Serialize(file, save);
                file.Close();
                return true;
            }
            catch (Exception e)
            {
                Debug.Log(e);
                return false;
            }
        }

        public static bool RemoveFile(string saveName, string path, string postfix)
        {
            Debug.Log($"Removing save: {saveName}");
            try
            {
                if (Exists(saveName, path, postfix))
                {
                    File.Delete(path + saveName + postfix);
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.Log(e);
                return false;
            }
        }

        public static List<T> LoadAll<T>(string path, string postfix)
        {
            Debug.Log($"Loading {postfix} saves from: {path}");
            try
            {
                List<T> saves = new List<T>();
                BinaryFormatter bf = new BinaryFormatter();
                Directory.CreateDirectory(path);
                DirectoryInfo di = new DirectoryInfo(path);
                FileInfo[] files = di.GetFiles("*" + postfix);
                foreach (FileInfo fi in files)
                {
                    FileStream file = fi.Open(FileMode.Open);
                    saves.Add((T)bf.Deserialize(file));
                    file.Close();
                }
                return saves;
            }
            catch (Exception e)
            {
                Debug.Log(e);
                return null;
            }
        }

        public static T Load<T>(string saveName, string path, string postfix)
        {
            Debug.Log($"Loading save: {saveName}");
            try
            {
                T save = default(T);
                if(Exists(saveName, path, postfix))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream file = File.Open(path + saveName + postfix, FileMode.Open);
                    save = (T)bf.Deserialize(file);
                    file.Close();
                }
                return save;
            }
            catch (Exception e)
            {
                Debug.Log(e);
                return default(T);
            }
        }

        public static bool Exists(string saveName, string path, string postfix)
        {
            return File.Exists(path + saveName + postfix);
        }
    }
}