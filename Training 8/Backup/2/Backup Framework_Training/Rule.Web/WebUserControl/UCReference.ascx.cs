using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Reflection;
using System.Collections;
using Rule.Web.WebUserControl;

namespace Rule.Web.WebUserControl
{
    public partial class UCReference : UserControlBase
    {
        #region "ENUM"
        public enum AdditionalSelectionType
        {
            All,
            None,
            Blank,
            SelectOne,
            SelectNone
        }
        #endregion

        #region DELEGATE EVENT HANDLER
        public delegate void SelectedIndexChangedEventHandler(object sender, EventArgs e);
        #endregion

        #region DELEGATE PROPERTIES
        public SelectedIndexChangedEventHandler SelectedIndexChanged;
        #endregion

        #region "PROPERTIES"
        public string SelectedValue
        {
            get { return ltlReferenceVal.Text == "" ? ddlReference.SelectedItem.Value : ltlReferenceVal.Text; }
            set
            {
                try
                {
                    ddlReference.SelectedValue = value;
                }
                catch { }
            }
        }

        public string SelectedText
        {
            get { return ltlReference.Text == "" ? ddlReference.SelectedItem.Text : ltlReference.Text; }
        }

        public int SelectedIndex
        {
            set { ddlReference.SelectedIndex = value; }
            get { return ddlReference.SelectedIndex; }
        }

        public bool AutoPostBack
        {
            get { return ddlReference.AutoPostBack; }
            set { ddlReference.AutoPostBack = value; }
        }

        public bool IsRequired
        {
            get { return rfvDdlReference.Enabled; }
            set
            {
                if (value)
                {
                    if (IsDdlVisible)
                        setEnabledVisible(rfvDdlReference, true);
                }
                else
                {
                    if (IsDdlVisible)
                        setEnabledVisible(rfvDdlReference, false);
                }
            }
        }

        public bool Enabled
        {
            get { return ddlReference.Enabled; }
            set { ddlReference.Enabled = value; }
        }

        public bool IsDdlVisible
        {
            get { return ddlReference.Visible; }
            set { ddlReference.Visible = value; }
        }

        public string ValidationGroup
        {
            get { return rfvDdlReference.ValidationGroup; }
            set { rfvDdlReference.ValidationGroup = value; }
        }
        #endregion

        #region "PAGE LOAD"
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        #endregion

        #region EVENT
        protected void ddlReference_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
                SelectedIndexChanged(sender, e);
        }
        #endregion

