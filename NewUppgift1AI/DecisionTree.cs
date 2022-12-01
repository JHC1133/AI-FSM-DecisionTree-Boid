using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI
{
    internal class DecisionTree
    {
        internal class BinaryTree
        {
            public int ID;
            bool EvalMethod;
            public BinaryTree trueBranch;
            public BinaryTree falseBranch;
            bool activateMode;
            bool drinkMode, rageMode, moveMode, peeMode;

            public Dog dog;

            public BinaryTree()
            {

            }

            public BinaryTree(int newID, bool newEval)
            {
                ID = newID;
                EvalMethod = newEval;
            }

            BinaryTree root;

            public void SetRoot(int newID, bool newEval)
            {
                root = new BinaryTree(newID, newEval);
            }

            public void AddTrueNode(int existingNodeID, int newNodeID, bool newQuestAns, bool activateMode)
            {
                if (root == null)
                {
                    return;
                }

                if (ParseTreeAndAddTrueNode(root, existingNodeID, newNodeID, newQuestAns, activateMode))
                {
                    //Added
                }
                else
                {
                    //Not added
                }
            }

            bool ParseTreeAndAddTrueNode(BinaryTree currentNode, int existingNodeID, int newNodeID, bool newQuestAns, bool activateMode)
            {
                if (currentNode.ID == existingNodeID)
                {
                    if (currentNode.trueBranch == null)
                    {
                        currentNode.trueBranch = new BinaryTree(newNodeID, newQuestAns);
                    }
                    else
                    {
                        //Replacing node
                        currentNode.trueBranch = new BinaryTree(newNodeID, newQuestAns);
                    }
                    return true;
                }
                else
                {
                    if (currentNode.trueBranch != null)
                    {
                        if (ParseTreeAndAddTrueNode(currentNode.trueBranch, existingNodeID, newNodeID, newQuestAns, activateMode))
                        {
                            return true;
                        }
                        else
                        {
                            if (currentNode.falseBranch != null)
                            {
                                return (ParseTreeAndAddTrueNode(currentNode.falseBranch, existingNodeID, newNodeID, newQuestAns, activateMode));
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    return false;
                }
            }

            public void AddFalseNode(int existingNodeID, int newNodeID, bool newQuestAns, bool activateMode)
            {
                if (root == null)
                {
                    return;
                }

                if (ParseTreeAndAddFalseNode(root, existingNodeID, newNodeID, newQuestAns, activateMode))
                {
                    //Added
                }
                else
                {
                    //Not added
                }
            }

            bool ParseTreeAndAddFalseNode(BinaryTree currentNode, int existingNodeID, int newNodeID, bool newQuestAns, bool activateMode)
            {
                if (currentNode.ID == existingNodeID)
                {
                    if (currentNode.falseBranch == null)
                    {
                        currentNode.falseBranch = new BinaryTree(newNodeID, newQuestAns);
                    }
                    else
                    {
                        //Replacing node
                        currentNode.falseBranch = new BinaryTree(newNodeID, newQuestAns);
                    }
                    return true;
                }
                else
                {
                    if (currentNode.trueBranch != null)
                    {
                        if (ParseTreeAndAddFalseNode(currentNode.trueBranch, existingNodeID, newNodeID, newQuestAns, activateMode))
                        {
                            return true;
                        }
                        else
                        {
                            if (currentNode.falseBranch != null)
                            {
                                return ParseTreeAndAddFalseNode(currentNode.falseBranch, existingNodeID, newNodeID, newQuestAns, activateMode);
                            }
                            else return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            private void Eval(BinaryTree currentNode)
            {
                if (currentNode.EvalMethod == true)
                {
                    ParseTree(currentNode.trueBranch);
                }
                else
                {
                    if (currentNode.EvalMethod == false)
                    {
                        ParseTree(currentNode.falseBranch);
                    }
                }
            }

            private void ParseTree(BinaryTree currentNode)
            {
                if (currentNode.trueBranch == null)
                {
                    if (currentNode.falseBranch == null)
                    {
                        Debug.WriteLine("true and false branch was null");
                        currentNode.activateMode = true;
                        Debug.WriteLine(currentNode.activateMode.ToString() + " " + currentNode.activateMode);
                    }
                    return;
                }
                if (currentNode.falseBranch == null)
                {
                    Debug.WriteLine("true and false branch was null");
                    currentNode.activateMode = true;
                    Debug.WriteLine(currentNode.activateMode.ToString() + " " + currentNode.activateMode);
                    return;
                }
                Eval(currentNode);
            }

            public void ParseTree()
            {
                ParseTree(root);
            }
        }

    }
}
