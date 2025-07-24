using System;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : Singleton<GridManager>
{
    public GameObject[] obstacles;
    public Node[,] nodes { get; set; }

    public int numOfRows;
    public int numOfCols;
    public float gridCellSize;

    private Vector3 origin = new Vector3();
    public Vector3 Origin
    {
        get { return origin; }
    }

    protected override void Awake()
    {
        base.Awake();

        obstacles = GameObject.FindGameObjectsWithTag("Obstacles");
        CalculateObstacles();
    }

    private void CalculateObstacles()
    {
        nodes = new Node[numOfRows, numOfCols];

        int index = 0;
        for (int i = 0; i < numOfCols; i++)
        {
            for (int j = 0; j < numOfRows; j++)
            {
                Vector3 cellPos = GetGridCellCenter(index);
                Node node = new Node(cellPos);
                nodes[i, j] = node;
                index++;
            }
        }

        if (obstacles != null && obstacles.Length > 0)
        {
            foreach (GameObject obstacle in obstacles)
            {
                int indexCell = GetGridIndex(obstacle.transform.position);
                int row = GetRow(indexCell);
                int col = GetCol(indexCell);
                nodes[row, col].MarkAsObstacle();
            }
        }
    }

    public Vector3 GetGridCellCenter(int index)
    {
        Vector3 cellPosition = GetGridCellPosition(index);
        cellPosition.x += gridCellSize / 2f;
        cellPosition.z += gridCellSize / 2f;

        return cellPosition;
    }

    public Vector3 GetGridCellPosition(int index)
    {
        int row = GetRow(index);
        int col = GetCol(index);
        float xPosInGrid = col * gridCellSize;
        float zPosInGrid = row * gridCellSize;

        return Origin + new Vector3(xPosInGrid, 0, zPosInGrid);
    }

    public int GetGridIndex(Vector3 pos)
    {
        if (!IsInBounds(pos))
        {
            return -1;
        }

        pos += Origin;
        int col = (int)(pos.x / gridCellSize);
        int row = (int)(pos.z / gridCellSize);

        return row * numOfCols + col;
    }

    public bool IsInBounds(Vector3 pos)
    {
        float width = numOfCols * gridCellSize;
        float height = numOfRows * gridCellSize;

        bool isInBounds = (pos.x >= Origin.x && pos.x <= Origin.x + width && pos.z >= Origin.z && pos.z <= Origin.z + height);

        return isInBounds; 
    }

    public void GetNeighbors(Node node, List<Node> neighbors)
    {
        int nodeIndex = GetGridIndex(node.pos);
        int row = GetRow(nodeIndex);
        int col = GetCol(nodeIndex);

        //¾Æ·¡
        int leftNodeRow = row - 1;
        int leftNodeCol = col;
        AssignNeighbor(leftNodeRow, leftNodeCol, neighbors);

        //À§
        leftNodeRow = row + 1;
        leftNodeCol = col;
        AssignNeighbor(leftNodeRow, leftNodeCol, neighbors);

        //¿À
        leftNodeRow = row;
        leftNodeCol = col + 1;
        AssignNeighbor(leftNodeRow, leftNodeCol, neighbors);

        //¿Þ
        leftNodeRow = row;
        leftNodeCol = col - 1;
        AssignNeighbor(leftNodeRow, leftNodeCol, neighbors);
    }

    private void AssignNeighbor(int row, int col, List<Node> neighbors)
    {
        if (row != -1 &&  col != -1 && row < numOfRows && col < numOfCols)
        {
            Node nodeToAdd = nodes[row, col];
            if (!nodeToAdd.isObstacle)
            {
                neighbors.Add(nodeToAdd);
            }
        }
    }

    public int GetRow(int index)
    {
        int row = index / numOfCols;

        return row;
    }

    public int GetCol(int index)
    {
        int col = index % numOfCols;

        return col;
    }

    void OnDrawGizmos()
    {
        DebugDrawGrid(transform.position, numOfRows, numOfCols, gridCellSize, Color.blue);
    }

    public void DebugDrawGrid(Vector3 origin, int numRows, int numCols, float cellSize, Color color)
    {
        float width = numCols * cellSize;
        float height = numRows * cellSize;

        for (int i = 0; i < numRows; i++)
        {
            Vector3 startPos = origin + i * cellSize * new Vector3(0, 0, 1);
            Vector3 endPos = startPos + width * new Vector3(1, 0, 0);
            Debug.DrawLine(startPos, endPos, color);
        }

        for (int i = 0; i < numCols; i++)
        {
            Vector3 startPos = origin + i * cellSize * new Vector3(1, 0, 0);
            Vector3 endPos = startPos + height * new Vector3(0, 0, 1);
            Debug.DrawLine(startPos, endPos, color);
        }
    }
}