        #region "METHOD"
        public void BindingObject(IList listOfReference, string text, string value, bool isRequired = false, AdditionalSelectionType addSelectionType = AdditionalSelectionType.None, string defaultValue = "")
        {
            if ((addSelectionType == AdditionalSelectionType.All || addSelectionType == AdditionalSelectionType.SelectNone || addSelectionType == AdditionalSelectionType.Blank) && !isRequired)
            {
                ddlReference.DataSource = listOfReference;
                ddlReference.DataTextField = text;
                ddlReference.DataValueField = value;
                ddlReference.DataBind();

                ddlReference.Visible = true;
                ltlReference.Visible = false;
                ltlReferenceVal.Text = string.Empty;

                if (addSelectionType == AdditionalSelectionType.All)
                    ddlReference.Items.Insert(0, new ListItem("All", "All"));
                else if (addSelectionType == AdditionalSelectionType.Blank)
                    ddlReference.Items.Insert(0, new ListItem("", ""));
                else if (addSelectionType == AdditionalSelectionType.SelectNone)
                    ddlReference.Items.Insert(0, new ListItem("Select None", ""));

                if (isRequired)
                    setEnabledVisible(rfvDdlReference, true);
                else
                    setEnabledVisible(rfvDdlReference, false);

                if (defaultValue != "" && ddlReference.Items.FindByValue(defaultValue) != null)
                {
                    ddlReference.SelectedValue = defaultValue;
                }
            }
            else if (listOfReference.Count > 1)
            {
                ddlReference.DataSource = listOfReference;
                ddlReference.DataTextField = text;
                ddlReference.DataValueField = value;
                ddlReference.DataBind();

                ddlReference.Visible = true;
                ltlReference.Visible = false;
                //ltlReferenceVal.Visible = false;
                ltlReferenceVal.Text = string.Empty;

                if (addSelectionType == AdditionalSelectionType.SelectOne || isRequired)
                {
                    ddlReference.Items.Insert(0, new ListItem("Select One", ""));
                    if (addSelectionType == AdditionalSelectionType.SelectNone)
                    {
                        //ddlReference.Items.Insert(0, new ListItem("Select One", ""));
                        ddlReference.Items.Insert(1, new ListItem("None", "None"));
                    }
                }
                else if (addSelectionType == AdditionalSelectionType.All)
                    ddlReference.Items.Insert(0, new ListItem("All", "All"));
                else if (addSelectionType == AdditionalSelectionType.Blank)
                    ddlReference.Items.Insert(0, new ListItem("", ""));
                else if (addSelectionType == AdditionalSelectionType.SelectNone)
                    ddlReference.Items.Insert(0, new ListItem("Select None", "SelectNone"));

                if (isRequired)
                    setEnabledVisible(rfvDdlReference, true);
                else
                    setEnabledVisible(rfvDdlReference, false);

                if (defaultValue != "" && ddlReference.Items.FindByValue(defaultValue) != null)
                {
                    ddlReference.SelectedValue = defaultValue;
                }
            }
            else if (listOfReference.Count == 1)
            {
                if (addSelectionType == AdditionalSelectionType.Blank)
                {
                    ddlReference.DataSource = listOfReference;
                    ddlReference.DataTextField = text;
                    ddlReference.DataValueField = value;
                    ddlReference.DataBind();

                    ddlReference.Items.Insert(0, new ListItem("", ""));
                    ddlReference.Visible = true;
                    ltlReference.Visible = false;
                    //ltlReferenceVal.Visible = false;
                    ltlReferenceVal.Text = string.Empty;

                    if (isRequired)
                        setEnabledVisible(rfvDdlReference, true);
                    else
                        setEnabledVisible(rfvDdlReference, false);

                    if (defaultValue != "" && ddlReference.Items.FindByValue(defaultValue) != null)
                    {
                        ddlReference.SelectedValue = defaultValue;
                    }
                }
                else
                {
                    DataTable dTable = convertToDataTable(listOfReference);
                    DataRow dRow = dTable.Rows[0];

                    ltlReference.Text = dRow[text].ToString();
                    ltlReferenceVal.Text = dRow[value].ToString();
                    ddlReference.SelectedValue = null;
                    ddlReference.DataSource = null;
                    ddlReference.DataBind();
                    ddlReference.Visible = false;
                    ltlReference.Visible = true;
                    setEnabledVisible(rfvDdlReference, false);
                }
            }
            else if (listOfReference.Count == 0)
            {
                //ltlReference.Text = "-";
                //ltlReferenceVal.Text = "";

                ddlReference.DataSource = listOfReference;
                ddlReference.DataTextField = text;
                ddlReference.DataValueField = value;
                ddlReference.DataBind();
                ddlReference.Visible = true;

                ddlReference.Items.Insert(0, new ListItem("Select One", ""));
                ddlReference.Visible = true;
                ltlReference.Visible = false;
                //ltlReferenceVal.Visible = false;
                ltlReferenceVal.Text = string.Empty;

                setEnabledVisible(rfvDdlReference, true);

                rfvDdlReference.Enabled = true;

            }
        }

        public void ResetDropDownList()
        {
            if (ddlReference.SelectedIndex == -1)
                ddlReference.SelectedIndex = -1;
            else
                ddlReference.SelectedIndex = 0;
        }

        private DataTable convertToDataTable(IList items)
        {
            Type type = items.GetType().GetGenericArguments()[0];

            var tb = new DataTable(type.Name);

            PropertyInfo[] props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = getCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }

            foreach (var item in items)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }

        private static bool isNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        private static Type getCoreType(Type t)
        {
            if (t != null && isNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }

        private void setEnabledVisible(WebControl obj, bool avaiability)
        {
            obj.Visible = avaiability;
            obj.Enabled = avaiability;
            ltl_Form_Req_ddlReference.Visible = avaiability;
        }

        public void Clear()
        {
            ddlReference.Items.Clear();
            ltlReference.Text = string.Empty;
            ltlReferenceVal.Text = string.Empty;
        }

        #endregion
    }
}