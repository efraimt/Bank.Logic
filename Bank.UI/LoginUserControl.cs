using Bank.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank.UI
{
    public partial class LoginUserControl : UserControl
    {
        
        public LoginUserControl()
        {
            InitializeComponent();
            
            UserLoginManager.UnsuccesfullLogin += loginFailureReason => {
                switch (loginFailureReason)
                {
                    case FailedLoginReasons.UserNameDoesNotExist:
                        MessageBox.Show("User name not found!");
                        break;
                    case FailedLoginReasons.WrongPassword:
                        MessageBox.Show("Wrong password");
                        break;
                    default:
                        break;
                }
            };

            //UserLoginManager.UnsuccesfullLogin += LoginFailure;

            UserLoginManager.SuccesfullLogin +=
                user => {
                    MessageBox.Show("Welcome " + user.UserName + "!");
                };

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            UserLoginManager.Login(txtUserName.Text, txtPassword.Text);
        }

        private void LoginUserControl_Load(object sender, EventArgs e)
        {

        }

        //void LoginFailure(FailedLoginReasons failedLoginReasons)
        //{
        //    MessageBox.Show(failedLoginReasons.ToString());
        //}

    }
}
