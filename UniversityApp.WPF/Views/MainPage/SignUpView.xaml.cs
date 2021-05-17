using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace UniversityApp.Views.MainPage
{
    public partial class SignUpView : UserControl
    {
        public SignUpView()
        {
            InitializeComponent();
        }


        private void UIElement_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = e.Text != " " && new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}