using System;
using Xamarin.Forms;

namespace MobileApplication {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        private void IncrementNumber(object sender, EventArgs e) {
            if (!(sender is Entry entry)) {
                BindingContext = "Could not cast to Entry";
                return;
            }
            bool parsedSuccessfully = int.TryParse(entry.Text, out int number);
            if (!parsedSuccessfully) {
                BindingContext = "Could not parse to Int";
                return;
            }
            number++;
            BindingContext = number.ToString();
        }
    }
}