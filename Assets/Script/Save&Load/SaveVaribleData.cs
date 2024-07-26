using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AggiaCreation.SaplingSaga
{
    [System.Serializable]
    public class SaveVaribleData
    {
        public int WaterTree;
        public float AudioVolume;
        public SaveVaribleData(SaveVarible player)
        {
            WaterTree = player.WaterTree;
            AudioVolume = player.AudioVolume;
        }
    }
}