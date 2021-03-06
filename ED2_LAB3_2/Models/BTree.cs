﻿using System;
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
        public static int grade = 5;
        public Node root = null;
        public int number = 0;

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
        public void Disc()
        {
            StreamWriter TreeText = new StreamWriter(@"c:\Users\Gerardo\Desktop\Gerardo\URL\5to Ciclo\Estructura de Datos II\ED2_LAB3_2\Arbol.txt");
            TreeText.WriteLine("Grado " + grade);
            TreeText.WriteLine("Raiz " + root);
            TreeText.WriteLine("Proxima posicion " + number);

            foreach (var NodeList in soda)
            {
                if (NodeList.Name == null)
                {
                    TreeText.Write(NodeList.Name + "|0|");
                }
                else
                {
                    TreeText.Write(NodeList.Name + "|" + NodeList.Name + "|");
                }
                if (NodeList.Flavor == null)
                {
                    string son = string.Empty;
                    for(int i = 0; i <grade; i++)
                    {
                        son = son + "0|";
                    }
                    TreeText.Write(son);
                }
                else
                {
                    TreeText.Write("|0");
                }

                foreach (var values in soda)
                {
                    TreeText.Write(values.Name + "|");
                    TreeText.Write(values.Flavor + "|");
                    TreeText.Write(values.Price + "|");
                    TreeText.Write(values.Volume + "|");
                    TreeText.Write(values.Producer_House + "|");
                }
                TreeText.Write("\n");
            }
            TreeText.Close();

        }
    }
}
