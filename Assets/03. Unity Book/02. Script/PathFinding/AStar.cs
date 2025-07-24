using System;
using System.Collections.Generic;
using UnityEngine;

public class AStar
{
    public static PriorityQueue openList;
    public static PriorityQueue closeList;

    private static float HeuristEstimateCost(Node curNode, Node endNode)
    {
        Vector3 cost = curNode.pos - endNode.pos;

        return cost.magnitude;
    }

    public static List<Node> FindPath(Node startNode, Node endNode)
    {
        openList = new PriorityQueue();
        openList.Push(startNode);
        startNode.nodeTotalCost = 0f;
        startNode.estimateCost = HeuristEstimateCost(startNode, endNode);
        closeList = new PriorityQueue();
        Node node = null;  

        while (openList.Length != 0)
        {
            node = openList.First();

            if (node.pos == endNode.pos)
            {
                return CalculatePath(node);
            }

            List<Node> neighbors = new List<Node>();
            GridManager.Instance.GetNeighbors(node, neighbors);

            for (int i = 0; i < neighbors.Count; i++)
            {
                Node neighborNode = neighbors[i];

                if(!closeList.Contains(neighborNode))
                {
                    float cost = HeuristEstimateCost(node, neighborNode);
                    float totalCost = node.nodeTotalCost + cost;

                    float neighborNodeEstCost = HeuristEstimateCost(neighborNode, endNode);

                    neighborNode.nodeTotalCost = totalCost;
                    neighborNode.parent = node;
                    neighborNode.estimateCost = totalCost + neighborNodeEstCost;

                    if (!openList.Contains(neighborNode))
                    {
                        openList.Push(neighborNode);
                    }
                }
            }

            closeList.Push(node);
            openList.Remove(node);
        }

        if (node.pos != endNode.pos)
        {
            Debug.LogError("Destination Path Not Found");

            return null;
        }

        return CalculatePath(node);
    }

    private static List<Node> CalculatePath(Node node)
    {
        List<Node> list = new List<Node>();

        while (node != null)
        {
            list.Add(node);
            node = node.parent;
        }

        list.Reverse();

        return list;
    }
}