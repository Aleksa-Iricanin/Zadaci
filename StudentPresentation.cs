using BusinessLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class StudentPresentation : Form
    {
        readonly StudentsBusiness studentsBusiness = new StudentsBusiness();
        public StudentPresentation()
        {
            InitializeComponent();
        }
        
        private void RefreshList()
        {
            bool pera = false;
            listBox1.Items.Clear();
            pera = checkBox1.Checked;
            foreach (Students student in studentsBusiness.GetStudents5(pera))
            {
                string studentData = string.Format("{0}. {1}. {2}. {3}. {4}", student.StudentName, student.IndexNumber, student.ProjectPoints, student.TestPoints, student.ExamMark);
                listBox1.Items.Add(studentData);

            }
           


        }

        private void StudentPresentation_Load(object sender, EventArgs e)
        {
            
            RefreshList();
        }

        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            Students student = new Students()
            {
                StudentName = textBoxStudentName.Text,
                IndexNumber = textBoxIndexNumber.Text,
                ProjectPoints = Convert.ToInt32(textBoxProjectPoints.Text),
                TestPoints = Convert.ToInt32(textBoxTestPoints.Text),
                ExamMark = Convert.ToInt32(textBoxExamMark.Text)
            };

            studentsBusiness.InsertStudent(student);

            RefreshList();

            textBoxStudentName.Text = string.Empty;
            textBoxIndexNumber.Text = string.Empty;
            textBoxProjectPoints.Text = string.Empty;
            textBoxTestPoints.Text = string.Empty;
            textBoxExamMark.Text = string.Empty;

        }
    }
}
