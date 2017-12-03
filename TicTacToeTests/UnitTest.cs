
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TicTacToe
{
    [TestClass]
    public class TicTacToeTests
    {
        [TestMethod]
        public void A_User_Needs_To_Play_With_Zero_Players()
        {
            String promptUser = "With how many user do you want play?"; //Use checkmarks on this one

            zeroPlayerskChecked = true;
            String zeroPlayers = "You selected Zero players, the computer will compete agains another computer";
            String userSelection = zeroPlayers;
            Assert.AreEqual("You selected Zero players, the computer will compete agains another computer", userSelection);
        }

        [TestMethod]
        public void A_User_Needs_To_Play_With_One_Players()
        {

            String promptUser = "With how many user do you want play?"; //Use checkmarks on this one

            onePlayerChecked = true;
            String zeroPlayers = "You selected One player, you will comptete against the computer";
            String userSelection = onePlayers;
            Assert.AreEqual("You selected One player, you will comptete against the computer", userSelection);
        }

        [TestMethod]
        public void A_User_Needs_To_Play_With_Two_Players()
        {
            String promptUser = "With how many user do you want play?"; //Use checkmarks on this one

            twoPayersChecked = true;
            String twoPlayers = "You selected Two players, you will comptete against other plauer";
            String userSelection = twoPlayers;
            Assert.AreEqual("You selected Two players, you will comptete against other player", userSelection);
        }

        [TestMethod]
        public void A_User_Needs_To_Choose_X()
        {

            User.Symbol = symbol;
            User.Symbol = "X";
            Assert.AreEqual("X", User.Symbol);
        }

        [TestMethod]
        public void A_User_Needs_To_Choose_O()
        { 
            User.Symbol = symbol;
            User.Symbol = "O";
            Assert.AreEqual("O", User.Symbol);
        }

        [TestMethod]
        public void A_User_Needs_To_Place_X()
        {
            User.Symbol = "X";
            String userPosition = Button b.Content;
            String userPosition = A1;
            Assert.Equals("X", userPosition);
        }

        [TestMethod]
        public void A_User_Needs_To_Place_O()
        {
            User.Symbol = "O";
            String userPosition = Button b.Content;
            String userPosition = A1;
            Assert.Equals("O", userPosition);
        }

        [TestMethod]
        public void A_User_Needs_To_Be_Told_When_A_Win_Happens()
        {
            there_is_winner = true;

            Message msgDialog = new MessageDialog(winner + " wins!!", "Congrats!");
            msgDialog.ShowAsync();
        }

        [TestMethod]
        public void A_User_Needs_To_Be_Told_When_A_Loss_Happens()
        {

            there_is_winner = true;

            Message msgDialog = new MessageDialog(winner + " wins!!\n" + loser + "lost", "Congrats!");
            msgDialog.ShowAsync();
        }

        [TestMethod]
        public void A_User_Needs_To_Told_When_A_Draw_Happens()
        {
            there_is_winner = false;

            Message msgDialog = new MessageDialog("It's a draw", "Sad!");
            msgDialog.ShowAsync();
        }

        [TestMethod]
        public void A_User_Needs_To_Queried_If_They_Wish_To_Pay_Again()
        {
            MessageDialog msgDialog = new MessageDialog(winner + " wins!!", "Congrats!");
            msgDialog.ShowAsync();
            msgDialog.Commands.Add(new UICommand("Play again", new UICommandInvokedHandler(this.CommandInvokedHandler1)));
            msgDialog.Commands.Add(new UICommand("Close", new UICommandInvokedHandler(this.CommandInvokedHandler2)));
        }

        [TestMethod]
        public void A_User_Needs_To_Enter_Their_Name_Before_Game_Starts()
        {
        }

        [TestMethod]
        public void A_User_Needs_To_See_A_Score_Chart()
        {
        }

       

    }
}
