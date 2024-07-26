using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace AggiaCreation.SaplingSaga
{
    public class MuteSound : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Sprite[] m_spriteSound;
        [SerializeField] private Image m_imageSound;

        private void Update()
        {
            AudioSystem.Instance.ChangeVolume(SaveVarible.Instance.AudioVolume);
            if (SaveVarible.Instance.AudioVolume == 0)
            {
                m_imageSound.sprite = m_spriteSound[0];
            }
            else if (SaveVarible.Instance.AudioVolume == 1)
            {
                m_imageSound.sprite = m_spriteSound[1];
            }
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            AudioSystem.Instance.SelectBtn();
            if (SaveVarible.Instance.AudioVolume == 0)
            {
                m_imageSound.sprite = m_spriteSound[1];
                SaveVarible.Instance.AudioVolume = 1;
                AudioSystem.Instance.ChangeVolume(SaveVarible.Instance.AudioVolume);
            }
            else if (SaveVarible.Instance.AudioVolume == 1)
            {
                m_imageSound.sprite = m_spriteSound[0];
                SaveVarible.Instance.AudioVolume = 0;
                AudioSystem.Instance.ChangeVolume(SaveVarible.Instance.AudioVolume);
            }
            SaveVarible.Instance.SavePlayer();
        }
    }
}