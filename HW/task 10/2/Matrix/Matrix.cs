using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Matrix: IEnumerator
    {
        private int n;
        private int m;
        private int[,] arr;
        private int positionI;
        private int positionJ;
        bool moveRight;
        public Matrix()
        {
            n = 1;
            m = 1;
            arr = new int[n, m];
            positionI = 0;
            positionJ = -1;
            moveRight = true;
        }
        public Matrix(int n_, int m_)
        {
            n = n_;
            m = m_;
            arr = new int[n, m];
            int num = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    arr[i, j] = num++;
            positionI = 0;
            positionJ = -1;
            moveRight = true;
        }
        public object Current
        {
            get
            {
                try
                {
                    return arr[positionI, positionJ];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        public bool MoveNext()
        {
            
            if (positionI >= n)
            {
                return false;
            }
            if(moveRight)
                ++positionJ;
            else
                --positionJ;

            if (positionJ >= m)
            {
                moveRight = false;
                positionJ = m - 1;
                return ++positionI < n;
                
            }
            else if ( positionJ < 0)
            {
                moveRight = true;
                positionJ = 0;
                return ++positionI < n;
            }
            else
            {
                return true;
            }
            
        }
        public void Reset()
        {
            positionI = 0;
            positionJ = -1;
            moveRight = true;
        }
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public void VerticalSnake()
        {
            int num = 1;
            for (int j = 0; j < m;)
            {
                for (int i = 0; i < n; i++)
                {
                    arr[i, j] = num;
                    num ++;
                }
                j++;
                if (j == m)
                    break;
                for (int i = n - 1; i >= 0; i--)
                {
                    arr[i, j] = num;
                    num++;
                }
                j++;
            }
        }
        public void MainDiag(bool ToTheRight = false)
        {
            int num = 1;
            int i = 0, j = 0;
            if (ToTheRight)
            {
                arr[0, 0] = num;
                num++;
                j = 1;
            }
            for (; (j < m) || (i < n);)
            {
                for (; (i < n) && (j >= 0); ++i, --j)//вниз
                {
                    arr[i, j] = num;
                    num++;
                }
                if (i >= n)
                { --i; j += 2; }
                else if (j < 0)
                { ++j; }

                for (; (i >= 0) && (j < m); --i, ++j)//вгору
                {
                    arr[i, j] = num;
                    num++;
                }
                if (j >= m)
                { --j; i += 2; }
                else if (i < 0)
                { ++i; }
            }
        }
        public void MainDiagSquare()
        {
            if (n!=m )
            {
                Console.WriteLine("N != M - matrix is not square");
                return;
            }
            int num = 1;
            for (int i = 0, j = 0; (j < n) || (i < n);)
            {
                for (; (i < n) && (j >= 0); ++i, --j)//вниз
                {
                   
                }
            }
        }
        public void Spiral()
        {
            int num = 1;
            float p = ((float)Math.Min(n, m)) / 2;//визначаємо, скільки буде кіл

            int i = n, j = -1;
            for (int step = 0; step < p; ++step)
            {
                for (++j, --i; (i >= step) && (arr[i, j] == 0); --i)//вгору
                {
                    arr[i, j] = num;
                    num++;
                }
                for (++i, ++j; (j <= m - 1 - step) && (arr[i, j] == 0); ++j)//вправо
                {
                    arr[i, j] = num;
                    num++;
                }
                for (--j, ++i; (i <= n - 1 - step) && (arr[i, j] == 0); ++i)//вниз
                {
                    arr[i, j] = num;
                    num++;

                }
                for (--i, --j; (j >= 1 + step) && (arr[i, j] == 0); --j)//вліво
                {
                    arr[i, j] = num;
                    num++;
                }
            }

            /*for (int step = 0; step < p; ++step)
            {
                for (; (i > step) && (arr[i, j] == 0); --i)//вгору
                {
                    arr[i, j] = num;
                    num++;
                }
                for (; (j < m - 1 - step) && (arr[i, j] == 0); ++j)//вправо
                {
                    arr[i, j] = num;
                    num++;
                }
                for (; (i < n - 1 - step) && (arr[i, j] == 0); ++i)//вниз
                {
                    arr[i, j] = num;
                    num++;

                }
                for (; (j > 1 + step) && (arr[i, j] == 0); --j)//вліво
                {
                    arr[i, j] = num;
                    num++;
                }
            }*/

            //if (arr[i, j] == 0)  
            //arr[i, j] = num;

        }

        public void test()
        {
            
            int middle = n / 2;
            int a = middle;
            for (int i = 0; i < middle; i++, a--)
            {
                for (int j = 0; j < a; j++)
                {
                    arr[i, j] = 1;
                }
            }
            a = middle;
            for (int i = 0; i < middle; i++, a++)
            {
                for (int j = a + 1; j < n; j++)
                {
                    arr[i, j] = 2;
                }
            }
            a = 0;
            for (int i = middle; i < n; i++, a++)
            {
                for (int j = 0; j < a; j++)
                {
                    arr[i, j] = 3;
                }

            }
            a = 0;
            for (int i = middle + 1; i < n; i++, a++)
            {
                for (int j = n - 1 - a; j < n; j++)
                {
                    arr[i, j] = 4;
                }

            }
        }
        public void Print()
        {
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.Write("\n");
            }
        }
        

       
    }
}
