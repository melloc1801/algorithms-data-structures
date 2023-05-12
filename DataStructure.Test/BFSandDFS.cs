using NUnit.Framework;

namespace DataStructure.Test;

[TestFixture]
public class BFSandDFS
{
    [Test]
    public void Tmp()
    {
        var tree = new TreeNode(2);
        
        tree.Add(4);
        tree.Add(3);
        
            tree._children[4].Add(10);
            tree._children[4].Add(15);
        
                tree._children[4]._children[15].Add(11);
                tree._children[4]._children[15].Add(9);
                
                    tree._children[4]._children[15]._children[11].Add(2);
                    tree._children[4]._children[15]._children[11].Add(3);
                
            tree._children[3].Add(2);
            tree._children[3].Add(6);
                tree._children[3]._children[6].Add(4);
                tree._children[3]._children[6].Add(6);
                    
                    tree._children[3]._children[6]._children[4].Add(1);
                    tree._children[3]._children[6]._children[4].Add(2);
                    tree._children[3]._children[6]._children[4].Add(3);
                    tree._children[3]._children[6]._children[6].Add(1);
        
        

        tree.BreadthFirstSearchLog();
    }
}