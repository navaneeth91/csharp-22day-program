using System.Collections.Generic;
class StackUsingQueue
{
    Queue<int> queue = new Queue<int>();
    public void push(int x)
    {
        queue.Enqueue(x);
        for (int i = 0; i < queue.Count; i++)
        {
            queue.Enqueue(queue.Dequeue());
        }
    }
    public int pop()
    {
        return queue.Dequeue();
    }


}