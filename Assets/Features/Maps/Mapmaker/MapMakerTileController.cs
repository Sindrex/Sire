using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sire
{
    public class MapMakerTileController : MapTileController
    {
        public override void Click()
        {
            MapMakerManager.Instance.TileSelectTab.SelectTile(this);
        }
    }
}
