using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    enum PivotChoiсe
    {
        first,
        middle,
        last
    }
    internal class Vector
    {
        int[] arr;

        public int Length { get { return arr.Length; } }
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < arr.Length)
                {
                    return arr[index];
                }
                else
                {
                    throw new Exception("Index out of range array");
                }
            }
            set
            {
                if (index >= 0 && index < arr.Length)
                {
                    arr[index] = value;
                }
                else
                {
                    throw new Exception("Index out of range array");
                }
            }
        }

        public Vector(int[] arr)
        {
            this.arr = arr;
        }

        public Vector(int n)
        {
            arr = new int[n];
        }

        public Vector()
        {
            arr = new int[1];
        }


        public void RandomInitialization(int a, int b)
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(a, b);
            }
        }

        public void RandomInitialization()
        {
            //int index = Array.IndexOf(arr, 2);
            //Console.WriteLine(index);

            Random random = new Random();
            int x;
            for (int i = 0; i < arr.Length; i++)
            {
                while (arr[i] == 0)
                {
                    x = random.Next(1, arr.Length + 1);
                    bool isExist = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (x == arr[j])
                        {
                            isExist = true;
                            break;
                        }
                    }
                    if (!isExist)
                    {
                        arr[i] = x;
                        break;
                    }
                }
            }
        }
        public void InitShuffle()
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                arr[i] = i;
            }
            Random random = new Random();
            while (n > 1)
            {
                int k = random.Next(n--);
                int temp = arr[n];
                arr[n] = arr[k];
                arr[k] = temp;
            }
        }
        public Pair[] CalculateFreq()
        {

            Pair[] pairs = new Pair[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                pairs[i] = new Pair(0, 0);

            }
            int countDifference = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                bool isElement = false;
                for (int j = 0; j < countDifference; j++)
                {
                    if (arr[i] == pairs[j].Number)
                    {
                        pairs[j].Freq++;
                        isElement = true;
                        break;
                    }
                }
                if (!isElement)
                {
                    pairs[countDifference].Freq++;
                    pairs[countDifference].Number = arr[i];
                    countDifference++;
                }
            }

            Pair[] result = new Pair[countDifference];
            for (int i = 0; i < countDifference; i++)
            {
                result[i] = pairs[i];
            }

            return result;
        }

        public bool IsPalindrom()
        {
            bool result = true;
            for (int i = 0; i < arr.Length / 2; i++)
            {
                if (arr[i] != arr[arr.Length - 1 - i])
                {
                    result = false;
                    break;
                }
            }
            return (result);
        }
        public void CustomReverse()
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                int a = arr[i];
                arr[i] = arr[arr.Length - 1 - i];
                arr[arr.Length - 1 - i] = a;
            }
        }
        public void Reverse()
        {
            Array.Reverse(arr);
        }
        public Vector Subsequence()//повертатимемо першу підпослідовність, якщо буде кілька однакової довжини
        {
            int numb = 0;
            int count = 0;
            int numb_max = 0;
            int count_max = 0;
            for (int i = 0; i < arr.Length - count_max;)
            {
                numb = arr[i];
                count = 1;
                i++;
                for (; (i < arr.Length) && (numb == arr[i]); i++)
                {
                    count++;
                }
                if (count > count_max)
                {
                    count_max = count;
                    numb_max = numb;
                }
            }
            int[] result_arr = new int[count_max];
            for (int i = 0; i < count_max; i++)
                result_arr[i] = numb_max;

            return new Vector(result_arr);
        }
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str += arr[i] + " ";
            }
            return str;
        }

        //швидке сортування
        public void QuickSort(PivotChoiсe choiсe = 0)
        {
            SortArray(0, arr.Length - 1, choiсe);
        }


        private void SortArray(int leftIndex, int rightIndex, PivotChoiсe choiсe)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = arr[leftIndex];
            if (choiсe == PivotChoiсe.middle)
            {
                pivot = arr[(rightIndex + leftIndex) / 2];
            }
            else if (choiсe == PivotChoiсe.last)
            {
                pivot = arr[rightIndex];
            }
            while (i <= j)
            {
                while (arr[i] < pivot)
                {
                    i++;
                }

                while (arr[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                SortArray(leftIndex, j, choiсe);
            if (i < rightIndex)
                SortArray(i, rightIndex, choiсe);
        }

        public void Merge(int l, int q, int r)
        {
            int i = l;
            int j = q;
            int[] temp = new int[r - l];
            int k = 0;
            while (i < q && j < r)
            {
                if (arr[i] < arr[j])
                {
                    temp[k] = arr[i];
                    i++;
                }
                else
                {
                    temp[k] = arr[j];
                    j++;
                }
                k++;
            }
            if (i == q)
            {
                for (int m = j; m < r; m++)
                {
                    temp[k] = arr[m];
                    k++;
                }
            }
            else
            {
                while (i < q)
                {
                    temp[k] = arr[i];
                    i++;
                    k++;
                }
            }
            for (int n = 0; n < temp.Length; n++)
            {
                arr[n + l] = temp[n];
            }
        }
        public void SplitMergeSort()
        {
            SplitMergeSort(0, arr.Length);
        }
        private void SplitMergeSort(int start, int end)
        {

            if (end - start <= 1)
            {
                return;
            }
            int middle = (end + start) / 2;
            SplitMergeSort(start, middle);
            SplitMergeSort(middle, end);
            Merge(start, middle, end);
        }

        public void ReadFromFile(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            ReadFromStreamReader(reader);
        }
        public void ReadFromStreamReader(StreamReader reader)//якщо масив записаний в одному рядку
        {
            string line = reader.ReadLine();
            string[] numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            arr = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                arr[i] = Int32.Parse(numbers[i]);
            }
            reader.Close();
        }
        public void WriteToFileLine(StreamWriter writer)//запис у файл в один рядок
        {
            writer.Write(this.ToString());
        }
        public void WriteToFileColumn(StreamWriter writer)//запис у файл у стовбець
        {
            for (int i = 0; i < this.Length; i++)
            {
                writer.WriteLine(arr[i]);
            }
        }
        public void WriteToFile(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            WriteToFileLine(writer);
            writer.Close();
        }
        public void HeapSort()
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                Heapify(i, 0);
            }
        }
        private void Heapify(int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && arr[left] > arr[largest])
                largest = left;
            if (right < n && arr[right] > arr[largest])
                largest = right;
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                Heapify(n, largest);
            }
        }

    }
}
