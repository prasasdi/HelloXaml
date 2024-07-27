using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelloXaml.UIs
{
    /// <summary>
    /// Interaction logic for UserControlView.xaml
    /// </summary>
    public partial class UserControlView : UserControl
    {
        UserControlViewModel a;
        public UserControlView()
        {
            InitializeComponent();
            a = (UserControlViewModel)this.DataContext;
            a.Messages.Add(new MessageModel()
            {
                Id = Guid.NewGuid(),
                Message = "Lewat ViewModel Lokator",
                Epoch = "B"
            });
        }
    }
}
