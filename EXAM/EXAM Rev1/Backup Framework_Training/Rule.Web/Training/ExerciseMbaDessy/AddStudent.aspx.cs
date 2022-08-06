using AdIns.Service;
using Rule.Web;
using Rule.Web.WebUserControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.API;
using Training.DataModel.TrainingModel;

namespace Training.ExerciseMbaDessy
{
    public partial class AddStudent : WebFormBase
    {
        #region PAGE CONTROL
        protected global::Rule.Web.WebUserControl.UCDatePicker ucBirthDt;
        protected global::Rule.Web.WebUserControl.UCInputNumber ucInputScore;
        protected global::Rule.Web.WebUserControl.Lookup.UCLookupMajor ucLookup;    //udah comment di designer
        protected global::Rule.Web.WebUserControl.UCReference ucCourse, ucCourseCode;
        #endregion
        #region PROPERTIES
        private enum SaveMode
        {
            Add,
            Edit,
        }
        private SaveMode mode
        {
            get { return (SaveMode)ViewState["mode"]; }
            set { ViewState["mode"] = value; }
        }
        private Int64 studentId
        {
            get { return (Int64)ViewState["studentId"]; }
            set { ViewState["studentId"] = value; }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                {
                    try
                    {
                        studentId = Convert.ToInt64(base.RedirectState["studentId"]);
                        setEditScreen();

                        mode = SaveMode.Edit;
                    }
                    catch
                    {
                        mode = SaveMode.Add;
                    }
                }
                
                setScreen();
                ucLookup.TextBoxEnable = false;
                ucLookup.LookupBase.EnableTextChanged();
                ucLookup.LookupBase.txtInputObj.TextChanged += new EventHandler(ucLookup.LookupBase.txtInput_TextChanged);
                //txtStudentNo.Enabled = false;
            }

        }

