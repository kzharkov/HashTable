using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            int sum = 0;
            Array.ForEach(value.ToCharArray(), delegate (char i) { sum += i; });
            return sum % size;
        }

        public int SeekSlot(string value)
        {
            int slot = HashFun(value);
            int startSlot = slot;
            while (slots[slot] != null && slots[slot] != value)
            {
                slot += step;
                slot %= size;
                if (slot == startSlot) return -1;
            }
            return slot;
        }

        public int Put(string value)
        {
            int slot = SeekSlot(value);
            if (slot != -1)
            {
                slots[slot] = value;
            }
            
            return slot;
        }

        public int Find(string value)
        {
            int slot = HashFun(value);
            int startSlot = slot;
            while (slots[slot] != null)
            {
                if (slots[slot] == value)
                {
                    return slot;
                }
                slot += step;
                slot %= size;
                if (slot == startSlot) break;
            }
            return -1;
        }
    }

}