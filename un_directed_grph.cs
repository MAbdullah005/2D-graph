using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Threading.Channels;
namespace weightGraph_dsa
{
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
	        {
       Dictionary<Node,Node> previos = new Dictionary<Node,Node>();
       Dictionary<Node,int> distance= new Dictionary<Node,int>();
        HashSet<Node> set = new HashSet<Node>();
       PriorityQueue<Node,int> quee=new PriorityQueue<Node,int>();
        quee.Enqueue(_nodes[data],0);
        while(quee.Count > 0)
        {
            Node node = quee.Dequeue();
            foreach(var item in  node.getedges())
            {
               if(quee.UnorderedItems.Any(i=>i.Element==node))
                {

                    
            }
        }
    }
   private bool balance(Dictionary<Node, Node> previos,Dictionary<Node, int> distance,Node from,Node to,int wight)
    {
         if(!distance.ContainsKey(from))
        {
            distance.Add(from,wight);
            previos.Add(to,from);
        }   
         else if (distance[from]>wight)
        {
            distance[from] = wight;
        }
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
            weight_Graph.addedge("A","B",3);
            weight_Graph.addedge("A","C",2);
            weight_Graph.print();
            }
        }
}
  
