using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common
{
    public class Utils
    {
        public static void SaveObjectToFileAsBinary(Object obj, string filepath)
        {
            Stream stream = File.Open(filepath, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, obj);
            stream.Close();
        }

        public static Object LoadObjectToFileAsBinary(string filepath)
        {
            try
            {
                Stream stream = File.Open(filepath, FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                Object obj = binaryFormatter.Deserialize(stream);
                stream.Close();

                return obj;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
