using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ED2_LAB3_2.Models
{
    public class BTree
    {
        //Arbol B* en disco
        public List<Soda> soda = new List<Soda>();
        public Node node;

        public void insert(Soda info)
        {
            if (node == null)
            {
                var newNode = new Node();
                newNode.rightVal = info;
                node = newNode;
            }
            else
            {
                var x = ins(info, node);
                if (x != null)
                {
                    node = x;
                }
            }
        }
        public Node ins(Soda info, Node node)
        {
            if (node.leftChild == null)
            {
                if (node.intermideateChild == null)
                {
                    if (node.rightChild == null)
                    {
                        if (node.rightVal == null)
                        {
                            if (node.leftVal.Name.CompareTo(info.Name) == 1)
                            {
                                node.rightVal = node.leftVal;
                                node.leftVal = info;
                            }
                            else
                            {
                                node.rightVal = info;
                            }

                        }
                    }
                    return null;
                }
                else
                {
                    if (node.rightVal.Name.CompareTo(info.Name) == -1)
                    {
                        var Up = new Node();
                        var newVal = new Node();
                        Up.leftVal = node.rightVal;
                        newVal.leftVal = info;
                        node.rightVal = null;
                        Up.leftChild = node;
                        Up.intermideateChild = newVal;


                        return Up;
                    }

                    if (node.leftVal.Name.CompareTo(info.Name) == 1)
                    {
                        var Up = new Node();
                        var newVal = new Node
                        {
                            leftVal = node.rightVal
                        };
                        node.rightVal = null;
                        Up.leftVal = node.leftVal;
                        node.leftVal = info;
                        Up.leftChild = node;
                        Up.intermideateChild = newVal;


                        return Up;
                    }
                    else
                    {
                        var Up = new Node
                        {
                            leftVal = info
                        };
                        var newVal = new Node
                        {
                            leftVal = node.rightVal
                        };
                        node.rightVal = null;
                        Up.leftChild = node;
                        Up.intermideateChild = newVal;
                        return Up;
                    }
                }
            }
            else
            {
                if (node.rightVal == null)
                {
                    if (node.leftVal.Name.CompareTo(info.Name) == -1)
                    {
                        var x = ins(info, node.intermideateChild);
                        if (x != null)
                        {
                            node.rightVal = x.leftVal;
                            node.intermideateChild = x.leftChild;
                            node.rightChild = x.intermideateChild;
                        }
                        return null;
                    }
                    else
                    {
                        var x = ins(info, node.leftChild);
                        if (x != null)
                        {
                            node.rightVal = node.leftVal;
                            node.leftVal = x.leftVal;
                            node.leftChild = x.leftChild;
                            node.rightChild = node.intermideateChild;
                            node.intermideateChild = x.intermideateChild;
                        }
                        return null;
                    }
                }
                else
                {

                    if (info.Name.CompareTo(node.leftVal.Name) == -1)
                    {
                        var x = ins(info, node.leftChild);
                        if (x != null)
                        {
                            var Up = new Node
                            {
                                leftVal = node.leftVal,
                                leftChild = x
                            };
                            node.leftVal = node.rightVal;
                            node.rightVal = null;
                            node.leftChild = node.intermideateChild;
                            node.intermideateChild = node.rightChild;
                            node.rightChild = null;
                            Up.intermideateChild = node;
                            return Up;
                        }
                        else
                        {
                            return null;
                        }

                    }
                    if ((info.Name.CompareTo(node.rightVal.Name) == -1))
                    {
                        var x = ins(info, node.intermideateChild);
                        if (x != null)
                        {
                            var Up = new Node
                            {
                                leftVal = x.leftVal
                            };
                            var newVal = new Node
                            {
                                leftVal = node.rightVal,
                                intermideateChild = node.rightChild,
                                leftChild = x.intermideateChild
                            };
                            node.rightVal = null;
                            node.rightChild = null;
                            Up.leftChild = node;
                            node.intermideateChild = x.leftChild;
                            Up.intermideateChild = newVal;
                            newVal.leftChild = x.intermideateChild;
                            return Up;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        var x = ins(info, node.rightChild);
                        if (x != null)
                        {
                            var Up = new Node
                            {
                                leftVal = node.rightVal
                            };
                            node.rightChild = null;
                            node.rightVal = null;
                            Up.leftChild = node;
                            Up.intermideateChild = x;
                            return Up;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
    }
}
