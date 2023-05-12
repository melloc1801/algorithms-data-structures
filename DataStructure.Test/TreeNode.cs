namespace DataStructure.Test;

class TreeNode
{
    public readonly Dictionary<int, TreeNode> _children = new ();

    public readonly int Id;
    
    public TreeNode(int id)
    {
        Id = id;
    }

    public void Add(int id)
    {
        _children[id] = new TreeNode(id);
    }

    public void BreadthFirstSearchLog()
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            // Gets and removes all nodes from queue (Current Level)
            var currentLevelNodes = new List<TreeNode>();
            while (queue.Count > 0)
            {
                currentLevelNodes.Add(queue.Dequeue());
            }
            
            // Log all nodes from current level
            foreach (var node in currentLevelNodes)
            {
                Console.Write($"_{node.Id}_");
            }
            Console.WriteLine();
            
            // Add to queue current level children nodes
            foreach (var currentNode in currentLevelNodes)
            {
                foreach (var node in currentNode._children.Values)
                {
                    queue.Enqueue(node);
                }
            }
        }
    }

    public void DepthFirstSearchLog()
    {
        
    }
}