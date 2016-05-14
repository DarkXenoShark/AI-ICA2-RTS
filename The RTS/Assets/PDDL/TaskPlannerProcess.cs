using UnityEngine;
using System.Collections;

// required
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Linq;

public class TaskPlannerProcess : MonoBehaviour {

	private Process PProcessPlanner;
	public string workingDirectory = "";
	private string plannerFilename = "";
	private string PDDLdomFileName = ""; // name without .pddl extension
	private string PDDLprbFileName = ""; // name without .pddl extension
	private string solutionFilename = "";
	public string parsedSolution = "";
	public int actionsFound = 0;

	// generic instantiation and initialisation
	public void InstantiatePlanner()
	{
		PProcessPlanner = new Process();

		workingDirectory = Application.dataPath + @"/Planner";
		plannerFilename = workingDirectory + @"/metric-ff.exe";
		PDDLdomFileName = @"coconut-domain"; // name without .pddl extension
		PDDLprbFileName = @"coconut-problem"; // name without .pddl extension
		solutionFilename = workingDirectory + @"/ffSolution.soln";
	}

	public void ProcessStart()
	{
		// set the information for the Process and get it to run
		// make sure it runs from the Planner's folder
		PProcessPlanner.StartInfo.WorkingDirectory = workingDirectory;
		// metric-ff needs to run using the full explicit path ...
		PProcessPlanner.StartInfo.FileName = plannerFilename;
		PProcessPlanner.StartInfo.Arguments = string.Format("-o {0}.pddl -f {1}.pddl", PDDLdomFileName, PDDLprbFileName);
		PProcessPlanner.StartInfo.CreateNoWindow = true;
		PProcessPlanner.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
		// run the process, and wait until it has closed
		PProcessPlanner.Start();
		PProcessPlanner.WaitForExit();
	}

	// Use this for initialization
	void Start () {

		InstantiatePlanner();
		ProcessStart();
		UnityEngine.Debug.Log ("SOLUTION FOUND");

		// (sorry I couldn't resist to add this):
		// using Linq, extract all the lines containing ':', 
		// ie all the lines specifying the actions in the solution generated
		var result = File.ReadAllLines (solutionFilename).Where(s => s.Contains(":"));

		// just to show how many actions have been found (*debug*)
		actionsFound = result.Count();

		// show the first action parsed in the editor window
		parsedSolution = result.ToList ()[0].ToString ();

		// delete the solution file, so you don't get to read it again next time you generate a new solution
		File.Delete (solutionFilename);
		UnityEngine.Debug.Log ("FILE DELETED");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
