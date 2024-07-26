using UnityEngine;
namespace AggiaCreation.SaplingSaga
{
    public class Spawner : MonoBehaviour
    {
        private void Start()
        {
            InvokeRepeating(nameof(SpawnObjectWater), 1f, 1.5f);
            InvokeRepeating(nameof(SpawnObjectRock), 2f, 2f);
        }
        private void Update()
        {
            if (!GameplayManager.Instance.CanMove)
            {
                CancelInvoke(nameof(SpawnObjectWater));
                CancelInvoke(nameof(SpawnObjectRock));
            }
        }
        private void SpawnObjectWater()
        {
            // Generate a random X position between -3 and 3
            float xPosition = Random.Range(-3f, 3f);
            // You can set the Y and Z positions to whatever you need
            Vector3 spawnPosition = new Vector3(xPosition, 10, 0);

            GameObject water = ObjectPooler.SharedInstance.GetWater(0);
            if (water != null)
            {
                water.transform.position = spawnPosition;
                water.transform.rotation = Quaternion.identity;
                water.SetActive(true);
            }
        }

        private void SpawnObjectRock()
        {
            // Generate a random X position between -3 and 3
            float xPosition = Random.Range(-4f, 4f);
            // You can set the Y and Z positions to whatever you need
            Vector3 spawnPosition = new Vector3(xPosition, 10, 0);

            GameObject rock = ObjectPooler.SharedInstance.GetRock(0);
            if (rock != null)
            {
                rock.transform.position = spawnPosition;
                rock.transform.rotation = Quaternion.identity;
                rock.SetActive(true);
            }
        }
    }
}