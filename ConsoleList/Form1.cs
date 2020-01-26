                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConsoleList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form1_Load);
            button1.MouseEnter += Button1_MouseEnter;
            button1.MouseLeave += Button1_MouseLeave;
            button2.MouseEnter += Button2_MouseEnter;
            button2.MouseLeave += Button2_MouseLeave;
            button3.MouseEnter += Button3_MouseEnter;
            button3.MouseLeave += Button3_MouseLeave;
            button4.MouseEnter += Button4_MouseEnter;
            button4.MouseLeave += Button4_MouseLeave;
            button5.MouseEnter += Button5_MouseEnter;
            button5.MouseLeave += Button5_MouseLeave;
        }
        private void Form1_Load (object sender, EventArgs e)
        {   
            listBox2.BeginUpdate();
            //Отразим операции в listBox2
            ListNodes MyList = new ListNodes();
            listBox2.Items.Add(MyList.AddRightName);
            listBox2.Items.Add(MyList.AddLeftName);
            listBox2.Items.Add(MyList.SelectHeadRightName);
            listBox2.Items.Add(MyList.SelectHeadLeftName);
            listBox2.Items.Add(MyList.TailIfCountFromRightName);
            listBox2.Items.Add(MyList.TailIfCountFromLeftName);
            listBox2.Items.Add(MyList.MergeListsName);
            listBox2.EndUpdate();
        }
        //Подсказки при наведении мышью на кнопки
        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Создаёт новый пустой список";
            CreateToolTip(button1, "Создаёт новый пустой список");
        }
        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "";
        }
        private void Button2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Выполняет выбранную операцию для выбранного списка";
            CreateToolTip(button2, "Выполняет выбранную операцию для выбранного списка");
        }
        private void Button2_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "";
        }
        private void Button3_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Удаляет последний список";
            CreateToolTip(button3, "Удаляет последний список");
        }
        private void Button3_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "";
        }
        private void Button4_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Вызывает справочное окно";
            CreateToolTip(button4, "Вызывает справочное окно");
        }
        private void Button4_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "";
        }
        private void Button5_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Обеспечивает закрытие формы";
            CreateToolTip(button5, "Обеспечивает закрытие формы");
        }
        private void Button5_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "";
        }
        //Всплывающие подсказки
        private void CreateToolTip(Control controlForToolTip, string toolTipText)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.Active = true;
            toolTip.SetToolTip(controlForToolTip, toolTipText);
            toolTip.IsBalloon = true;
        }
        //Клик по кнопке "Создать список". Создание пустых списков
        private void Button1_Click(object sender, EventArgs e)
        {
            ListNodes MyNewList = new ListNodes();
            listBox1.DisplayMember = "Name";
            listBox2.DisplayMember = "ActionName";
            int ListsInBox = listBox1.Items.Count;
            if (ListsInBox == 0)
            { //Если список пуст
                MyNewList.Name = "List0";
                listBox1.Items.Add(MyNewList);
            }
            else
            {
                MyNewList.Index = ListsInBox;
                MyNewList.Name = "List" + MyNewList.Index.ToString();
                listBox1.Items.Add(MyNewList);
                MyNewList.Index += 1;
            }            
        }
        //Клик по кнопке "Удалить список". Удаляет только последний список
        private void Button3_Click(object sender, EventArgs e)
        {
            int ListBox1Size = listBox1.Items.Count;
            if (ListBox1Size > 0)
            {
                listBox1.Items.RemoveAt(ListBox1Size - 1);
            }
            else
                MessageBox.Show("Списки отсутствуют!");
        }
        //Клик по кнопке "Выполнить"
        private void Button2_Click(object sender, EventArgs e)
        {//Проверяем, выделен ли список
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите список!");
            }//Если выделен 1 список
            else if (listBox1.SelectedItems.Count == 1)
            {//Проверяем, выбрана ли операция
                ListNodes MySelectedItem = new ListNodes();
                MySelectedItem = GetParameter<ListNodes>(listBox1.SelectedItem);
                string myListItem = textBox1.Text.Trim();
                if (listBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите операцию!");
                }//Если выделена операция "Добавить справа"
                else if (listBox2.SelectedItem.ToString() == MySelectedItem.AddRightName)
                {
                    if (myListItem == string.Empty)
                    {
                        MessageBox.Show("Введите значение в текстовое поле!");
                    }
                    else
                    {//Добавляем справа

                        MySelectedItem.AddRight(Convert.ToInt32(myListItem));
                        textBox2.Text = Convert.ToString(MySelectedItem.Size);
                        listBox3.Items.Clear();
                        PrintInBoxFromLeft(listBox3, MySelectedItem);
                        label7.Text = "Элементы, начиная с головы (слева)";

                    }
                }//Если выделена операция "Добавить слева"
                else if (listBox2.SelectedItem.ToString() == MySelectedItem.AddLeftName)
                {
                    if (textBox1.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Введите значение в текстовое поле!");
                    }
                    else
                    {
                        MySelectedItem.AddLeft(Convert.ToInt32(myListItem));
                        textBox2.Text = Convert.ToString(MySelectedItem.Size);
                        listBox3.Items.Clear();
                        PrintInBoxFromLeft(listBox3, MySelectedItem);
                        label7.Text = "Элементы, начиная с головы (слева)";
                    }
                }//Если выделена операция "Выделить голову справа"
                else if (listBox2.SelectedItem.ToString() == MySelectedItem.SelectHeadRightName)
                {
                    if (MySelectedItem.IsListEmpty())
                    {
                        MessageBox.Show("Список пуст!");
                    }
                    else
                    {
                        label7.Text = "Элементы, начиная с головы (справа)";
                        label5.Visible = true;
                        textBox3.Visible = true;
                        listBox3.Items.Clear();
                        textBox3.Text = MySelectedItem.HeadRight().ToString();
                        PrintInBoxFromRight(listBox3, MySelectedItem);
                    }
                }
                //Если выделена операция "Выделить голову слева"
                else if (listBox2.SelectedItem.ToString() == MySelectedItem.SelectHeadLeftName)
                {
                    if (MySelectedItem.IsListEmpty())
                    {
                        MessageBox.Show("Список пуст!");
                    }
                    else
                    {
                        label7.Text = "Элементы, начиная с головы (слева)";
                        label5.Visible = true;
                        textBox3.Visible = true;
                        listBox3.Items.Clear();
                        textBox3.Text = MySelectedItem.HeadLeft().ToString();
                        PrintInBoxFromLeft(listBox3, MySelectedItem);
                    }
                }
                //Если выделена операция "Выделить хвост (слева направо)"
                else if (listBox2.SelectedItem.ToString() == MySelectedItem.TailIfCountFromLeftName)
                {
                    if (MySelectedItem.IsListEmpty())
                    {
                        MessageBox.Show("Список пуст!");
                    }
                    else
                    {
                        MySelectedItem = MySelectedItem.TailIfCountFromLeft();
                        label7.Text = "Элементы, образующие хвост (слева направо)";
                        label5.Visible = false;
                        textBox3.Visible = false;
                        listBox3.Items.Clear();
                        PrintInBoxFromLeft(listBox3, MySelectedItem);
                    }
                }
                //Если выделена операция "Выделить хвост (справа налево)"
                else if (listBox2.SelectedItem.ToString() == MySelectedItem.TailIfCountFromRightName)
                {
                    MySelectedItem = MySelectedItem.TailIfCountFromRight();
                    label7.Text = "Элементы, образующие хвост (справа налево)";
                    label5.Visible = false;
                    textBox3.Visible = false;
                    listBox3.Items.Clear();
                    PrintInBoxFromRight(listBox3, MySelectedItem);
                    textBox2.Text = MySelectedItem.Size.ToString();
                }
                //Если выделена операция "Соединить списки"
                else if (listBox2.SelectedItem.ToString() == MySelectedItem.MergeListsName)
                {
                    MessageBox.Show("Выберите два списка!");
                }
            }
            //Если выделены 2 списка
            else if (listBox1.SelectedItems.Count == 2)
            {
                //listBox2.SetSelected(1, false);
                ListNodes FirstSelectedItem = new ListNodes();
                FirstSelectedItem = GetParameter<ListNodes>(listBox1.SelectedItems[0]);
                ListNodes SecondSelectedItem = new ListNodes();
                SecondSelectedItem = GetParameter<ListNodes>(listBox1.SelectedItems[1]);
                //Если выбрана операция "Соединить списки"
                if (listBox2.SelectedItem.ToString() == FirstSelectedItem.MergeListsName)
                {
                    listBox4.Items.Clear();
                    label10.Text = "Результирующий список " + FirstSelectedItem.Name;
                    textBox2.Text = FirstSelectedItem.Size.ToString();
                    FirstSelectedItem.MergeLists(SecondSelectedItem);
                    PrintInBoxFromLeft(listBox4, FirstSelectedItem);
                    textBox4.Text = FirstSelectedItem.Size.ToString();
                    PrintInBoxFromLeft(listBox3, SecondSelectedItem);
                    label6.Text = "Состояние списка " + SecondSelectedItem.Name;
                }
                else
                {
                    MessageBox.Show("Неверное действие! Прочтите руководство по использованию, нажав на кнопку 'Помощь'");
                }
            }
            else
            {
                MessageBox.Show("Неверное действие! Прочтите руководство по использованию, нажав на кнопку 'Помощь'");
            }
        }       
        public static T GetParameter<T>(object obj) where T : class
        {
            return obj as T;
        }
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {//Если выделен список в listBox1, отображаем инф. о списке
            if(listBox1.SelectedIndex != -1)
            {
                label4.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                textBox2.Visible = true;
                listBox3.Visible = true;
                textBox3.Text = "";
                listBox3.Items.Clear();
                //Работаем с выделенным списком
                ListNodes MySelectedItem = new ListNodes();
                MySelectedItem = GetParameter<ListNodes>(listBox1.SelectedItem);
                //Определяем длину списка, выводим информацию о списке
                if (MySelectedItem.IsListEmpty())
                {                    
                    textBox2.Text = "0";                   
                }
                else
                { 
                    PrintInBoxFromLeft(listBox3, MySelectedItem);
                    label5.Visible = false;
                    textBox3.Visible = false;
                }
                label6.Text = "Состояние списка " + MySelectedItem.Name;
                label6.ForeColor = Color.Red;
            }
        }        
        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListNodes MySelectedItem = new ListNodes();
            MySelectedItem = GetParameter<ListNodes>(listBox1.SelectedItem);
            if (listBox2.SelectedIndex != -1)
            {
                if (listBox2.SelectedItem.ToString() == MySelectedItem.AddRightName 
                    || listBox2.SelectedItem.ToString() == MySelectedItem.AddLeftName)
                {
                    label3.Visible = true;
                    label5.Visible = false;
                    textBox1.Visible = true;
                    textBox3.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;
                    label10.Visible = false;
                    textBox4.Visible = false;
                    listBox4.Visible = false;
                }
                else if (listBox2.SelectedItem.ToString() == MySelectedItem.SelectHeadRightName 
                    || listBox2.SelectedItem.ToString() == MySelectedItem.SelectHeadLeftName)
                {
                    label3.Visible = false;
                    label5.Visible = false;
                    textBox1.Visible = false;
                    textBox3.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;
                    label10.Visible = false;
                    textBox4.Visible = false;
                    listBox4.Visible = false;
                }
                else if (listBox2.SelectedItem.ToString() == MySelectedItem.TailIfCountFromRightName
                    || listBox2.SelectedItem.ToString() == MySelectedItem.TailIfCountFromLeftName)
                {
                    label3.Visible = false;
                    textBox1.Visible = false;
                    label5.Visible = false;
                    textBox3.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;
                    label10.Visible = false;
                    textBox4.Visible = false;
                    listBox4.Visible = false;
                }
                else if (listBox2.SelectedItem.ToString() == MySelectedItem.MergeListsName)
                {
                    label3.Visible = false;
                    textBox1.Visible = false;
                    label5.Visible = false;
                    textBox3.Visible = false;
                    label8.Visible = true;
                    label9.Visible = true;
                    label10.Visible = true;
                    textBox4.Visible = true;
                    listBox4.Visible = true;
                }
            }
        }
        //Вывод элементов справа налево
        private void PrintInBoxFromRight(ListBox listBox, ListNodes MyList)
        {
            if (MyList.Size == 0)
            {
                MessageBox.Show("Список пуст!");
            }
            else
            {
                for (int i = MyList.Size; i >= 1; i--)
                {
                    listBox.Items.Add(MyList[i]);
                }
                textBox2.Text = MyList.Size.ToString();
            }
        }
        //Вывод элементов слева направо
        private void PrintInBoxFromLeft (ListBox listBox,ListNodes MyList)
        {
            if (MyList.Size == 0)
            {
                textBox2.Text = MyList.Size.ToString();
                listBox.Items.Clear();
            }
            else
            {
                for (int i = 1; i <= MyList.Size; i++)
                {
                    listBox.Items.Add(MyList[i]);
                }
                textBox2.Text = MyList.Size.ToString();
            }
        }
        //При клике на кнопку Помощь
        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            button4.Enabled = false;
            form2.Show();
        }
        //При клике на кнопку Выход
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               