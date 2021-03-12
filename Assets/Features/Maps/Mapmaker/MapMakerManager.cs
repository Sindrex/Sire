using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Sire
{
    public class MapMakerManager : MonoBehaviour
    {
        public Map CurrentMap;
        public List<MapMakerTileController> Tiles;

        //Setup map
        public SetupMap SetupMap;

        //Select
        public TileSelectTab TileSelectTab;

        //Map Management
        public MapManager MapManager;

        //Bars
        public GameObject TopBar;
        public GameObject BotBar;

        public static MapMakerManager Instance {get;private set;}
        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                return;
            }
            Destroy(this);
        }

        // Start is called before the first frame update
        void Start()
        {
            CameraController.Instance.canMove = false;

            MapManager.Disable();
            TileSelectTab.Disable();
            SetupMap.Disable();

            MapManager.Enable();
        }

        public void BackToMainMenu()
        {
            GameSceneManager.Instance.LoadScene(GameSceneManager.Scene.MainMenu);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void SaveMap()
        {
            if(CurrentMap == null) return;
            
            SaveLoadMap.Save(CurrentMap);
        }

        public void LoadMap(Map map)
        {
            CurrentMap = map;
            SetupMap.SpawnMap(CurrentMap);
        }

        public void FlushTiles()
        {
            for(int i = Tiles.Count - 1; i >= 0; i--)
            {
                MapMakerTileController go = Tiles[i];
                Tiles.Remove(go);
                Destroy(go.gameObject);
            }
        }
    }
}