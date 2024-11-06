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
            private List<Edges> edges=new List<Edges>();
            public Node(string lable)
            {
                this.lable = lable;
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
        Dictionary<Node,List<Edges>> adjenceylsit= new Dictionary<Node,List<Edges>>();
        public void addnode(string data)
        {
            Node node = new Node(data);
            _nodes.TryAdd(data, node);
            adjenceylsit.TryAdd(node, new List<Edges>());
        }
        public void addedge(string from,string to,int wight)
        {
            var from1 = _nodes[from]; 
            var to1 = _nodes[to];
            if (from1 == null || to1 == null) return;
            adjenceylsit[from1].Add(new Edges(from1, to1, wight));
            adjenceylsit[to1].Add(new Edges(to1, from1, wight));
        }
        public void print()
        {
            foreach (var source in adjenceylsit.Keys)
            {
                var target = adjenceylsit[source];
                if(target == null) continue;
				Console.Write(source + "connected to ");
				foreach (var node in target)
                {
                    Console.Write(node);
                }
                Console.WriteLine();
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
  
