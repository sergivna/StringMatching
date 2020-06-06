using System;
using System.Collections.Generic;
using System.Text;

namespace Algo.Additional
{
    public static class Automata
    {
        public static Graph NewGraph(int v, int e)
        {
            Graph g = new Graph();

            g.vertexNumber = v;
            g.edgeNumber = e;
            g.initial = 0;
            g.vertexCounter = 1;
            return (g);
        }

        public static Graph NewAutomaton(int v, int e)
        {
            Graph aut;

            aut = NewGraph(v, e);
            aut.target = new int[e];
            ;
            aut.terminal = new int[v];
            return (aut);
        }


        public static Graph NewSuffixAutomaton(int v, int e)
        {
            Graph aut;

            aut = NewAutomaton(v, e);
            aut.target = new int[e];
            for (int i = 0; i < e; i++)
                aut.target[i] = -1;
            aut.suffixLink = new int[v];
            aut.length = new int[v];
            aut.position = new int[v];
            aut.shift = new int[e];
            return (aut);
        }

        public static Graph NewTrie(int v, int e)
        {
            Graph aut;

            aut = NewAutomaton(v, e);
            aut.target = new int[e];
            for (int i = 0; i < e; i++)
                aut.target[i] = -1;
            aut.suffixLink = new int[v];
            aut.length = new int[v];
            aut.position = new int[v];
            aut.shift = new int[e];
            return (aut);
        }

        public static int NewVertex(Graph g)
        {
            int res = -1;
            if (g != null && g.vertexCounter <= g.vertexNumber)
                res = (g.vertexCounter++);
            return res;
        }


        public static int GetInitial(Graph g)
        {
            return g.initial;
        }

        public static bool IsTerminal(Graph g, int v)
        {
            bool res = false;
            if (g != null && g.terminal != null && v < g.vertexNumber)
                res = (g.terminal[v] == 1 ? true : false);
            return res;
        }

        public static void SetTerminal(Graph g, int v)
        {
            if (g != null && g.terminal != null && v < g.vertexNumber)
                g.terminal[v] = 1;
        }

        public static int GetTarget(Graph g, int v, int c)
        {
            int res = -1;
            if (g != null && g.target != null && v < g.vertexNumber
                    && v * c < g.edgeNumber)
                res = (g.target[v * (g.edgeNumber / g.vertexNumber) + c]);
            return res;
        }

        public static void SetTarget(Graph g, int v, int c, int t)
        {
            if (g != null && g.target != null && v < g.vertexNumber
                    && v * c <= g.edgeNumber && t < g.vertexNumber)
                g.target[v * (g.edgeNumber / g.vertexNumber) + c] = t;
        }


        public static int GetSuffixLink(Graph g, int v)
        {
            int res = -1;
            if (g != null && g.suffixLink != null && v < g.vertexNumber)
                res = (g.suffixLink[v]);
            return res;
        }


        public static void SetSuffixLink(Graph g, int v, int s)
        {
            if (g != null && g.suffixLink != null && v < g.vertexNumber
                    && s < g.vertexNumber)
                g.suffixLink[v] = s;
        }

        public static int GetLength(Graph g, int v)
        {
            int res = -1;
            if (g != null && g.length != null && v < g.vertexNumber)
                res = (g.length[v]);
            return res;
        }

        public static void SetLength(Graph g, int v, int ell)
        {
            if (g != null && g.length != null && v < g.vertexNumber)
                g.length[v] = ell;
        }

        public static int GetPosition(Graph g, int v)
        {
            int res = -1;
            if (g != null && g.position != null && v < g.vertexNumber)
                res = (g.position[v]);
            return res;
        }

        public static void SetPosition(Graph g, int v, int p)
        {
            if (g != null && g.position != null && v < g.vertexNumber)
                g.position[v] = p;
        }

  
        public static int GetShift(Graph g, int v, int c)
        {
            int res = -1;
            if (g != null && g.shift != null && v < g.vertexNumber
                    && v * c < g.edgeNumber)
                res = (g.shift[v * (g.edgeNumber / g.vertexNumber) + c]);
            return res;
        }

        public static void SetShift(Graph g, int v, int c, int s)
        {
            if (g != null && g.shift != null && v < g.vertexNumber
                    && v * c <= g.edgeNumber)
                g.shift[v * (g.edgeNumber / g.vertexNumber) + c] = s;
        }

        public static void CopyVertex(Graph g, int target, int source)
        {
            if (g != null && target < g.vertexNumber && source < g.vertexNumber)
            {
                if (g.target != null)
                    for (int i = 0; i < (g.edgeNumber / g.vertexNumber); i++)
                        g.target[target * (g.edgeNumber / g.vertexNumber) + i] = g.target[source
                                * (g.edgeNumber / g.vertexNumber) + i];
                if (g.shift != null)
                    for (int i = 0; i < (g.edgeNumber / g.vertexNumber); i++)
                        g.shift[target * (g.edgeNumber / g.vertexNumber) + i] = g.shift[source
                                * (g.edgeNumber / g.vertexNumber) + i];
                if (g.terminal != null)
                    g.terminal[target] = g.terminal[source];
                if (g.suffixLink != null)
                    g.suffixLink[target] = g.suffixLink[source];
                if (g.length != null)
                    g.length[target] = g.length[source];
                if (g.position != null)
                    g.position[target] = g.position[source];
            }
        }
    }
}
