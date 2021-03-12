using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sire
{
    public class MapTileController : MonoBehaviour
    {
        public int xIndex;
        public int yIndex;
        public MapTile MyTile;

        public Image MyImage;
        public Color NormalColor;
        public Color SelectedColor;

        public bool IsSelected;

        public virtual void Click()
        {
            //MapMakerManager.Instance.TileSelectTab.SelectTile(this);
        }

        public void Select()
        {
            MyImage.color = SelectedColor;
            IsSelected = true;
        }

        public void UnSelect()
        {
            MyImage.color = NormalColor;
            IsSelected = false;
        }
    }
}