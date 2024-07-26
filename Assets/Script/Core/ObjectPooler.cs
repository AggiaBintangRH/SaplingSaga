using System.Collections.Generic;
using UnityEngine;
using System;
namespace AggiaCreation.SaplingSaga
{
	[Serializable]
	public class ObjectPoolItem
	{

		public GameObject objectToPool;
		public int amountToPool;
		public bool shouldExpand = true;

		public ObjectPoolItem(GameObject obj, int amt, bool exp = true)
		{
			objectToPool = obj;
			amountToPool = Mathf.Max(amt, 2);
			shouldExpand = exp;
		}
	}

	public class ObjectPooler : MonoBehaviour
	{
		public static ObjectPooler SharedInstance;
		public List<ObjectPoolItem> m_water;
		public List<ObjectPoolItem> m_rock;


		public List<List<GameObject>> pooledObjectWater, pooledObjectRock;
		public List<GameObject> pooledBoxWater, pooledRock;
		private List<int> posBoxWater, posRock;

		void Awake()
		{
			SharedInstance = this;

			#region Water
			pooledObjectWater = new List<List<GameObject>>();
			pooledBoxWater = new List<GameObject>();
			posBoxWater = new List<int>();
			#endregion

			#region Rock
			pooledObjectRock = new List<List<GameObject>>();
			pooledRock = new List<GameObject>();
			posRock = new List<int>();
			#endregion



			for (int i = 0; i < m_water.Count; i++)
			{
				ObjectPoolWater(i);
			}
			for (int i = 0; i < m_rock.Count; i++)
			{
				ObjectPoolRock(i);
			}

		}

		#region Water
		public GameObject GetWater(int index)
		{

			int curSize = pooledObjectWater[index].Count;
			for (int i = posBoxWater[index] + 1; i < posBoxWater[index] + pooledObjectWater[index].Count; i++)
			{

				if (!pooledObjectWater[index][i % curSize].activeInHierarchy)
				{
					posBoxWater[index] = i % curSize;
					return pooledObjectWater[index][i % curSize];
				}
			}

			if (m_water[index].shouldExpand)
			{

				GameObject obj = (GameObject)Instantiate(m_water[index].objectToPool);
				obj.name = "Water";
				obj.SetActive(false);
				obj.transform.parent = this.transform;
				pooledObjectWater[index].Add(obj);
				return obj;

			}
			return null;
		}

		public List<GameObject> GetAllpooledWater(int index)
		{
			return pooledObjectWater[index];
		}


		public int AddWater(GameObject GO, int amt = 3, bool exp = true)
		{
			ObjectPoolItem item = new ObjectPoolItem(GO, amt, exp);
			int currLen = m_water.Count;
			m_water.Add(item);
			ObjectPoolWater(currLen);
			return currLen;
		}


		void ObjectPoolWater(int index)
		{
			ObjectPoolItem item = m_water[index];

			pooledBoxWater = new List<GameObject>();
			for (int i = 0; i < item.amountToPool; i++)
			{
				GameObject obj = (GameObject)Instantiate(item.objectToPool);
				obj.name = "Water";
				obj.SetActive(false);
				obj.transform.parent = this.transform;
				pooledBoxWater.Add(obj);
			}
			pooledObjectWater.Add(pooledBoxWater);
			posBoxWater.Add(0);

		}
		#endregion

		#region Rock
		public GameObject GetRock(int index)
		{

			int curSize = pooledObjectRock[index].Count;
			for (int i = posRock[index] + 1; i < posRock[index] + pooledObjectRock[index].Count; i++)
			{

				if (!pooledObjectRock[index][i % curSize].activeInHierarchy)
				{
					posRock[index] = i % curSize;
					return pooledObjectRock[index][i % curSize];
				}
			}

			if (m_rock[index].shouldExpand)
			{

				GameObject obj = (GameObject)Instantiate(m_rock[index].objectToPool);
				obj.name = "Rock";
				obj.SetActive(false);
				obj.transform.parent = this.transform;
				pooledObjectRock[index].Add(obj);
				return obj;

			}
			return null;
		}

		public List<GameObject> GetAllpooledRock(int index)
		{
			return pooledObjectRock[index];
		}


		public int AddRock(GameObject GO, int amt = 3, bool exp = true)
		{
			ObjectPoolItem item = new ObjectPoolItem(GO, amt, exp);
			int currLen = m_rock.Count;
			m_rock.Add(item);
			ObjectPoolRock(currLen);
			return currLen;
		}


		void ObjectPoolRock(int index)
		{
			ObjectPoolItem item = m_rock[index];

			pooledRock = new List<GameObject>();
			for (int i = 0; i < item.amountToPool; i++)
			{
				GameObject obj = (GameObject)Instantiate(item.objectToPool);
				obj.name = "Rock";
				obj.SetActive(false);
				obj.transform.parent = this.transform;
				pooledRock.Add(obj);
			}
			pooledObjectRock.Add(pooledRock);
			posRock.Add(0);

		}
		#endregion


	}
}