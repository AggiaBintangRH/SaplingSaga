using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace AggiaCreation.SaplingSaga
{
    public class OpenScene : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private string m_sceneName;
        [SerializeField] private int m_indexBtn;
        public void OnPointerClick(PointerEventData eventData)
        {
            if (m_indexBtn == 0)
                AudioSystem.Instance.SelectBtn();
            else if (m_indexBtn == 1)
                AudioSystem.Instance.DeselectBtn();

            SaveVarible.Instance.SavePlayer();
            SceneManager.LoadScene(m_sceneName);
        }
    }
}