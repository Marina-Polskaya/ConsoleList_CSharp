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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form2_Load);
        }
        private void Form2_Load(object sender, EventArgs e)
        {  
            richTextBox1.ReadOnly = true;
            richTextBox1.UseWaitCursor = false;
            richTextBox1.Text = "Приложение демонстрирует работу\n" +
                "абстрактного типа данных 'список строк'.\n" +
                "Для выполнения операций со списком необходимо:\n" +
                "1. Создать один или более списков. Создаваемые\n" +
                "списки нумеруются, начиная с нуля\n" +
                "2. С помощью мыши выделить список, над которым вы\n" +
                "хотите выполнить операцию. После этого на форме будет\n" +
                "отображено текущее состояние списка: количество элементов\n" +
                "и находящиеся в списке строки.\n" +
                "3. Выберите интересующую вас операцию и нажмите\n" +
                "кнопку 'Выполнить'. Если для операции требуются данные,\n" +
                "введите их в окно редактора. После чего отобразится состояние\n" +
                "списка после выполнения операции.\n" +
                "4. Для выполнения операции Соединить списки необходимо\n" +
                "иметь не менее двух списков. Выберите 2 списка с помощью\n" +
                "мыши. Затем выберите операцию.\n" +
                "Соединить списки и нажмите кнопку 'Выполнить'\n" +
                "После чего отобразится состояние результирующего списка -\n" +
                "списка после выполнения операции.";   
        }
        //При нажатии кнопки "Выход" кнопка "Помощь" в Form1 становится активной
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = (Form1)Application.OpenForms["Form1"];
            f1.button4.Enabled = true;
            this.Close();
        }
    }
}
