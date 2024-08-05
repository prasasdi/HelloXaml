using System.Windows.Controls;
using System.Timers;
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

        }
    }
}
