using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BattleShip
{
    class SerializeUtilities<T>
    {
        private static IFormatter formatter = new BinaryFormatter();

        
        private SerializeUtilities() { }

        
        public static void Serialize(T obj, string fileName)
        {
            if(obj == null)
            {
                throw new ArgumentException();
            }
            else if(fileName == null || fileName.Trim().Length == 0)
            {
                throw new ArgumentException();
            }

            if(!obj.GetType().IsSerializable)
            {
                throw new ArgumentException("Параметр объекта" + obj.ToString() + " должен быть ");
            }

            
            Stream fileStream = new FileStream
                (fileName, FileMode.Create, FileAccess.Write, FileShare.None);

            try
            {
                
                formatter.Serialize(fileStream, obj);
            }
           
            finally
            {
                if(fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }

        
        public static T Deserialize(string fileName)
        {
            if (fileName == null || fileName.Trim().Length == 0)
            {
                throw new ArgumentException();
            }

            
            Stream fileStream = new FileStream
                (fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            T toReturn;

            try
            {
                
                object obj = formatter.Deserialize(fileStream);

                
                if(obj.GetType() != typeof(T))
                {
                    throw new ArgumentException(" deserialized object " + obj.ToString() + " не относится к типу Т: " + typeof(T).ToString());
                }

                toReturn = (T)obj;

            }
            
            finally
            {
                if(fileStream != null)
                {
                    fileStream.Close();
                }
            }

            return toReturn;
        }
    }
}
