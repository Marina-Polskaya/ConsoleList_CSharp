using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleList
{
    class ListNodes
    {
        //Голова списка.
        Node first = null;
        //Конец списка.
        Node last = null;
        //Размер списка. 
        int size = 0;
        //Свойство для доступа к размеру списка
        string name = "0";
        int index;
        string addRightName = "Добавить справа";
        string addLeftName = "Добавить слева";
        string selectHeadRightName = "Выделить голову справа";
        string selectHeadLeftName = "Выделить голову слева";
        string tailIfCountFromRightName = "Выделить хвост (справа налево)";
        string tailIfCountFromLeftName = "Выделить хвост (слева направо)";
        string mergeListsName = "Соединить списки";

        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
            }
        }
        public string AddRightName
        {
            get
            {
                return addRightName;
            }
        }
        public string AddLeftName
        {
            get
            {
                return addLeftName;
            }
        }
        public string SelectHeadRightName
        {
            get
            {
                return selectHeadRightName;
            }
        }
        public string SelectHeadLeftName
        {
            get
            {
                return selectHeadLeftName;
            }
        }
        public string TailIfCountFromRightName
        {
            get
            {
                return tailIfCountFromRightName;
            }
        }
        public string TailIfCountFromLeftName
        {
            get
            {
                return tailIfCountFromLeftName;
            }
        }
        public string MergeListsName
        {
            get
            {
                return mergeListsName;
            }
        }

        //Свойство-индексатор для доступа к элементам списка по индексу
        public int this[int i]
        {
            get
            {
                Node t = first;
                while (t != null & i - 1 > 0)
                {
                    t = t.Next;
                    i--;
                }
                return t.Key;
            }
        }
        
        //Добавить элемент справа.
        public void AddRight(int key_)
        {
            if (size == 0)
            {
                first = new Node(key_);
                last = first;
                size++;
                return;
            }
            last.Next = new Node(key_);
            last = last.Next;
            size++;
        }
        //Возвращает указатель на предпоследний узел.
        public Node PredLast()
        {
            Node pred = first, lst = first.Next;
            if (Size == 0 | Size == 1)
            {
                return null;
            }
            while (lst.Next != null)
            {
                pred = lst;
                lst = lst.Next;
            }
            return pred;
        }

        //Добавить элемент слева.
        public void AddLeft(int key_)
        {
            if (size == 0)
            {
                first = new Node(key_);
                last = first;
                size++;
            }
            else
            {
                first = new Node(key_, first);
                size++;
            }
        }
        public void CleanOutList()
        {
            first = null;
            last = null;
            size = 0;
        }
        //Выделить голову слева
        public int HeadLeft()
        {
            int headKey = 0;
            try
            {
                if (IsListEmpty() == true)
                {
                    throw new Exception("cписок пуст.");
                }
                else
                {
                    headKey = first.Key;
                    first = this.first.Next;
                    size--;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Действие не выполнено. Ошибка: " + ex.Message + "\n");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return headKey;
        }

        //Выделить голову справа
        public int HeadRight()
        {
            int headKey = 0;
            try
            {
                if (IsListEmpty() == false)
                {
                    headKey = last.Key;
                    last.Next = null;
                    last = PredLast();
                    size--;
                }
                else
                {
                    throw new Exception("cписок пуст.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Действие не выполнено. Ошибка: " + ex.Message + "\n");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return headKey;
        }

        public bool IsListEmpty() //если пустой - истина
        {
            if (size == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ListNodes TailIfCountFromLeft()
        {
            int headKey = 0;
            if (IsListEmpty() == true || size == 1)
            {
                size = 0;
            }
            else
            {
                headKey = first.Key;
                first = this.first.Next;
                size--;
            }
            return this;
        }
        public ListNodes TailIfCountFromRight()
        {
            int headKey = 0;
            if (IsListEmpty() == true || size == 1)
            {
                size = 0;
            }
            else
            {
                headKey = last.Key;
                last.Next = null;
                last = PredLast();
                size--;
            }
            return this;
        }
        public void MergeLists(ListNodes MyList)
        {
            for (int i = 1; i <= MyList.Size; i++)
            {
                this.AddRight(MyList[i]);
            }
            MyList.CleanOutList();
        }
    }
}