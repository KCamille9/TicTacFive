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

        MessageDialog msgDialog;


        public MainPage()
        {
            this.InitializeComponent();
        }

        private void button_click(Object sender, RoutedEventArgs e)
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

            turn = !turn;
            b.IsEnabled = false; //Para que no puedas cambiar el simbolo en el mismo boton
            turn_count++;

            checkForWinner();
        }

        private void checkForWinner()
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
                    winner = "O";
                }
                else
                {
                    winner = "X";
                }

                //Display if X or O won
                msgDialog = new MessageDialog(winner + " wins!!", "Congrats!");
                msgDialog.ShowAsync();

                //Show continue or exit options
                msgDialog.Commands.Add(new UICommand("Play again", new UICommandInvokedHandler(this.CommandInvokedHandler1)));
                msgDialog.Commands.Add(new UICommand("Close", new UICommandInvokedHandler(this.CommandInvokedHandler2)));
            }
            else
            {
                if(turn_count == 25)
                {
                    
                    msgDialog = new MessageDialog("It's a draw!!", "So sad :(");
                    msgDialog.ShowAsync();

                    msgDialog.Commands.Add(new UICommand("Play again", new UICommandInvokedHandler(this.CommandInvokedHandler1)));
                    msgDialog.Commands.Add(new UICommand("Close", new UICommandInvokedHandler(this.CommandInvokedHandler2)));

                }
            }


        }//end check for winner

        //Restore Screen
        private void CommandInvokedHandler1(IUICommand command)
        {
            foreach (Button button in GameGrid.Children)
            {
                Button b = (Button)button;
                b.IsEnabled = true;
                b.Content = "";
                turn_count = 0;
            }
        }

        private void CommandInvokedHandler2(IUICommand command)
        {
            CoreApplication.Exit();
        }

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
    }
}
