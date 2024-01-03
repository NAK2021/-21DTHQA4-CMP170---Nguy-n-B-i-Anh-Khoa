using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercise2
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            WebService webService = new WebService();
            int a = Convert.ToInt32(Num1.Text);
            int b = Convert.ToInt32(Num2.Text);
            Label1.Text = "\nAdd: " + webService.Add(a, b).ToString() + "                    ";
            Label2.Text = "\nSubtract: " + webService.Subtract(a, b).ToString() + "                    ";
            Label3.Text = "\nMultiply: " + webService.Multiply(a, b).ToString() + "                    ";
            Label4.Text = "\nDivide: " + webService.Divide(a, b).ToString() + "                    ";
        }
    }
}