        private void setScreen()
        {
            IRefCourseService studSvc = (IRefCourseService)UnityFactory.Resolve<IRefCourseService>();

            #region CourseCode
            List<RefCourse> listCourseCode = studSvc.listOfRefCourse(".Net Course");
            ucCourse.BindingObject(listCourseCode, "CourseCode", "CourseName", true, UCReference.AdditionalSelectionType.SelectOne);
            #endregion

            #region Course
            List<RefCourse> listCourse = studSvc.listOfRefCourse(".Net Course");
            ucCourseCode.BindingObject(listCourse, "CourseName", "CourseCode", true, UCReference.AdditionalSelectionType.SelectOne);
            #endregion
        }
        #region TOOLBAR
        protected void lb_Toolbar_Save_Click(object sender, EventArgs e)
        {
            IStudentService iss = (IStudentService)UnityFactory.Resolve<IStudentService>();

            Student stud = new Student();
            

            stud.StudentId = Convert.ToInt64(txtStudentId.Text);
            stud.Name = txtStudentName.Text;
            stud.StudentNo = txtStudentNo.Text;
            stud.Address = txtAddress.Text;
            stud.BirthPlace = txtBirthPlace.Text;
            stud.BirthDt = ucBirthDt.DateValue;
            stud.RefMajorId = Convert.ToInt64(ucLookup.RefMajorId);

            for (int i = 0; i < gvScoreTemp.Rows.Count; i++)
            {
                StudentScore StudSc = new StudentScore();
                //string lblGridRefCourseId = ((Label)gvScoreTemp.Rows[i].FindControl("lblGridRefCourseId")).Text;
                string lblGridCourseCode = ((Label)gvScoreTemp.Rows[i].FindControl("lblGridCourseCode")).Text;
                string lblGridCourseName = ((Label)gvScoreTemp.Rows[i].FindControl("lblGridCourseName")).Text;
                string lblGridScore = ((Label)gvScoreTemp.Rows[i].FindControl("lblGridScore")).Text;
                string lblGridScoreId = ((TextBox)gvScoreTemp.Rows[i].FindControl("txtStudentScoreIdTemp")).Text;

                RefCourse refcourse = iss.listOfCourse(lblGridCourseCode);

                StudSc.StudentScoreId = Convert.ToInt64(lblGridScoreId);
                //StudSc.RefCourseId = Convert.ToInt64(lblGridRefCourseId);
                stud.StudentScore.Add(StudSc);
            }
            iss.AddStud(stud);



            //}
            //iss.AddStud(StudSc);



            //IStudentService iss = (IStudentService)UnityFactory.Resolve<IStudentService>();
            //if (mode == SaveMode.Add)
            //{


            //    StudentScore studentScore = new StudentScore();
            //    string saveMode = string.Empty;
            //    string user = "Training";
            //    DateTime date = DateTime.Now;
            //    Student student = new Student();
            //    student.StudentId = Convert.ToInt64(txtStudentId.Text);
            //    student.StudentNo = txtStudentNo.Text;
            //    student.Name = txtStudentName.Text;
            //    student.Address = txtAddress.Text;
            //    student.BirthPlace = txtBirthPlace.Text;
            //    student.BirthDt = Convert.ToDateTime(ucBirthDt.DateValue);


            //    student.RefMajorId = Convert.ToInt64(txtRefMajorId.Text);
            //    //student.AddStud(student);

            //}
            //else if (mode == SaveMode.Edit)
            //{
            //    Student student = iss.GetStudentById(studentId);
            //    student.StudentNo = txtStudentNo.Text;
            //    student.Name = txtStudentName.Text;
            //    student.Address = txtAddress.Text;
            //    student.BirthPlace = txtBirthPlace.Text;
            //}
            //RedirectUrl("~/Training/ExerciseMbaDessy/StudentPaging.aspx");



            //    IStudentService isss = (IStudentService)UnityFactory.Resolve<IStudentService>();
            //    Student stud = new Student();

            //    stud.StudentId = Convert.ToInt64(txtStudentId.Text);
            //    stud.StudentNo = txtStudentNo.Text;
            //    stud.
            //  TIDAK BISA MEMANGGIL CLASS Student
            //    for (int i = 0; i < gvScore.Rows.Count; i++)
            //    {

            //    }
        }


