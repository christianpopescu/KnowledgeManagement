<Query Kind="Program" />

/// <summary>
/// Input: One argument a file that contains a list of asciidoc file to process
/// </summary>

void Main(string[] args)
{
#if !CMD
	args = new[] { @"D:\Temp\AsciiDocDocumentToProcess.txt", "html" };
#endif
	foreach (var line in File.ReadLines(args[0]))
	{
		BuildAsciiDoc(line, args[1]);
		Console.WriteLine(line + " Processed");
	}

}


public static void BuildAsciiDoc(string filePath, string type)
{
	var process = new Process();
	process.StartInfo.FileName = "cmd.exe";
	process.StartInfo.Arguments = "/c asciidoctorj.bat -b " + type + " " + Path.GetFileName(filePath);
	process.StartInfo.WorkingDirectory = Path.GetDirectoryName(filePath);
	process.StartInfo.RedirectStandardOutput = true;
	process.StartInfo.UseShellExecute = false;
	process.StartInfo.CreateNoWindow = true;

	process.Start();
	string output = process.StandardOutput.ReadToEnd();
	process.WaitForExit();

}

/// <summary>
///   Run asciidoctorj with asciictor-diagram to process plantuml or graphviz doc
/// </summary>
public static void BuildAsciiDocWithDiagrams(string filePath, string type)
{
	var process = new Process();
	process.StartInfo.FileName = "cmd.exe";
	// asciidoctorj.bat -r asciidoctor-diagram -b html ArchitectureTools.asciidoc
	process.StartInfo.Arguments = "/c asciidoctorj.bat -r asciidoctor-diagram -b " + type + " " + Path.GetFileName(filePath);
	process.StartInfo.WorkingDirectory = Path.GetDirectoryName(filePath);
	process.StartInfo.RedirectStandardOutput = true;
	process.StartInfo.UseShellExecute = false;
	process.StartInfo.CreateNoWindow = true;

	process.Start();
	string output = process.StandardOutput.ReadToEnd();
	process.WaitForExit();

}

// You can define other methods, fields, classes and namespaces here
