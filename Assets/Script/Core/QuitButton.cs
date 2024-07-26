using UnityEngine;
using UnityEngine.EventSystems;
namespace AggiaCreation.SaplingSaga
{
    public class QuitButton : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            AudioSystem.Instance.SelectBtn();
            Application.Quit();
        }
    }
}