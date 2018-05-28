using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Admins
{
    public partial class Config : System.Web.UI.Page
    {
        static string Id = "";
        static bool Insert = false;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dt = ConfigService.Config_GetByAll();
                if (dt.Rows.Count > 0)
                {
                    Insert = false;
                    Id = dt.Rows[0]["Id"].ToString();
                    txtMail_Smtp.Text = dt.Rows[0]["Mail_Smtp"].ToString();
                    txtMail_Port.Text = dt.Rows[0]["Mail_Port"].ToString();
                    txtMail_Info.Text = dt.Rows[0]["Mail_Info"].ToString();
                    txtMail_Password.Text = dt.Rows[0]["Mail_Password"].ToString();
                    txtMail_Noreply.Text = dt.Rows[0]["Mail_Noreply"].ToString();
                    fckContent.Value = dt.Rows[0]["Contact"].ToString();
                    fckCopyright.Value = dt.Rows[0]["Copyright"].ToString();
                    txtTitle.Text = dt.Rows[0]["Title"].ToString();
                    txtDescription.Text = dt.Rows[0]["Description"].ToString();
                    txtKeyword.Text = dt.Rows[0]["Keyword"].ToString();
                }
                else
                {
                    Insert = true;
                    ControlClass.ResetControlValues(this);
                }
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Data.Config obj = new Data.Config();
                obj.Id = Id;
                obj.Mail_Smtp = txtMail_Smtp.Text;
                obj.Mail_Info = txtMail_Info.Text;
                obj.Mail_Port = txtMail_Port.Text;
                obj.Mail_Password = txtMail_Password.Text;
                obj.Mail_Noreply = txtMail_Noreply.Text;
                obj.Contact = fckContent.Value;
                obj.Copyright = fckCopyright.Value;
                obj.Title = txtTitle.Text;
                obj.Keyword = txtDescription.Text;
                obj.Description = txtKeyword.Text;
                if (Insert == true)
                {
                    ConfigService.Config_Insert(obj);
                }
                else
                {
                    ConfigService.Config_Update(obj);
                }
            }
        }
    }
}