using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Sire
{
    public class TileSelectTab : MonoBehaviour
    {
        //Select
        private MapMakerTileController SelectedTile;
        public GameObject SelectedTab;
        public Image SelectedTileImage;
        public Text SelectedTileCoords;
        public Dropdown Terrain;
        public Dropdown Building;
        public Text[] Upgrades;
        
        public void Enable()
        {
            SelectedTab.SetActive(true);
        }

        public void Disable()
        {
            SelectedTab.SetActive(false);
        }

        public void SelectTile(MapMakerTileController selected)
        {
            foreach (var item in MapMakerManager.Instance.Tiles)
            {
                if(!item.Equals(selected)) item.UnSelect();
            }
            if(!selected.IsSelected)
            {
                selected.Select();
                SelectedTab.SetActive(true);
            }
            else
            {
                selected.UnSelect();
                SelectedTab.SetActive(false);
            }
        }
    }
}