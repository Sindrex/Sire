using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Sire
{
    public class SetupMap : MonoBehaviour
    {
        //create map
        public GameObject SetupMapContainer;
        public InputField SetupMapWidthField;
        public InputField SetupMapHeightField;
        public InputField SetupMapNameField;
        public InputField SetupMapAuthorField;

        //spawn map
        public GameObject MapContainer;
        public int Offset = 30;
        public GameObject MapTilePrefab;
        
        public void Enable()
        {
            CameraController.Instance.canMove = false;
            SetupMapContainer.SetActive(true);
        }

        public void Disable()
        {
            CameraController.Instance.canMove = true;
            SetupMapContainer.SetActive(false);
        }

        public void SetupNewMap()
        {
            Disable();

            Map CurrentMap = new Map
            {
                Name = SetupMapNameField.text,
                Author = SetupMapAuthorField.text,
                DateCreated = DateTime.Today
            };

            Int32.TryParse(SetupMapWidthField.text, out int width);
            Int32.TryParse(SetupMapHeightField.text, out int height);
            CurrentMap.MapTiles = new MapTile[width][];
            CurrentMap.width = width;
            CurrentMap.height = height;

            SpawnMap(CurrentMap);

            MapMakerManager.Instance.CurrentMap = CurrentMap;
        }

        public void SpawnMap(Map map)
        {
            MapMakerManager.Instance.FlushTiles();

            int height = map.height;
            int width = map.width;

            MapMakerManager.Instance.Tiles = new List<MapMakerTileController>();
            Vector3 current = new Vector3();
            for(int x = 0; x < width; x++)
            {
                map.MapTiles[x] = new MapTile[height];
                for(int y = 0; y < height; y++)
                {
                    map.MapTiles[x][y] = new MapTile();
                    GameObject go = Instantiate(MapTilePrefab, MapContainer.transform);
                    go.transform.localPosition = current;
                    MapMakerTileController tile = go.GetComponent<MapMakerTileController>();
                    tile.xIndex = x;
                    tile.yIndex = y;
                    tile.MyTile = map.MapTiles[x][y];
                    MapMakerManager.Instance.Tiles.Add(tile);

                    current = new Vector3(current.x, current.y + Offset, 0);
                }
                current = new Vector3(current.x + Offset, 0, 0);
            }
        }

        public void CancelSetup()
        {
            Disable();
            MapMakerManager.Instance.MapManager.Enable();
        }
    }
}