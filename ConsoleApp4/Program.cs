using System.Xml.Serialization;
using System.IO;
using System.IO.Compression;
using Animals;
using System.Text;

class Program
{


    static string DirSearch( string startDirectory, string fileName )
    {
        //  Обработка исключения ошибки доступа
        try
        {
            var testname = Directory.GetFiles(startDirectory);
        }
        catch (System.UnauthorizedAccessException)
        {
            return null;
        }

        var names = Directory.GetFiles(startDirectory);
        foreach (var pos in names)
        {
            if (pos.Substring( pos.Length - fileName.Length ) == fileName)
                return pos;
        }

        var dirs = Directory.GetDirectories(startDirectory);
        foreach (var pos in dirs)
        {
            string str = DirSearch( pos, fileName );
            if (str != null)
                return str;
        }
        return null;
    }

    static void Main()
    {

        string fileName = "Lab08File.xml";
        ///*

        // Сериализация в файл
        {
            var xmlSerializer = new XmlSerializer(typeof(Lion));
            var fout = new FileStream(fileName, FileMode.OpenOrCreate);
            var SerializedLion = new Lion("Africa", false, "Simba");
            Console.WriteLine( "Class instance before serialization:" );
            SerializedLion.Print();
            Console.WriteLine();
            xmlSerializer.Serialize( fout, SerializedLion );
            fout.Close();
        }
        // Десериализация из файла
        {
            var xmlSerializer = new XmlSerializer(typeof(Lion));
            var fin = new FileStream(fileName, FileMode.OpenOrCreate);
            Lion? DeserializedLion = xmlSerializer.Deserialize(fin) as Lion;
            Console.WriteLine( "Deserialized instance of the class:" );
            DeserializedLion.SayHello();
            DeserializedLion.Print();
            fin.Close();
        }
        //*/
        /*
        // Задание 2
        Console.OutputEncoding = Encoding.UTF8;
        //Console.Write( "File name: " );
        //string? fileName = Console.ReadLine();
        Console.Write( "Start directory: " );
        string? startDirectory = Console.ReadLine();
        Console.WriteLine();

        string? filepath = DirSearch(startDirectory, fileName );
        Console.WriteLine( filepath );
        if (filepath == null)
        {
            Console.WriteLine( "The file was not found in the specified directory" );
        }
        else
        {
            using (var fsSource = new FileStream( filepath, FileMode.Open, FileAccess.Read ))
            {
                byte[] bytes = new byte[fsSource.Length];
                int numBytesToRead = (int)fsSource.Length;
                int numBytesReaded = 0;

                while (numBytesToRead > 0)
                {
                    int n = fsSource.Read(bytes, numBytesReaded, numBytesToRead);
                    if (n == 0) break;
                    numBytesReaded += n;
                    numBytesToRead -= n;
                }

                numBytesToRead = bytes.Length;

                Console.WriteLine( "File Contents:" );
                foreach (var pos in bytes)
                {
                    Console.Write( (char)pos );
                }
                Console.WriteLine();
                Console.WriteLine( "End of file!" );
                Console.WriteLine();

                fsSource.Close();
            }
            // Ниже описан алгоритм сжатия файла стандартными методами .NET
            // Имя будущего сжатого файла
            string ZipFile = "./lab08file.zip";
            // Создаём файл архива и подключаем к нему поток
            FileStream zipStream = File.Create(ZipFile);
            // Создаём архив, в который потом запишем необходимый нам файл
            using ZipArchive archive = new(zipStream, ZipArchiveMode.Create);
            // Точка входа для данных из файла в архив
            ZipArchiveEntry entry = archive.CreateEntry(Path.GetFileName(filepath));
            // Создаём поток чтения данных из несжатого файла
            using FileStream inputStream = File.OpenRead(filepath);
            // Создаём поток для записи данных в архив
            using Stream outputStream = entry.Open();
            // Записываем данные в архив
            inputStream.CopyTo( outputStream );


            Console.WriteLine( "Archiving is complete!" );
            DirSearch( startDirectory, "lab08file.zip" );
        }

        */
    }
}