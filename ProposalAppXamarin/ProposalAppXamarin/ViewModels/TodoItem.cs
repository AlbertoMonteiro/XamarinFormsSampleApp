using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProposalAppXamarin.ViewModels
{
    public class TodoItem : BaseViewModel
    {
        private bool _isDone;
        private string _text;

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        public bool IsDone
        {
            get => _isDone;
            set => SetProperty(ref _isDone, value);
        }
    }
}