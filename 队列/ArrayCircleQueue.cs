﻿using System;

namespace 队列
{

    /// <summary>
    /// 循环顺序队列
    /// </summary>
    public class ArrayCircleQueue<T> where T : IComparable<T>
    {
        private T[] items;
        private int capacity;
        private int head;
        private int tail;
        private int count;
        public int Count => count;
        public int Capacity => capacity;

        public ArrayCircleQueue() : this(4)
        {

        }

        public ArrayCircleQueue(int capacity)
        {
            items = new T[capacity];
            this.capacity = capacity;
        }


        public void Enqueue(T item)
        {
            if (count == capacity)
            {
                int newCapacity = capacity * 2;
                T[] newItems = new T[newCapacity];
                Array.Copy(items, newItems, capacity);
                tail = capacity;
                head = head % capacity;
                capacity = newCapacity;
                items = newItems;
            }
            items[tail] = item;
            tail = (tail + 1) % capacity;
            count++;
        }

        public T Dequeue()
        {
            if (count == 0)
            {
                throw new Exception("the queue is empty");
            }
            T item = items[head];
            items[head] = default(T);
            count--;
            head = (head + 1) % capacity;
            return item;
        }
    }
}
