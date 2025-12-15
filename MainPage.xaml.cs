


namespace Rock_Paper_Scissor
{
    public partial class MainPage : ContentPage
    {
        private readonly string[] moves = { "🗿 Камень", "📄 Бумага", "✂️ Ножницы" };
        private Random random = new Random();
        private int playerWins = 0;
        private int aiWins = 0;
        private int draws = 0;



        public MainPage()
        {
            InitializeComponent();
        }

        private void OnBattleButtonClicked(object sender, EventArgs e)
        {

            string playerMove = GetPlayerMove();

            string aiMove = GetAIMove();


            bool result = DetermineWinner(playerMove, aiMove);


            ShowResultAlert(result);
        }
        private string GetPlayerMove()
        {

            var picker = this.FindByName<Picker>("PlayerPicker");

            if (picker != null && picker.SelectedIndex >= 0)
            {
                return picker.SelectedItem.ToString();
            }
            return moves[random.Next(0, moves.Length)];


        }
        private string GetAIMove()
        {
            int randomIndex = random.Next(0, moves.Length);
            return moves[randomIndex];
        }
        private bool DetermineWinner(string playerMove, string aiMove)
        {
            string playerClean = playerMove.Substring(2).Trim();
            string aiClean = aiMove.Substring(2).Trim();

            if (playerClean == aiClean)
            {
                draws++;
                return true;
            }

            bool playerWinsRound =
                (playerClean == "Камень" && aiClean == "Ножницы") ||
                (playerClean == "Бумага" && aiClean == "Камень") ||
                (playerClean == "Ножницы" && aiClean == "Бумага");

            if (playerWinsRound)
            {
                playerWins++;
                return true;
            }
            else
            {
                aiWins++;
                return false;
            }
        }
        private void ShowResultAlert(bool isPlayerWin)
        {
            string title;
            string message;
            string buttonText = "OK";

            if (isPlayerWin)
            {
                title = "🎉 ПОБЕДА! 🎉";
                message = "Вы победили в этой битве!\n\n" +
                         $"Ваши победы: {playerWins}\n" +
                         $"Победы ИИ: {aiWins}\n" +
                         $"Ничьи: {draws}\n\n" +
                         "Вы сохранили своё сознание!";
            }
            else
            {
                title = "🤖 ПОРАЖЕНИЕ 🤖";
                message = "ИИ победил вас!\n\n" +
                         $"Ваши победы: {playerWins}\n" +
                         $"Победы ИИ: {aiWins}\n" +
                         $"Ничьи: {draws}\n\n" +
                         "Ваше сознание частично захвачено искусственным интеллектом!";
            }

            DisplayAlert(title, message, buttonText);

            if (playerWins > 0 && aiWins > 0 && playerWins == aiWins)
            {
                DisplayAlert("⚖️ РАВНОВЕСИЕ ⚖️",
                   "Силы равны! Битва продолжается...",
                   "Продолжить");
            }
        }
     

        private string GetImageNameFromMove(string move)
        {
            string cleanMove = move.Substring(2).Trim().ToLower();

            return cleanMove switch
            {
                "камень" => "rock.png",
                "бумага" => "paper.png",
                "ножницы" => "scissors.png"

            };


    }
    }
}
