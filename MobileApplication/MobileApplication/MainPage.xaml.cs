using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MobileApplication {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        private async Task CheckNumber(object sender, EventArgs e) {
            int number = GetNumber(sender);
            string jsonResponse =
                await new HttpClient().GetStringAsync($"http://localhost:8505/api/checknumber?number={number}");
            var response = JsonConvert.DeserializeObject<GameResponse>(jsonResponse);
            BindingContext = response.Content;
        }

        private async Task ShowLogs(object sender, EventArgs e) {
            string jsonResponse =
                await new HttpClient().GetStringAsync("http://localhost:8505/api/showlogs");
            var response = JsonConvert.DeserializeObject<GameResponse>(jsonResponse);
            BindingContext = response.Content;
        }

        private int GetNumber(object sender) {
            if (!(sender is Entry entry)) {
                BindingContext = "Could not cast to Entry";
                throw new Exception("Could not cast to Entry");
            }

            bool parsedSuccessfully = int.TryParse(entry.Text, out int number);
            if (!parsedSuccessfully) {
                BindingContext = "Invalid number";
                throw new Exception("Invalid number");
            }

            return number;
        }
    }
}