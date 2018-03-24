using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Serializer
{
    public static void Save(string filename, object obj)
    {
        System.IO.Directory.CreateDirectory(@"SaveData\");
        FileStream fileStream = new FileStream(@"SaveData\" + filename, FileMode.Create);
        new BinaryFormatter().Serialize(fileStream, obj);
        fileStream.Close();
    }
    public static object Load(string filename)
    {
        FileStream fileStream = new FileStream(@"SaveData\" + filename, FileMode.Open);
        object obj = new BinaryFormatter().Deserialize(fileStream);
        fileStream.Close();
        return obj;
    }
    public static List<string> checkSaveData()
    {
        try
        {
            List<string> temp = new List<string>(Directory.GetFiles(@"SaveData\"));
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].StartsWith(@"Savedata\") && temp[i].EndsWith(@".savedata"))
                {
                    temp[i] = temp[i].Substring((@"SaveData").Length, temp[i].Length - (@".savedata").Length);
                }
                else
                {
                    i--;
                    temp.Remove(temp[i]);
                }
            }
            return temp;
        }
        catch (System.IO.DirectoryNotFoundException)
        {
            Directory.CreateDirectory(@"Savedata\");
            return new List<string>(0);
        }
    }
}
