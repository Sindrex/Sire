using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Sire
{
    public class MapManager : MonoBehaviour
    {
        //Map Management
        public GameObject MapManagementContainer;
        public GameObject MapSaveParent;
        public GameObject MapSavePrefab;
        public InputField MapsSetupMapNameField;
        public InputField MapsSetupMapAuthorField;

        private List<Map> MapList;
        private Map SelectedMap;

        public static MapManager Instance {get;private set;}
        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                return;
            }
            Destroy(this);
        }

        public void Enable()
        {
            CameraController.Instance.canMove = false;
            MapManagementContainer.SetActive(true);
            LoadMaps();
        }

        public void Disable()
        {
            CameraController.Instance.canMove = true;
            MapManagementContainer.SetActive(false);
        }

        public void ShowMapDetails(Map map)
        {
            SelectedMap = map;
            MapsSetupMapNameField.text = map.Name;
            MapsSetupMapAuthorField.text = map.Author;
        }

        public void NewMap()
        {
            Disable();
            MapMakerManager.Instance.SetupMap.Enable();
        }

        public void LoadMap()
        {
            Disable();
            MapMakerManager.Instance.LoadMap(SelectedMap);
        }

        public void LoadMaps()
        {
            MapList = SaveLoadMap.LoadAll();

            //destroy previous
            List<GameObject> removeList = new List<GameObject>();
            foreach (Transform child in MapSaveParent.transform)
            {
                removeList.Add(child.gameObject);
            }
            for(int i = removeList.Count - 1; i >= 0; i--)
            {
                Destroy(removeList[i]);
            }

            foreach(Map map in MapList)
            {
                GameObject go = Instantiate(MapSavePrefab, MapSaveParent.transform);
                go.GetComponent<MapSaveController>().Set(map);
            }
        }

        public void SaveMetaMap()
        {

        }
    }
}