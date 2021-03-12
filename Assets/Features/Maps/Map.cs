using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Sire
{
    [Serializable]
    public class Map
    {
        public string Name;
        public string Author;
        public DateTime DateCreated;
        public DateTime DateEdited;
        public MapTile[][] MapTiles;
        public int width;
        public int height;
    }
}
