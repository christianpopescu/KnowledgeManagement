<Query Kind="Program" />

/// <summary>
/// Input: One argument a file that contains a list of asciidoc file to process
/// </summary>

void Main(string[] args)
{
#if !CMD
	args = new[] { @"D:\ccp_wrks\KnowledgeManagement\tools\AsciiDocDocumentToProcess.txt", "pdf" };
#endif
	foreach (var line in File.ReadLines(args[0]))
	{
		Console.WriteLine(BuildAsciiDocWithDiagrams(line, args[1]));
		Console.WriteLine(line + " Processed");
	}

}


public static string BuildAsciiDoc(string filePath, string type)
{
	string result;
	var process = new Process();
	process.StartInfo.FileName = "cmd.exe";
	process.StartInfo.Arguments = "/c asciidoctorj.bat -b " + type + " " + Path.GetFileName(filePath);
	process.StartInfo.WorkingDirectory = Path.GetDirectoryName(filePath);
	process.StartInfo.RedirectStandardOutput = true;
	process.StartInfo.UseShellExecute = false;
	process.StartInfo.CreateNoWindow = true;
	result = process.StartInfo.Arguments + '\n';
	process.Start();
	process.WaitForExit();
	string output = process.StandardOutput.ReadToEnd();
	result += output;
	return result;
	
}

/// <summary>
///   Run asciidoctorj with asciictor-diagram to process plantuml or graphviz doc
/// </summary>
public static string BuildAsciiDocWithDiagrams(string filePath, string type)
{
	string result;
	var process = new Process();
	process.StartInfo.FileName = "cmd.exe";
	// asciidoctorj.bat -r asciidoctor-diagram -b html ArchitectureTools.asciidoc
	process.StartInfo.Arguments = "/c asciidoctorj.bat -r asciidoctor-diagram -b " + type + " " + Path.GetFileName(filePath);
	process.StartInfo.WorkingDirectory = Path.GetDirectoryName(filePath);
	process.StartInfo.RedirectStandardOutput = true;
	process.StartInfo.UseShellExecute = false;
	process.StartInfo.CreateNoWindow = true;
	result = process.StartInfo.Arguments + '\n';
	process.Start();
	string output = process.StandardOutput.ReadToEnd();
	process.WaitForExit();

	result += output;
	return result;

}

// You can define other methods, fields, classes and namespaces here
