using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TicTacToe
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        bool turn = true; //true = x, false = o
        int turn_count = 0;

        MessageDialog msgDialog; //setting up the dialog message

        static String player1, player2; //Setting up the players

        //Set players
        public static void SetPlayers(String n1, String n2)
        {
            player1 = n1;
            player2 = n2;
        }

        public MainPage()
        {
            this.InitializeComponent();
            //Put players name accordingly
            xScore.Text = player1; 
            oScore.Text = player2;
        }

        //Command to put the symbol on a button
        private void PlaceSymbol(Object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Content = "X";
            }
            else
            {
                b.Content = "O";
            }

            turn = !turn; //Change symbol
            b.IsEnabled = false; //So that you cannot the symbol on the same button
            turn_count++;

            CheckForWinner();
        }

        //Command to check if X or O won, vertically, horizontally, or diagonally
        private void CheckForWinner()
        {
            bool there_is_winner = false;


            //Horizontal Checks
            if ((A1.Content == A2.Content) && (A2.Content == A3.Content) && (A3.Content == A4.Content) && (A4.Content == A5.Content) &&(!A1.IsEnabled))
            {

                there_is_winner = true;
            }
            else if ((B1.Content == B2.Content) && (B2.Content == B3.Content) && (B3.Content == B4.Content) && (B4.Content == B5.Content) &&(!B1.IsEnabled)) {

                there_is_winner = true;
            }
            else if ((C1.Content == C2.Content) && (C2.Content == C3.Content) && (C3.Content == C4.Content) && (C4.Content == C5.Content) && (!C1.IsEnabled)) {

                there_is_winner = true;
            }
            else if ((D1.Content == D2.Content) && (D2.Content == D3.Content) && (D3.Content == D4.Content) && (D4.Content == D5.Content) && (!D1.IsEnabled)) {

                there_is_winner = true;
            }
            else if ((E1.Content == E2.Content) && (E2.Content == E3.Content) && (E3.Content == E4.Content) && (E4.Content == E5.Content) && (!E1.IsEnabled)) { 
            
                there_is_winner = true;
            }


            //Vertical Checks
            if ((A1.Content == B1.Content) && (B1.Content == C1.Content) && (C1.Content == D1.Content) && (D1.Content == E1.Content) && (!A1.IsEnabled))
            {

                there_is_winner = true;
            }
            else if ((A2.Content == B2.Content) && (B2.Content == C2.Content) && (C2.Content == D2.Content) && (D2.Content == E2.Content) && (!A2.IsEnabled))
            {

                there_is_winner = true;
            }
            else if ((A3.Content == B3.Content) && (B3.Content == C3.Content) && (C3.Content == D3.Content) && (D3.Content == E3.Content) && (!A3.IsEnabled))
            {

                there_is_winner = true;
            }
            else if ((A4.Content == B4.Content) && (B4.Content == C4.Content) && (C4.Content == D4.Content) && (D4.Content == E4.Content) && (!A4.IsEnabled))
            {

                there_is_winner = true;
            }
            else if ((A5.Content == B5.Content) && (B5.Content == C5.Content) && (C5.Content == D5.Content) && (D5.Content == E5.Content) && (!A5.IsEnabled))
            {

                there_is_winner = true;
            }

            //Diagonal Checks
            if ((A1.Content == B2.Content) && (B2.Content == C3.Content) && (C3.Content == D4.Content) && (D4.Content == E5.Content) && (!A1.IsEnabled))
            {

                there_is_winner = true;
            }
            else if ((E1.Content == D2.Content) && (D2.Content == C3.Content) && (C3.Content == B4.Content) && (B4.Content == A5.Content) && (!E1.IsEnabled))
            {

                there_is_winner = true;
            }


            if (there_is_winner)
            {
                disableButtons();
                String winner = "";
                if (turn)
                {
                    winner = player2;
                    o_count.Text = (Int32.Parse(o_count.Text) + 1).ToString(); //Counter
                    turn_count = 0;
                }
                else
                {
                    winner = player1;
                    x_count.Text = (Int32.Parse(x_count.Text) + 1).ToString(); // Counter
                    turn_count = 0;
                }

                //Display if X or O won
                msgDialog = new MessageDialog(winner + " wins!!", "Congrats!");
                msgDialog.ShowAsync();

                //Show continue or exit options
                msgDialog.Commands.Add(new UICommand("Play again", new UICommandInvokedHandler(this.CommandInvokedHandler1)));
                msgDialog.Commands.Add(new UICommand("Close", new UICommandInvokedHandler(this.CommandInvokedHandler2)));

                //Reseting first turn to "X"
                turn = true;

            }
            else
            {
                //if there is a draw
                if(turn_count == 25)
                {
                    
                    msgDialog = new MessageDialog("It's a draw!!", "So sad :(");
                    msgDialog.ShowAsync();

                    msgDialog.Commands.Add(new UICommand("Play again", new UICommandInvokedHandler(this.CommandInvokedHandler1)));
                    msgDialog.Commands.Add(new UICommand("Close", new UICommandInvokedHandler(this.CommandInvokedHandler2)));

                    //Counter
                    draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();

                    //Reseting first turn to "X"
                    turn = true;

                    //reset count
                    turn_count = 0;
                }
            }


        }//end check for winner

        //Restore Screen
        private void CommandInvokedHandler1(IUICommand command)
        {
            foreach (Button button in GameBoard.Children)
            {
                try //try and catch so it doesn't compkaint about extra buttons
                {
                    Button b = (Button)button;
                    b.IsEnabled = true;
                    b.Content = "";
                    turn_count = 0;
                }
                catch { }
            }
        }

        private void CommandInvokedHandler2(IUICommand command)
        {
            CoreApplication.Exit();
        }

        //Disable all buttons on the board
        private void disableButtons()
        {
            try
            {
                foreach (Button button in GameGrid.Children)
                {
                    Button b = (Button)button;
                    b.IsEnabled = false;
                }
            }
            catch { }

        }

        //Hover a button to know which turn is it
        private void ButtonEnter(object sender, PointerRoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b.IsEnabled)
            {
                if (turn)
                {
                    b.Content = "X";
                }
                else
                {
                    b.Content = "O";
                }
            }
            
        }

        //Leave a button
        private void ButtonExit(object sender, PointerRoutedEventArgs e)
        {
            Button b = (Button)sender;

            if (b.IsEnabled)
            {
                b.Content = "";
            }

        }

        //Command to set all the score to 0
        private void RestorePoints(object sender, RoutedEventArgs e)
        {
            o_count.Text = "0";
            x_count.Text = "0";
            draw_count.Text = "0";
        }
    }
}
