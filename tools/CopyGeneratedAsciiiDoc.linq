<Query Kind="Program" />

/// <summary>
/// Input: Arguments
/// 		- a file that contains a list of asciidoc file processed
/// 		- The type of processed document pdf/html
/// 		- The destination folder. Note for HTML a folder with the name of the file will be created.
/// 			in this file the html main file and img folder (if exis) will be copied.
/// 		
/// </summary>

void Main(string[] args)
{
#if !CMD
	args = new[] { @"D:\ccp_wrks\KnowledgeManagement\tools\AsciiDocDocumentToProcess.txt", "html", @"D:\ccp_wrks\KnowledgeManagement\books\pdf" };
#endif
	foreach (var line in File.ReadLines(args[0]))
	{
		CopyAsciidocGeneratedFiles(line, args[1], args[2]);
		Console.WriteLine(line + " Processed");
	}

}




/// <summary>
///   Run asciidoctorj with asciictor-diagram to process plantuml or graphviz doc
/// </summary>
public static void CopyAsciidocGeneratedFiles(string filePath, string type, string destinationPath)
{
	
	type = type.ToLower();
	var srcPath = Path.GetDirectoryName(filePath) + Path.GetFileNameWithoutExtension(filePath) + "." + type;
	string dstPath;
	if (type == "pdf")
		dstPath = Path.GetDirectoryName(destinationPath) + Path.GetFileNameWithoutExtension(filePath) + "." + type;
	else
		dstPath = Path.GetDirectoryName(destinationPath) + Path.GetFileNameWithoutExtension(filePath) + @"\" + Path.GetFileNameWithoutExtension(filePath) + "." + type;
	File.Move(srcPath, dstPath);
	Console.WriteLine(srcPath + " moved succesfully.");
	// If HTML the Images should be also moved.
	
	if (type == "html")
	{
		var imgPath = srcPath = Path.GetDirectoryName(filePath) + "img";
		var rootDestinationPath = dstPath = Path.GetDirectoryName(destinationPath) + Path.GetFileNameWithoutExtension(filePath) + @"\" + Path.GetFileNameWithoutExtension(filePath) +  @"\img";
		foreach (string file in Directory.EnumerateFiles(imgPath))
		{
			var fileDestination = rootDestinationPath + Path.GetFileName(file);
			File.Copy(file, fileDestination);
			Console.WriteLine(srcPath + " image copyied succesfully.");
		}
	}
	
	

}

// You can define other methods, fields, classes and namespaces here
