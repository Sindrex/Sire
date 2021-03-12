using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Sire
{
    [Serializable]
    public class MapTile
    {
        public int xIndex;
        public int yIndex;
        public int Terrain;
        public Building Building;
    }
}
