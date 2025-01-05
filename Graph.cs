using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace trps_app1
{
    internal class Graph
    {
        private Random rnd = new Random();
        private int maxVertex;
        private int nChanges;
        private int maxPath;
        private List<int> usingVertexes;
        private List<int> shortestPathTemp;
        private int[] pathsToVertexes;

        public int[,] weightsMatrix;
        private int sourceVertex;
        private int lastVertex;
        private int targetVertex;
        public int shortestPathLength;
        public List<int> shortestPath;

        public Graph(int nVertexes, int nChanges, int maxPath)
        {
            this.maxVertex = nVertexes - 1;
            this.nChanges = nChanges;
            this.maxPath = maxPath;
            this.shortestPathLength = 0;
            this.sourceVertex = rnd.Next(0, maxVertex - (nChanges + 3));
            this.lastVertex = rnd.Next(sourceVertex + nChanges + 3, maxVertex);
            this.targetVertex = rnd.Next(sourceVertex + 2, lastVertex - nChanges);
            this.weightsMatrix = new int[nVertexes, nVertexes];
            this.shortestPath = new List<int>();
            this.shortestPathTemp = new List<int>();
            this.usingVertexes = new List<int>();
            this.pathsToVertexes = new int[nVertexes];
            for (int i = 1; i < pathsToVertexes.Length; i++)
            {
                pathsToVertexes[i] = maxPath*3;
            }

            generate();
        }
        private void generate()
        {

            int[] paths = new int[nChanges + 1];
            int[] pathsWithoutLast = new int[nChanges + 1];
            int minPath;

            // Построение графа до части с алгоритмом
            if (!(sourceVertex == 0))
            {
                int nPathsBefore = rnd.Next(sourceVertex/2+1, sourceVertex+1);
                buildEdgesBeforeAfter(nPathsBefore, 1, sourceVertex, 0, sourceVertex);
            }

            // Построение части графа с алгоритмом
            minPath = 0;
            Array.Clear(paths);
            Array.Clear(pathsWithoutLast);
            generatePaths(ref paths, nChanges + 1, nChanges * 2 + 2, maxPath, true);
            for (int i = 0; i < nChanges + 1; i++)
            {
                pathsWithoutLast[i] = i * 2 + 1;
            }
            Array.Sort(paths);
            Array.Reverse(paths);

            fillVertexes(sourceVertex + 1, targetVertex);
            buildPath(paths[0], pathsWithoutLast[0], 0, sourceVertex, targetVertex);

            fillVertexes(targetVertex + 1, lastVertex + 1);
            for (int i = 1; i <= nChanges; i++)
            {
                shortestPathTemp.Clear();
                buildPath(paths[i], pathsWithoutLast[i], i, sourceVertex, targetVertex);
                minPath = paths[i];
            }
            shortestPath.AddRange(shortestPathTemp);
            shortestPathLength += minPath;

            pathsToVertexes[targetVertex] = pathsToVertexes[sourceVertex] + minPath;

            // Построение графа после части с алгоритмом
            if (!(lastVertex == maxVertex))
            {
                int nPathsAfter = rnd.Next((maxVertex - lastVertex)/2+1, maxVertex - lastVertex+1);
                buildEdgesBeforeAfter(nPathsAfter, lastVertex + 1, maxVertex, targetVertex, maxVertex);
            }

            // Добавление дополнительных ребер с большим весом
            int nBigEdges = rnd.Next(maxVertex-3, maxVertex);
            int v1, v2,k;
            int j = 0;
            while (j<= nBigEdges)
            {
                v1 = rnd.Next(0, maxVertex);
                v2 = rnd.Next(0, maxVertex);
                if (buildExtraEdge(v1, v2))
                     j++;
            }


            checkIsolated();

            shortestPath.Add(maxVertex);
        }

        private bool buildExtraEdge(int v1, int v2)
        {
            if (weightsMatrix[v1, v2] == 0 && v1!=v2 && v2!=targetVertex)
            {
                if ((pathsToVertexes[v1] == maxPath * 3) && (pathsToVertexes[v2] == maxPath * 3))
                {
                    return false;
                }
                else if ((pathsToVertexes[v1]== maxPath * 3)|| (pathsToVertexes[v2] == maxPath * 3))
                {
                    int w = rnd.Next(1, 10);
                    weightsMatrix[v1, v2] = w;
                    pathsToVertexes[v2] = Math.Min(pathsToVertexes[v2], pathsToVertexes[v1] + w);
                    return true;
                }
                else
                {
                    int k = pathsToVertexes[v2] - pathsToVertexes[v1] + 1;
                    if ((k > 0) && (k <= 10))
                    {
                        weightsMatrix[v1, v2] = rnd.Next(k, k + 5);
                        return true;
                    }
                    else if ((k <= 0))
                    {
                        weightsMatrix[v1, v2] = rnd.Next(1, 10);
                        return true;
                    }
                }            
            }
            return false;
        }

        private void checkIsolated()
        {
            for (int i = 0; i <= maxVertex; i++)
            {
                int s_to = 0;
                int s_from = 0;
                for (int j = 0; j <= maxVertex; j++)
                {
                    s_to += weightsMatrix[j, i];
                    s_from += weightsMatrix[i, j];
                }
                if (s_to == 0)
                {
                    int v1 = rnd.Next(0, maxVertex);
                    int v2 = i;
                    while (!(buildExtraEdge(v1, v2)))
                    {
                        v1 = rnd.Next(0, maxVertex);
                    }
                }
                if (s_from == 0)
                {
                    int v2 = rnd.Next(0, maxVertex);
                    int v1 = i;
                    while (!(buildExtraEdge(v1, v2)))
                    {
                        v2 = rnd.Next(0, maxVertex); 
                    }
                }
            }
        }
        private void buildPath(int path, int pathWithoutLast, int pathNumber, int source, int target)
        {
            int vertex = target;
            int lastWeight = path - pathWithoutLast;
            vertex = buildEdge(ref path, lastWeight, vertex, source, target, pathNumber);

            while (vertex != source)
            {
                int weight = rnd.Next(1, path);
                vertex = buildEdge(ref path, weight, vertex, source, target, pathNumber);
            }

            shortestPathTemp.Reverse();
        }

        private int buildEdge(ref int path, int weight, int vertex, int source, int target, int pathNumber)
        {
            int previousVertex;
            pathsToVertexes[vertex] = Math.Min(pathsToVertexes[vertex], pathsToVertexes[source] + path);
            if ((path == weight) | (usingVertexes.Count == 0) | ((pathNumber != 0) & (usingVertexes.Count == nChanges - pathNumber)))
            {
                previousVertex = source;
                weight = path;
            }
            else
            {
                int v = rnd.Next(usingVertexes.Count);
                previousVertex = usingVertexes[v];
                usingVertexes.RemoveAt(v);
                path -= weight;
            }
            weightsMatrix[previousVertex, vertex] = weight;          

            shortestPathTemp.Add(previousVertex);

            return previousVertex;
        }

        private void fillVertexes(int begin, int end)
        {
            usingVertexes.Clear();
            for (int i = begin; i < end; i++)
            {
                usingVertexes.Add(i);
            }
        }

        private void generatePaths(ref int[] paths, int n, int begin, int end, bool unique)
        {
            int element;
            int i = 0;
            while (i < n)
            {
                element = rnd.Next(begin, end);
                if (!(paths.Contains(element)) || !unique)
                {
                    paths[i] = element;
                    i++;
                }
            }
        }

        private void buildEdgesBeforeAfter(int n, int begin, int end, int source, int target)
        {
            int path;
            int pathWithoutLast;
            int minPath;
            int[] paths = new int[n];
            int[] pathsWithoutLast = new int[n];
            List<int> shortestPathSave = new List<int>();

            minPath = maxPath;
            generatePaths(ref paths, n, maxPath / 4, maxPath / 2, false);
            generatePaths(ref pathsWithoutLast, n, 1, maxPath / 4, false);
            fillVertexes(begin, end);
            for (int i = 0; i < n; i++)
            {
                shortestPathTemp.Clear();
                path = paths[i];
                pathWithoutLast = pathsWithoutLast[i];
                buildPath(path, pathWithoutLast, 0, source, target);
                if (path < minPath)
                {
                    minPath = path;
                    shortestPathSave.Clear();
                    shortestPathSave.AddRange(shortestPathTemp);
                }
            }
            shortestPath.AddRange(shortestPathSave);
            shortestPathSave.Clear();
            shortestPathLength += minPath;
        }

    }
}

