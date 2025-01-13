using System.Collections;
using Godot;
namespace Graph;


class UndirectedGraph
{
    public int _v { get; private set; }
    public int _e { get; private set; } = 0;
    private Bag<int>[] adj;

    public UndirectedGraph(int v)
    {
        _v = v;
        adj = new Bag<int>[v];
        GD.Print(adj.Length);
        for (int i = 0; i < v; i++)
        {
            adj[i] = new Bag<int>();
        }
    }

    public void AddEdge(int v, int w)
    {
        adj[v].Add(w);
        adj[w].Add(v);
        _e++;
    }

    public IEnumerator GetEnumerator(int v)
    {
        return adj[v].GetEnumerator();
    }

    public override string ToString()
    {
        string s = _v + " verticies, " + _e + " edge(s)\n";
        for (int i = 0; i < _v; i++)
        {
            s += i + ": ";
            foreach (int w in adj[i])
            {
                s += w + " ";
            }
            s += "\n";
        }
        return s;
    }
}
