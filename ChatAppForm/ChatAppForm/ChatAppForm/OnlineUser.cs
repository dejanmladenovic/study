using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatAppForm
{
    public partial class OnlineUser : UserControl
    {
        public OnlineUser(String userName, string pictureURL)
        {
            this.lblUserName.Text = userName;
            this.userPicture.Load(pictureURL);
        }

        public OnlineUser()
        {

        }
    }
}
