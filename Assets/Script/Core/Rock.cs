using UnityEngine;
namespace AggiaCreation.SaplingSaga
{
    public class Rock : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("Ground"))
                this.gameObject.SetActive(false);

            if (collision.transform.CompareTag("Bucket") || collision.transform.CompareTag("Player"))
            {
                AudioSystem.Instance.RockDrop();
                GameplayManager.Instance.WaterQty--;
                this.gameObject.SetActive(false);
            }
        }
    }
}