﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Array
{
    public class DynamicArray2
    {
		private object[] arr;
		private const int GROWTH_FACTOR = 2;

        public int Count { get; private set; }
        public int Capacity { get { return arr.Length; } }

        public DynamicArray2(int capacity = 16)
        {
            arr = new object[capacity];
            Count = 0;
        }

        public void Add(object element)
        {
            // 배열의 크기가 가득 찼으면 확장
            if (Count >= Capacity)
            {
                int newSize = Capacity * GROWTH_FACTOR;
                var temp = new object[newSize];

                for (int i = 0; i < arr.Length; i++)
                {
                    temp[i] = arr[i];
                }

                arr = temp;
            }

            arr[Count] = element;
            Count++;
        }

        public object Get(int index)
        {
            if (index > Capacity - 1)
            {
                throw new ApplicationException("Out of range ARRAY!");
            }
            return arr[index];
        }
	}
}
