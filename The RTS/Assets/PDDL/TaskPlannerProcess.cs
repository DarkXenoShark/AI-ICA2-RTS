﻿using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class TaskPlannerProcess : MonoBehaviour
{
	private Process PProcessPlanner;
	public string workingDirectory = "";
	private string plannerFilename = "";
	private string PDDLdomFileName = ""; // name without .pddl extension
	private string PDDLprbFileName = ""; // name without .pddl extension
	private string solutionFilename = "";
	public string parsedSolution = "";
	public string[] todoList;
	public int actionsFound = 0;

	// generic instantiation and initialisation
	public void InstantiatePlanner()
	{
		PProcessPlanner = new Process();

		//workingDirectory = Application.dataPath + @"/Planner";
		workingDirectory = Application.dataPath + @"/PDDL/Metric-FF";
		plannerFilename = workingDirectory + @"/metric-ff.exe";
		PDDLdomFileName = @"rts-domain"; // name without .pddl extension
		PDDLprbFileName = @"rts-problem"; // name without .pddl extension
		solutionFilename = workingDirectory + @"/ffSolution.soln";
	}

	public void ProcessStart()
	{
		// set the information for the Process and get it to run
		// make sure it runs from the Planner's folder
		PProcessPlanner.StartInfo.WorkingDirectory = workingDirectory;
		// metric-ff needs to run using the full explicit path ...
		PProcessPlanner.StartInfo.FileName = plannerFilename;
		Debug.Log (plannerFilename);
		PProcessPlanner.StartInfo.Arguments = string.Format("-o {0}.pddl -f {1}.pddl", PDDLdomFileName, PDDLprbFileName);
		PProcessPlanner.StartInfo.CreateNoWindow = true;
		PProcessPlanner.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
		// run the process, and wait until it has closed
		PProcessPlanner.Start();
		PProcessPlanner.WaitForExit();
	}

	public void CallStart()
	{
		InstantiatePlanner();
		ProcessStart();
		Debug.Log ("SOLUTION FOUND");
		
		// (sorry I couldn't resist to add this):
		// using Linq, extract all the lines containing ':', 
		// ie all the lines specifying the actions in the solution generated
		var result = File.ReadAllLines (solutionFilename).Where(s => s.Contains(":"));
		
		// just to show how many actions have been found (*debug*)
		IEnumerable<string> enumerable = result as string[] ?? result.ToArray();
		actionsFound = enumerable.Count();
		
		// show the first action parsed in the editor window
		parsedSolution = enumerable.ToList ()[0];
		todoList = enumerable.ToArray();
		
		// delete the solution file, so you don't get to read it again next time you generate a new solution
		File.Delete (solutionFilename);
		Debug.Log ("FILE DELETED");
	}
}
