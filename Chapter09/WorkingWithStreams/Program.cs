using static System.Console;
using System.Xml;
using static System.Environment;
using static System.IO.Path;
using System.Xml.Schema;
using System.IO.Compression;

string currentDirectory = Combine(GetFolderPath(SpecialFolder.UserProfile), "OneDrive", "Dev", "C# Course", "Chapter09","OutputFiles");

//WorkingWithText(currentDirectory);
WorkingWithXML(currentDirectory);
WorkingWithCompression(currentDirectory);
WorkingWithCompression(currentDirectory, useBrotli: false);

static void WorkingWithText(string currentDirectory)
{
    //define a file to write to
    string textFile = Combine(currentDirectory, "Streams.txt");

    // create a text file and return a helpful writer
    StreamWriter text = File.CreateText(textFile);

    // enumerate the strings, writing each one to the stream on a seperate line
    foreach(string item in Viper.CallSigns)
    {
        text.WriteLine(item);
    }
    text.Close();

    // output the contents of the file
    WriteLine("{0} contains {1:N0} bytes.", textFile, new FileInfo(textFile).Length);

    WriteLine(File.ReadAllText(textFile));
}

static void WorkingWithXML(string currentDirectory)
{
    FileStream? xmlFileStream = null;
    XmlWriter? xml = null;

    try
    {
        //define a file to write to
        string xmlFile = Combine(currentDirectory, "streams.xml");

        //create a file stream
        xmlFileStream = File.Create(xmlFile);

        //wrap the file stream in an xml writer helper and automatically indent nested elements
        xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });

        //write the xml declaration
        xml.WriteStartDocument();

        //write the root element
        xml.WriteStartElement("Callsigns");

        //enumerate the strings writing each one to the stream
        foreach (string item in Viper.CallSigns)
        {
            xml.WriteElementString("callsign", item);
        }

        //write the close root element
        xml.WriteEndElement();

        //close helper and steam 
        xml.Close();
        xmlFileStream.Close();

        //output all the elements of the file
        WriteLine("{0} contains {1:N0} bytes.", xmlFile, new FileInfo(xmlFile).Length);

        WriteLine(File.ReadAllText(xmlFile));
    }
    catch(Exception ex)
    {
        // if the path dosen't exist the exception will be caught
        WriteLine($"{ex.GetType()} says {ex.Message}");

    }
    finally         //this section can be better optimised if you use the 'using' statement to call the writer
    {
        if(xml != null)
        {
            xml.Dispose();
            WriteLine("The XML Writer's unmanaged resources have been disposed.");
        }
        if(xmlFileStream != null)
        {
            xmlFileStream.Dispose();
            WriteLine("The file stream's unmanaged resources have been disposed.");
        }
    }
}

static void WorkingWithCompression(string currentDirectory, bool useBrotli = true)
{
    string fileExt = useBrotli ? "brolti" : "gzip";
    

    //compress the xml output
    string filePath = Combine(currentDirectory, $"streams.{fileExt}");

    FileStream file = File.Create(filePath);

    Stream compressor;

    if (useBrotli)
    {
        compressor = new BrotliStream(file, CompressionMode.Compress);
    }
    else
    {
        compressor = new GZipStream(file, CompressionMode.Compress);
    }

    using (compressor)
    {
        using(XmlWriter xml = XmlWriter.Create(compressor))
        {
            xml.WriteStartDocument();
            xml.WriteStartElement("Callsigns");

            foreach(string item in Viper.CallSigns)
            {
                xml.WriteElementString("callsign", item);
            }

            // the normal call to WriteEndElement is not necessary bacuse when the xml writer disposes, it will 
            // automatically end any elements of any depth
        }
    }   //also closes the underlying stream

    //output all the contents of the uncompressed file
    WriteLine("{0} contains {1:N0} bytes. ", filePath, new FileInfo(filePath).Length);

    WriteLine($"The compressed contents: ");
    WriteLine(File.ReadAllText(filePath));

    //read the compressed file
    WriteLine("Reading from the compresesd xml file");
    file = File.Open(filePath, FileMode.Open);

    Stream decompressor;
    if (useBrotli)
    {
        decompressor = new BrotliStream(file, CompressionMode.Decompress);
    }
    else
    {
        decompressor = new GZipStream(file, CompressionMode.Decompress);
    }

    using (decompressor)
    {
        using(XmlReader reader = XmlReader.Create(decompressor))
        {
            while (reader.Read())   //read the next xml node
            {
                //check if we are on an element node named callsign
                if((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign"))
                {
                    reader.Read();  //move to the text inside element
                    WriteLine($"{reader.Value}");   //read its value
                }
            }
        }
    }
}




static class Viper
{
    // define an array of viper pilot call signs
    public static string[] CallSigns = new[]
    {
        "Husker","Starbuck","Apollo","Boomer","Bulldog","Athena","Helo","Racetrack"
    };
}