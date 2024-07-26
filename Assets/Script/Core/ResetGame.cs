using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace AggiaCreation.SaplingSaga
{
    public class ResetGame : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            AudioSystem.Instance.SelectBtn();
            SaveVarible.Instance.AudioVolume = 1;
            SaveVarible.Instance.WaterTree = 0;
        }
    }
}