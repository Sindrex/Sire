using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sire
{
    public class MapSaveController : MonoBehaviour
    {
        private Map MyMap;
        public Text NameText;

        public void Set(Map map)
        {
            MyMap = map;
            NameText.text = map.Name;
        }

        public void Click()
        {
            MapManager.Instance.ShowMapDetails(MyMap);
        }
    }
}
