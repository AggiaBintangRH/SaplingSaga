using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AggiaCreation.SaplingSaga
{
    public class WaterDrop : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("Ground"))
                this.gameObject.SetActive(false);

            if (collision.transform.CompareTag("Bucket"))
            {
                AudioSystem.Instance.WaterDrop();
                GameplayManager.Instance.WaterQty++;
                this.gameObject.SetActive(false);
            }
        }
    }
}