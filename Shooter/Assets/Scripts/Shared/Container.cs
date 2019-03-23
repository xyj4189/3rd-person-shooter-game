using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Container : MonoBehaviour {

private class ContainerItem
    {
        public System.Guid Id;
        public string Name;
        public int Maximum;

        private int amountTaken;

        public ContainerItem()
        {
            Id = System.Guid.NewGuid();
        }

        public int Remaining
        {
            get
            {
                return Maximum - amountTaken;
            }
        }

        public int Get (int value){
            if ((amountTaken + value) > Maximum)
            {
                int toMuch = (amountTaken + value) - Maximum;
                amountTaken = Maximum;

                return value - toMuch;
            }
                amountTaken += value;
                return value;
           
        }
       

    }

    List<ContainerItem> items;

    void Awake()
    {
        items = new List<ContainerItem>();

    }
    public System.Guid Add(string name, int maximum)
    {
        items.Add(new ContainerItem
        {
            Id = System.Guid.NewGuid(),
            Name = name
        });

        return items.Last().Id;

    }

    public int TakeFromContainer(System.Guid id, int amount){
        var containerItem = items.Where(x => x.Id == id).FirstOrDefault();
        if (containerItem == null)
        
             return -1;//if its less than one it means container itemis not in the container list
      
        
           
            return containerItem.Get(amount);
    }
}
