using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Threading.Channels;
namespace weightGraph_dsa
{
	 public class Path
 {
     private List<string> node=new List<string>();
     public void addnode(string node)
     {
         this.node.Add(node);
     }
     public List<string> getpath()
     {
         return this.node;
     }
     public override string ToString()
     {
         return "node "+node.ToString()!; 
     }
 }
    public class Weight_Graph
    {
        private class Node
        {
           public string lable;
            public List<Edges> edges=new List<Edges>();
            public Node(string lable)
            {
                this.lable = lable;
            }
            public void addedge(Node to,int wight)
            {
                edges.Add(new Edges(this,to,wight)); 
            }
            public List<Edges> getedges()
            {
                return edges;
            }
            public override string ToString()
            {
                return "["+lable+"]";
            }
        }
        private class Edges
        {
           public Node from,to;
           public int wight;
            public Edges(Node from,Node to,int wight)
            {
                this.from = from;
                this.to = to;
                this.wight = wight;
            }
            public override string ToString()
            {
                return from + "->" + to;
            }
        }
        Dictionary<string,Node> _nodes = new Dictionary<string,Node>();
        public void addnode(string data)
        {
            _nodes.TryAdd(data, new Node(data));
        }
        public void addedge(string from,string to,int wight)
        {
            var from1 = _nodes[from]; 
            var to1 = _nodes[to];
            if (from1 == null || to1 == null) return;
            from1.addedge(to1, wight);
            to1.addedge(from1, wight);
        }
        public void print()
        {
            foreach (var node in _nodes.Values)
            {
                var target = node.getedges();
                if(target == null) continue;
				Console.Write(node + "connected to ");
				foreach (var nigbous in target)
                {
                    Console.Write(nigbous);
                }
                Console.WriteLine();
            }
        }
	    
  public Path shrotPath(String from, String to)
     {
        Dictionary<Node, int> distance = new Dictionary<Node, int>();
        Dictionary<Node, Node> presiosnode = new Dictionary<Node, Node>();
        foreach (var node in _nodes.Values)
        {
            distance.Add(node, int.MaxValue);
        }
        var tonode = _nodes[to];
        var tofrom = _nodes[from];
        distance[_nodes[from]] = 0;
        HashSet<Node> visited = new HashSet<Node>();
        PriorityQueue<Node, int> quee = new PriorityQueue<Node, int>();
        quee.Enqueue(_nodes[from], 0);
        while (quee.Count > 0)
        {
            var current = quee.Dequeue();
            visited.Add(current);
            foreach (var edge in current.getedges())
            {
                if (visited.Contains(edge.to))
                { continue; }
                int newdis = distance[current] + edge.wight;
                if (newdis < distance[edge.to])
                {
                    distance[edge.to] = newdis;
                    quee.Enqueue(edge.to, newdis);
                    presiosnode[edge.to] = current;
                }
            }
        }
        return buildPath(presiosnode, tonode);
    }
    private Path buildPath(Dictionary<Node, Node> presiosnode, Node tonode)
    {
        Stack<Node> stack = new Stack<Node>();
        stack.Push(tonode);
        var previos = presiosnode[tonode];
        while (previos != null)
        {
            stack.Push(previos);
            previos = presiosnode.GetValueOrDefault(previos);
        }
        Path path = new Path();
        while (stack.Count > 0)
        {
            path.addnode(stack.Pop().lable);
        }
        return path;
    }
}
}
        public class Progarm
        {
            static void Main()
            {
              Weight_Graph weight_Graph = new Weight_Graph();
              weight_Graph.addnode("A");
              weight_Graph.addnode("B");
              weight_Graph.addnode("C");
              weight_Graph.addnode("D");
              weight_Graph.addnode("E");
              weight_Graph.addnode("L");
              weight_Graph.addedge("A", "B", 3);
              weight_Graph.addedge("A", "C", 4);
              weight_Graph.addedge("A", "D", 2);
              weight_Graph.addedge("B", "D", 6);
              weight_Graph.addedge("B", "E", 1);
              weight_Graph.addedge("D", "E", 5);
              weight_Graph.addedge("D", "C", 1);
              weight_Graph.addedge("E", "L", 4);
              weight_Graph.shrotPath("A", "E");
            }
        }
}
  
