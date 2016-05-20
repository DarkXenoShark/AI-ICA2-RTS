using System.Collections.Generic;
using System.Linq;

namespace SandTiger
{
	public interface IAStar<TNode>
	{
		int HeuristicCostEstimate(TNode a, TNode b);

		IEnumerable<TNode> GetNeighbourNodes(TNode node);
	}

	/// <summary> http://en.wikipedia.org/wiki/A*_search_algorithm#Pseudocode </summary>
	public static class AStar
	{
		public static IEnumerable<TNode> Search<TNode>(this IAStar<TNode> astar, TNode start, TNode goal)
		{
			HashSet <TNode> closedSet			= new HashSet<TNode>(); // nodes already evaluated
			HashSet <TNode> openSet				= new HashSet<TNode> {start}; // nodes to be evaluated
			Dictionary <TNode, TNode> cameFrom	= new Dictionary<TNode, TNode>(); // the map of navigated nodes
			Dictionary <TNode, int> g			= new Dictionary<TNode, int>(); // g score for each node, cost from start along best path
			Dictionary <TNode, int> f			= new Dictionary<TNode, int>(); // f score for each node, estimated total cost from start to goal

			g[start] = 0;
			f[start] = g[start] + astar.HeuristicCostEstimate (start, goal);

			while (openSet.Count > 0)
			{
				// current is the node in openSet with lowest f score
				TNode[] current = { openSet.First() };
				foreach (TNode node in openSet.Where (node => f[node] < f[current[0]]))
				{
					current[0] = node;
				}

				// back track and yield path if we have reached the destination);
				if (current[0].Equals (goal))
				{
					IList<TNode> path;
					ReconstructPath (cameFrom, goal, out path);
					return path;
				}

				openSet.Remove (current[0]);
				closedSet.Add (current[0]);

				foreach (TNode neighbour in astar.GetNeighbourNodes (current[0]))
				{
					if (closedSet.Contains (neighbour)) continue;
					int tentativeG = g[current[0]] + astar.HeuristicCostEstimate (current[0], neighbour); // TODO distance?

					if (openSet.Contains (neighbour) && tentativeG >= g[neighbour]) continue;
					cameFrom[neighbour]	= current[0];
					g[neighbour]		= tentativeG;
					f[neighbour]		= g[neighbour] + astar.HeuristicCostEstimate(neighbour, goal);

					if (!openSet.Contains (neighbour)) openSet.Add (neighbour);
				}
			}

			return new TNode[] {};
		}

		// TODO convert this method to an iterative solution
		private static void ReconstructPath<TNode>(IDictionary<TNode, TNode> cameFrom, TNode current, out IList<TNode> path)
		{
			if (cameFrom.ContainsKey (current))
			{
				ReconstructPath (cameFrom, cameFrom[current], out path);
				path.Insert (path.Count, current);
			}
			else
			{
				path = new List<TNode> { current };
			}
		}
	}
}