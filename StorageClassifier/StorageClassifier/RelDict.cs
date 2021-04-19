using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Windows;
using System.IO;

namespace StorageClassifier
{
    static class RelDict
    {
        static Dictionary<string,string> dict = new Dictionary<string,string>();
        static TreeView treeView = new TreeView();
        public static void SerializeTree(TreeView tree)
        {
            foreach (TreeViewItem e in tree.Items)
                ConstructDict(e);
            try
            {
                using (Stream stream = File.Open("storage.bin", FileMode.Create))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binaryFormatter.Serialize(stream,dict);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }

        public static TreeView DeserializeTree(string path, TreeView tree)
        {
            try
            {
                using (Stream stream = File.Open(path, FileMode.Open))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    var f = binaryFormatter.Deserialize(stream);
                    treeView = tree;
                    dict = f as Dictionary<string, string>;
                    ConstructTree("", 0);
                    tree = treeView;
                    return tree;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); return null; }
        }

        public static void ConstructDict(TreeViewItem item)
        {
            foreach(TreeViewItem subItem in item.Items)
            {
                if (item.Parent == null)
                    dict[""] = subItem.Name;
                else
                    //dict[string.Join('#', item.AncestorsAndSelf().Select(x => x.Name))] = string.Join('#', subItem.AncestorsAndSelf().Select(x => x.Name));
                ConstructDict(subItem);
            }
            
        }

        public static void ConstructTree(string start, int counter)
        {
            foreach(var e in dict)
            {
                if(e.Key == start)
                {

                }
            }
        }

       

    }
}
