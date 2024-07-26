using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace AggiaCreation.SaplingSaga
{
    public static class SaveSystems
    {
        public static void SavePlayer(SaveVarible player)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/Player.Data";
            FileStream stream = new FileStream(path, FileMode.Create);

            SaveVaribleData data = new SaveVaribleData(player);
            //Debug.Log("Save File Sucses" + path);

            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static SaveVaribleData LoadPlayer()
        {
            string path = Application.persistentDataPath + "/Player.Data";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                SaveVaribleData data = formatter.Deserialize(stream) as SaveVaribleData;
                stream.Close();

                return data;
            }
            else
            {
                //Debug.LogError("Save File Not Found In" + path);
                return null;
            }
        }
    }
}