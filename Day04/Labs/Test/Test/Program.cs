//int[] arr = { 16, 17, 4, 3, 5, 2 };
//Stack<int> stack = new Stack<int>();
//int max = arr[arr.Length - 1];
//stack.Push(max);
//for(int i=arr.Length-1; i>=0; i--)
//{
//    if(arr[i] > max)
//    {
//        stack.Push(arr[i]);
//        max = arr[i];
//    }

//}
//while(stack.Count > 0)
//{
//    Console.Write(stack.Pop()+" ");
//}
//String a = "Race";
//String b = "Care";
//char[] aarr =a.ToLower().ToCharArray();
//char[] barr = b.ToLower().ToCharArray();
//Array.Sort(aarr);
//Array.Sort (barr);
//a=aarr.ToString();
//b=barr.ToString();
//if (a == b)
//    Console.WriteLine("Anagram");
//else
//    Console.WriteLine("NotAnagram");

//StackUsingQueue stack= new StackUsingQueue();
//stack.push(10);
//stack.push(20);
//Console.WriteLine(stack.pop());
//stack.push(30);
//Console.WriteLine(stack.pop());

//int[] arr = { 16, 5, 4, 3, 5, 2 };
//int minidx = arr.Length-1;
//Dictionary<int,int> dic=new Dictionary<int,int>();
//for (int i = 0; i < arr.Length; i++)
//{
//    if (dic.ContainsKey(arr[i]))
//    {
//        if (minidx > dic[arr[i]])
//        {
//            minidx = dic[arr[i]];
//        }

//    }
//    else
//    {
//        dic[arr[i]] = i;
//    }

//}
//Console.WriteLine(minidx);
//Console.WriteLine(arr[minidx]);
using System.Text;

String a = "aaabbbbbcdddd";
int n = a.Length;
int count = 1;
StringBuilder sb = new StringBuilder();
for (int i = 0; i < n; i++)
{
    if(i<n-1 && a[i] == a[i+1])
    {
        count++;
    }
    else
    {
        
        sb.Append(a[i]);
        sb.Append(count);
        count = 1;
    }
}
String c=sb.ToString();
if (c.Length > a.Length)
{
   Console.WriteLine(a);
}
else
    Console.WriteLine(c);
