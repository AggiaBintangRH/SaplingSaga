using UnityEngine;
using UnityEngine.EventSystems;
namespace AggiaCreation.SaplingSaga
{
    public class Pause : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject m_panelPause;
        [SerializeField] private int m_indexPause;

        private void Start()
        {
            m_panelPause.SetActive(false);
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            AudioSystem.Instance.SelectBtn();
            if (m_indexPause == 0)
            {
                m_panelPause.SetActive(true);
                Time.timeScale = 0;
            }
            else if(m_indexPause == 1)
            {
                Time.timeScale = 1;
                m_panelPause.SetActive(false);
            }
        }
    }
}