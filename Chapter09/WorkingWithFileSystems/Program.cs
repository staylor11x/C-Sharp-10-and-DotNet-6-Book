using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using static System.Formats.Asn1.AsnWriter;

//OutputFileSystemInfo();
//WorkingWithDrives();
//WorkingWithDirectories();
WorkingWithFiles();


static void OutputFileSystemInfo()
{
    WriteLine("{0,-33} {1}", "Path.PathSeperator", PathSeparator);
    WriteLine("{0,-33} {1}", "Path.DirectorySeparatorChar", DirectorySeparatorChar );
    WriteLine("{0,-33} {1}", "Path.GetCurrentDirectory()", GetCurrentDirectory());
    WriteLine("{0,-33} {1}", "Path.CurrentDirectory", CurrentDirectory);
    WriteLine("{0,-33} {1}", "Path.SystemDirectory", SystemDirectory);
    WriteLine("{0,-33} {1}", "Path.GetTempPath()", GetTempPath());

    WriteLine("GetFolderPath(SpecifiedFolder)");
    WriteLine("{0,-33} {1}", ".System", SpecialFolder.System);
    WriteLine("{0,-33} {1}", ".ApplicationData", SpecialFolder.ApplicationData);
    WriteLine("{0,-33} {1}", ".MyDocuments", SpecialFolder.MyDocuments);
    WriteLine("{0,-33} {1}", ".Personal", SpecialFolder.Personal);
}

static void WorkingWithDrives()
{
    WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}",
        "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");

    foreach(DriveInfo drive in DriveInfo.GetDrives())
    {
        if(drive.IsReady)
        {
            WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}",
        drive.Name, drive.DriveType, drive.DriveFormat, drive.TotalSize, drive.AvailableFreeSpace);
        }
        else
        {
            WriteLine("{0,-30} | {1,-10}", drive.Name, drive.DriveType);
        }
    }
}

static void WorkingWithDirectories()
{
    // Define a direcroty path for a new folder
    // starting in the user's folder
    string newFolder = Combine(GetFolderPath(SpecialFolder.Personal),"Code", "Chapter09", "NewFolder");

    WriteLine($"Working with: {newFolder}");

    //check if it exists
    WriteLine($"Does it exist? {Exists(newFolder)}");

    //create directory
    WriteLine("Creating it...");
    CreateDirectory(newFolder);
    WriteLine($"Does it exist? {Exists(newFolder)}");
    Write("Confirm the directory exists, and then press ENTER: ");
    ReadLine();

    //delete directory
    WriteLine("Deleting it...");
    Delete(newFolder, recursive: true);
    WriteLine($"Does it exist? {Exists(newFolder)}");
}

static void WorkingWithFiles()
{
    // define a directory path to the output files
    // starting in the user's folder

    string dir = Combine(GetFolderPath(SpecialFolder.UserProfile),"OneDrive","Dev","C# Course","Chapter09","OutputFiles");

    CreateDirectory(dir);

    //define file paths
    string textFile = Combine(dir, "Dummy.txt");
    string backupFile = Combine(dir, "Dummy.bak");
    WriteLine($"Working with: {textFile}");

    // check if file exists
    WriteLine($"Does it exist? {File.Exists(textFile)}");

    // creat a new file and write a line to it
    StreamWriter textWriter = File.CreateText( textFile );
    textWriter.WriteLine("Hello C#!");
    textWriter.Close(); //close the file and release the resources
    WriteLine($"Does it exist? {File.Exists(textFile)}");

    // copy the file and overwrite if it already exists
    File.Copy(sourceFileName: textFile, destFileName: backupFile, overwrite: true);
    Write("Confirm the files exist, and then press ENTER: ");
    ReadLine();

    // delete file
    File.Delete(textFile);
    WriteLine($"Does the file exist? {File.Exists(textFile)}");

    // read from the text file backup
    WriteLine($"Reading contents of {backupFile}:");
    StreamReader textReader = File.OpenText(backupFile);
    WriteLine(textReader.ReadToEnd());
    textReader.Close();

    // managing paths
    WriteLine($"Folder Name: {GetDirectoryName(textFile)}");
    WriteLine($"File Name: {GetFileName(textFile)}");
    WriteLine($"FIle name without extension: {0}", GetFileNameWithoutExtension(textFile));
    WriteLine($"FIle Extension: {GetExtension(textFile)}");
    WriteLine($"Random File Name: {GetRandomFileName()}");
    WriteLine($"Temporary file name: {GetTempFileName()}");

    FileInfo info = new(backupFile);
    WriteLine($"{backupFile}:");
    WriteLine($"Contains {info.Length} bytes");
    WriteLine($"Last accessed {info.LastAccessTime}");
    WriteLine($"Has readonly set to {info.IsReadOnly}");

}