        protected void lb_Toolbar_Cancel_Click(object sender, EventArgs e)
        {
            RedirectUrl("~/Training/ExerciseMbaDessy/StudentPaging.aspx");
        }
        #endregion
        #region DATATABLE
        private DataTable createDataTableScore()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CourseCode");
            dt.Columns.Add("CourseName");
            dt.Columns.Add("Score");
            //dt.Columns.Add("RefCourseId");
            return dt;
        }
        #endregion
        #region METHOD
        private void setEditScreen()
        {
            IStudentService iss = (IStudentService)UnityFactory.Resolve<IStudentService>();
            Student student = iss.GetStudentById(studentId);
            txtStudentNo.Text = student.StudentNo;
            txtStudentName.Text = student.Name;
            txtAddress.Text = student.Address;
            txtBirthPlace.Text = student.BirthPlace;
            ucBirthDt.DateValue = student.BirthDt;
            txtStudentNo.Enabled = false;

        }
        #endregion
        //hahaha ga demen gua twice mah

        protected void gvGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Label lblGridCourseName = (Label)e.Row.FindControl("lblGridCourseName");
                //Label lblGridCourseCode = (Label)e.Row.FindControl("lblGridCourseCode");
                //Label lblScore = (Label)e.Row.FindControl("lblGridScore");
                IStudentService studentService = (IStudentService)UnityFactory.Resolve<IStudentService>();
                UCReference ucCourse = (UCReference)e.Row.FindControl("ucCourse");
                Label lblCourseCodeTemp = (Label)e.Row.FindControl("lblCourseCodeTemp");
                List<RefCourse> listStudentService = studentService.listOfCourse();
                ucCourse.BindingObject(listStudentService, "CourseName", "CourseCode", false, UCReference.AdditionalSelectionType.SelectOne);
                ucCourse.SelectedValue = lblCourseCodeTemp.Text;
                //lblGridCourseCode.Text = ucCourseCode.SelectedValue;
                //lblGridCourseName.Text = ucCourse.SelectedValue;
                //ucInputScore.se

            }
            //upRepeater.Update();
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {

            //DataTable dt = createDataTableScore();

            //for (int i = 0; i < gvGrid.Rows.Count; i++)
            //{
            //    Label lblCourseCode = (Label)gvGrid.Rows[i].FindControl("lblGridCourseCode");
            //    Label lblCourseName = (Label)gvGrid.Rows[i].FindControl("lblGridCourseName");
            //    Label lblScore = (Label)gvGrid.Rows[i].FindControl("lblGridScore");
            //    Label lblRefCourseId = (Label)gvGrid.Rows[i].FindControl("lblGridRefCourseId");

            //    DataRow drowTemp = dt.NewRow();
            //    drowTemp["CourseCode"] = ucCourseCode.SelectedValue;
            //    drowTemp[1] = ucCourse.SelectedValue;
            //    drowTemp[2] = lblScore.Text;
            //    drowTemp[3] = lblRefCourseId.Text;

            //    dt.Rows.Add(drowTemp);
            //}
            //DataRow drow1 = dt.NewRow();
            //drow1[0] = ucCourseCode.SelectedValue;
            //drow1[1] = ucCourse.SelectedValue;
            //drow1[2] = txtScore.Text;
            //drow1[3] = txtRefCourseId.Text;
            //dt.Rows.Add(drow1);

            ////rptName.DataSource = dt;
            ////rptName.DataBind();
            
            //gvGrid.DataSource = dt;
            //gvGrid.DataBind();

            //upGrid.Update();
            ////upRepeater.Update();


        }
        //#region TEMPDATA
        protected void lblAddToTemp_Click(object sender, EventArgs e)
        {
            DataTable dt = createDataTableScore();
            RefCourse rc = new RefCourse();

            if (txtStudentNo.Enabled == true)
            {
                for (int i = 0; i < gvScoreTemp.Rows.Count; i++)
                {
                    Label lblCourseCodeTemp = (Label)gvScoreTemp.Rows[i].FindControl("lblCourseCodeTemp");
                    Label lblCourseNameTemp = (Label)gvScoreTemp.Rows[i].FindControl("lblCourseNameTemp");
                    Label lblScoreTemp = (Label)gvScoreTemp.Rows[i].FindControl("lblScoreTemp");
                    //Label lblRefCourseIdTemp = (Label)gvScoreTemp.Rows[i].FindControl("lblRefCourseIdTemp");
                    UCReference ucCourse2 = (UCReference)gvScoreTemp.Rows[i].FindControl("ucCourse");
                    UCInputNumber ucInputScore = (UCInputNumber)gvScoreTemp.Rows[i].FindControl("ucInputScore");
                    DataRow drowTemp = dt.NewRow();
                    drowTemp[0] = ucCourse2.SelectedValue;
                    drowTemp[1] = ucCourse2.SelectedText;
                    drowTemp[2] = ucInputScore.Text;
                    //drowTemp[3] = lblRefCourseIdTemp.Text;
                    dt.Rows.Add(drowTemp);
                }
                //fan

                // dah fan
                //txtCourse.Text = ucCourse.SelectedValue; // ga work

                DataRow drow = dt.NewRow();
                drow[0] = ucCourse.SelectedValue;
                //drow[1] = txtCourseName.Text;
                drow[1] = ucCourse.SelectedText; 
                drow[2] = "0";
                //drow[3] = txtRefCourseId.Text;
                dt.Rows.Add(drow);
            }
            gvScoreTemp.DataSource = dt;
            gvScoreTemp.DataBind();
            upFormTemp.Update();
        }

        //protected void gvScore_RowCommand(object sender, GridViewCommandEventArgs e)
        //{

        //}

        protected void gvScoreTemp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = ((GridViewRow)(((Control)e.CommandSource).Parent.Parent)).RowIndex;
            if (e.CommandName == "DEL")
            {
                //List<RefCourse> listCourse = new List<RefCourse>();
                //List<RefCourse> listCourseTemp = new List<RefCourse>();

                //Label lblCourseDelete = (Label)gvScoreTemp.Rows[index].FindControl("lblCourseTemp");
                DataTable dt = createDataTableScore();
                for (int i = 0; i < gvScoreTemp.Rows.Count; i++)
                {
                    //RefCourse course = new RefCourse();
                    //StudentScore score = new StudentScore();

                    Label lblCourseName = (Label)gvScoreTemp.Rows[i].FindControl("lblCourseCodeTemp");
                    Label lblCourseCode = (Label)gvScoreTemp.Rows[i].FindControl("lblCourseNameTemp");
                    Label lblScore = (Label)gvScoreTemp.Rows[i].FindControl("lblScoreTemp");
                    //UCReference ucCourse2 = (UCReference)gvScoreTemp.Rows[i].FindControl("ucCourse");
                    //UCInputNumber ucScore = (UCInputNumber)gvScoreTemp.Rows[i].FindControl("ucScore");

                    //course.CourseName = ucCourse2.SelectedValue;
                    //course.CourseCode = ucCourse2.SelectedText;
                    //score.Score = Convert.ToDecimal(ucScore.Text); // ini bener fan?
                    //listCourse.Add(course);
                    if (i != index)
                    {
                        //course.CourseCode = ucCourse2.SelectedValue;
                        //course.CourseName = ucCourse2.SelectedText;
                        //score.Score = Convert.ToDecimal(ucScore.Text);
                        DataRow drowTemp = dt.NewRow();
                        drowTemp[0] = lblCourseName.Text;
                        drowTemp[1] = lblCourseCode.Text;
                        drowTemp[2] = lblScore.Text; // sama ini?
                        //drowTemp[3] = txtRefCourseId.Text;
                        
                        dt.Rows.Add(drowTemp);
                    }
                }
                gvScoreTemp.DataSource = dt;
                gvScoreTemp.DataBind();
                upFormTemp.Update();
            }
        }

        //for (int j = 0; j < gvScoreTemp.Rows.Count; j++)
        //{
        //    Label lblCourseNameTemp = (Label)gvScoreTemp.Rows[j].FindControl("lblCourseNameTemp");
        //    Label lblCourseCodeTemp = (Label)gvScoreTemp.Rows[j].FindControl("lblCourseCodeTemp");
        //    Label lblScoreTemp = (Label)gvScoreTemp.Rows[j].FindControl("lblScoreTemp");

        //    RefCourse course = new RefCourse();
        //    StudentScore score = new StudentScore();
        //    if (lblCourseNameDelete.Text != lblCourseNameTemp.Text)
        //    {
        //        course.CourseName = lblCourseNameTemp.Text;
        //        course.CourseCode = lblCourseCodeTemp.Text;
        //        score.Score = Convert.ToDecimal(lblScoreTemp.Text);
        //    }
        //    else
        //    {
        //        course.CourseName = lblCourseNameTemp.Text;
        //        course.CourseCode = lblCourseCodeTemp.Text;
        //        score.Score = Convert.ToDecimal(lblScoreTemp.Text);
        //        listCourse.Add(course);
        //    }

        //        }
        //        //gvScore.DataSource = listCourse;
        //        //gvScore.DataBind();
        //        gvScoreTemp.DataSource = listCourseTemp;
        //        gvScoreTemp.DataBind();
        //        upFormTemp.Update();
        //        //upFormTemp.Update();
        //    }
        //}
        //#endregion

    }
}