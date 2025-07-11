using System;
using UnityEngine;

public class BinarySearchTree : MonoBehaviour
{
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int value;

        public TreeNode(int value)
        {
            this.value = value;
        }
    }

    private TreeNode root;
    private int[] array = { 7, 10, 3, 5, 7, 2, 1, 12, 4, 9, 15, 6 };

    private string result;

    void Start()
    {
        foreach(var v in array)
        {
            root = Insert(root, v);
        }

        PreOrder(root);
        Debug.Log($"PreOrder : {result.TrimEnd(',')}");
        result = string.Empty;

        InOrder(root);
        Debug.Log($"InOrder : {result.TrimEnd(',')}");
        result = string.Empty;

        PostOrder(root);
        Debug.Log($"PostOrder : {result.TrimEnd(',')}");

    }

    private TreeNode Insert(TreeNode node, int v)
    {
        if (node == null)
        {
            return new TreeNode(v);
        }

        if (v < node.value)
        {
            node.left = Insert(node.left, v);
        }
        else
        {
            node.right = Insert(node.right, v);
        }

        return node;
    }

    private void PreOrder(TreeNode node)
    {
        if (node == null)
            return;
        result += $"{node.value}, ";
        PreOrder(node.left);
        PreOrder(node.right);
    }

    private void InOrder(TreeNode node)
    {
        if (node == null)
            return;

        InOrder(node.left);
        result += $"{node.value}, ";
        InOrder(node.right);
    }

    private void PostOrder(TreeNode node)
    {
        if (node == null)
            return;

        PostOrder(node.left);
        PostOrder(node.right);
        result += $"{node.value}, ";
    }
}
