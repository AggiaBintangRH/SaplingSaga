using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace AggiaCreation.SaplingSaga
{
    public class GrowTreeUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text m_textProgress;

        Rigidbody Rigidbody;
        private void Update()
        {

            m_textProgress.text = TreeSystem.Instance.WaterQty.ToString() + " / 15";

        }
    }
}