﻿using BLL;
using System;
using System.Windows;

namespace Library_Management
{
    /// <summary>
    /// Interaction logic for AdminAddBook.xaml
    /// </summary>
    public partial class AdminAddBook : Window
    {
        public AdminAddBook()
        {
            InitializeComponent();
        }
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (tbBName.Text != string.Empty && tbBAuthor.Text != string.Empty && tbBISBN.Text != string.Empty && tbBPrice.Text != string.Empty &&
                tbBCopy.Text != string.Empty
                )
            {
                try
                {
                    BookBL bookBL = new BookBL();
                    string isDone = bookBL.AddBookBL(tbBName.Text, tbBAuthor.Text, tbBISBN.Text, double.Parse(tbBPrice.Text), int.Parse(tbBCopy.Text));
                    if (isDone == "true")
                    {
                        MessageBox.Show("Book added successfuly..");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(isDone + "Try again..");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Book price or Book copy!!!,\nThey should not be a string, Try again..");
                }
                catch (Exception)
                {
                    MessageBox.Show("Some unknown exception is occured!!!, Try again..");
                }
            }
            else
            {
                MessageBox.Show("Enter the fields properly!!!, Every field is required..");
            }
        }
    }
}
