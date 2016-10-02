using System.IO;
using System.Xml.Serialization;

namespace _03.Paths
{
    public static class Storage
    {
        public static Path3D LoadPath(string source)
        {
            using (var reader = new StreamReader(source))
            {
                var serializer = new XmlSerializer(typeof(Path3D));
                return (Path3D) serializer.Deserialize(reader);
            }
        }

        public static void SavePath(string destination, Path3D path)
        {
            using (var writer = new StreamWriter(destination))
            {
                var serializer = new XmlSerializer(path.GetType());
                serializer.Serialize(writer,path);
            }
        }
    }
}