using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace AggiaCreation.SaplingSaga
{
    public class Tutorial : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject m_howToPlay;
        [SerializeField] private int m_index;
        public void OnPointerClick(PointerEventData eventData)
        {
            AudioSystem.Instance.SelectBtn();
            if (m_index == 0)
            {
                m_howToPlay.SetActive(true);
            }
            else
            {
                m_howToPlay.SetActive(false);
            }
        }
    }
}