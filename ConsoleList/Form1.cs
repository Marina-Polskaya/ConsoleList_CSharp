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
            listBox2.Items.Add(MyList.SelectTailRightName);
            listBox2.Items.Add(MyList.SelectTailLeftName);
            listBox2.Items.Add(MyList.MergeListsName);
            listBox2.EndUpdate();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

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
                MessageBox.Show("Выберите элемент!");
        }

        //Клик по кнопке "Выполнить"
        private void Button2_Click(object sender, EventArgs e)
        {//Проверяем, выделен ли список
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите список!");
            }
            else
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
                }////Если выделена операция "Выделить голову слева"
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

            }
        }       

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void StatusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
             
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
          
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
                }
                else if (listBox2.SelectedItem.ToString() == MySelectedItem.SelectHeadRightName 
                    || listBox2.SelectedItem.ToString() == MySelectedItem.SelectHeadLeftName)
                {
                    label3.Visible = false;
                    label5.Visible = false;
                    textBox1.Visible = false;
                    textBox3.Visible = false;
                }
                else if (listBox2.SelectedItem.ToString() == MySelectedItem.SelectTailRightName
                    || listBox2.SelectedItem.ToString() == MySelectedItem.SelectTailLeftName)
                {

                }
                
            }
        }
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
        private void PrintInBoxFromLeft (ListBox listBox,ListNodes MyList)
        {
            if (MyList.Size == 0)
            {
                textBox2.Text = MyList.Size.ToString();
                MessageBox.Show("Список пуст!");
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
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               