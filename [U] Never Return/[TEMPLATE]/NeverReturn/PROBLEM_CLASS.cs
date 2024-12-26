using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem
{
    public static class PROBLEM_CLASS
    {
        public class Landmark
        {
            public int Id;
            public int X, Y;
            public bool IsInside;

            public Landmark(int id, int x, int y, bool isInside)
            {
                Id = id;
                X = x;
                Y = y;
                IsInside = isInside;
            }
        }


        #region YOUR CODE IS HERE
        //Your Code is Here:
        //==================
        /// <summary>
        /// Find the shortest path from "goerge" to any of the landmarks that is outside the Honor Stone 
        /// </summary>
        /// <param name="landmarks">list of Landmarks, each with Id, x, y, IsInside </param>
        /// <param name="trails">list of all trails, each consists of landmark1, landmark2, length</param>
        /// <param name="N">number of landmarks</param>
        /// <returns>value of the shortest path from goerge to outside </returns>
        /// 
        static List<List<Tuple<int, int>>> adj;
        static Stack<int> topo;
        static bool[] vis;
        static void DFS(int node)
        {
            vis[node] = true;
            foreach (var (child, _) in adj[node])
                if (!vis[child])
                    DFS(child);
            topo.Push(node);
        }
        public static int RequiredFunction(List<Landmark> landmarks, List<Tuple<int, int, int>> trails, int N)
        {
            //REMOVE THIS LINE BEFORE START CODING
            long[] ED = new long[N];
            int x0 = landmarks[0].X, y0 = landmarks[0].Y;
            foreach (Landmark i in landmarks)
                ED[i.Id] = ((i.X - x0) * (i.X - x0) + (i.Y - y0) * (i.Y - y0));

            adj = new List<List<Tuple<int, int>>>();
            for (int i = 0; i < N; i++)
                adj.Add(new List<Tuple<int, int>>());

            foreach (var (u, v, w) in trails)
                if (ED[u] > ED[v])
                    adj[v].Add(Tuple.Create(u, w));
                else if (ED[u] < ED[v])
                    adj[u].Add(Tuple.Create(v, w));

            vis = new bool[N];
            topo = new Stack<int>();
            DFS(0);

            long[] newW = new long[N];
            for (int i = 1; i < N; ++i) newW[i] = 2147483647; newW[0] = 0;

            while (topo.Count > 0)
            {
                int node = topo.Pop();
                foreach (var (child, w) in adj[node])
                    if (newW[child] > newW[node] + w)
                        newW[child] = newW[node] + w;
            }

            long mn = 2147483647;
            foreach (var i in landmarks)
                if (!i.IsInside)
                    if (mn > newW[i.Id])
                        mn = newW[i.Id];
            return (int)mn;
            // throw new NotImplementedException();
        }
        #endregion
    }
}