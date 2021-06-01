using System;
using System.Collections.Generic;
using System.Text;

namespace Puzle1_8
{
    class Queue<Int32, Game> 
    {
        public List<KeyValuePair<Int32, Game>> heap;
        private IComparer<Int32> comparer; 
        private const string ioeMessage = "No hay elemento";

        public Queue() : this(Comparer<Int32>.Default)
        {
        }
        public Queue(IComparer<Int32> Comparer)
        {
            if (Comparer == null)
                throw new ArgumentNullException();

            heap = new List<KeyValuePair<Int32, Game>>();
            comparer = Comparer;
        }
        
        public void Enqueue(Int32 Priority, Game Value)
        {
            KeyValuePair<Int32, Game> pair = new KeyValuePair<Int32, Game>(Priority, Value);
            heap.Add(pair);
            LastToFirstControl(heap.Count - 1);
        }

        public KeyValuePair<Int32, Game> Dequeue()
        {
            if (!Vacio)
            {
                KeyValuePair<Int32, Game> result = heap[0]; 
              
                if (heap.Count <= 1) 
                {
                    heap.Clear();
                }
                else 
                {
                    heap[0] = heap[heap.Count - 1];
                    heap.RemoveAt(heap.Count - 1);
                    FirstToLastControl(0);
                }
                return result;
            }
            else
                throw new InvalidOperationException(ioeMessage);
        }
        public int Count()
        {
            return heap.Count;
        }
        public KeyValuePair<Int32, Game> Peek()
        {
            if (!Vacio) 
            {
                return heap[0];
            }
            else 
            {
                throw new InvalidOperationException(ioeMessage);
            }
               
        }
        
        public List<Game> getHeapVariables()
        {
            List<Game> list = new List<Game>();
            for (int i = 0; i < heap.Count; i++)
            {
                list.Add(heap[i].Value);
            }
            return list;
        }
        public List<int> getHeapCosts()
        {
            List<int> list = new List<int>();

            for (int i = 0; i < heap.Count; i++)
            {
                list.Add(Convert.ToInt32(heap[i].Key));
            }
            return list;
        }

        public bool Vacio
        {
            get { return heap.Count == 0; }
        }

        private int LastToFirstControl(int Posisiton)
        {
            if (Posisiton >= heap.Count)
                return -1;
            int parentPos;
            while (Posisiton > 0)
            {
                parentPos = (Posisiton - 1) / 2;
                if (comparer.Compare(heap[parentPos].Key, heap[Posisiton].Key) > 0)
                {
                    ExchangeElements(parentPos, Posisiton);
                    Posisiton = parentPos;
                }
                else break;
            }
            return Posisiton;
        }

        private void FirstToLastControl(int Position)
        {
            if (Position >= heap.Count)
                return;
            while (true)
            {
                int smallestPosition = Position;
                int leftPosition = 2 * Position + 1;
                int rightPosition = 2 * Position + 2;
                if (leftPosition < heap.Count && comparer.Compare(heap[smallestPosition].Key, heap[leftPosition].Key) > 0)
                    smallestPosition = leftPosition;
                if (rightPosition < heap.Count && comparer.Compare(heap[smallestPosition].Key, heap[rightPosition].Key) > 0)
                    smallestPosition = rightPosition;
                if (smallestPosition != Position)
                {
                    ExchangeElements(smallestPosition, Position);
                    Position = smallestPosition;
                }
                else break;
            }
        }

        private void ExchangeElements(int Position1, int Position2)
        {
            KeyValuePair<Int32, Game> val = heap[Position1];
            heap[Position1] = heap[Position2];
            heap[Position2] = val;
        }
    }
}
