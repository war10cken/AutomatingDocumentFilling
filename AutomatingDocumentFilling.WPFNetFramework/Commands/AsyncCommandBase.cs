﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomatingDocumentFilling.WPFNetFramework.Commands
{
    public abstract class AsyncCommandBase : ICommand
    {
        public bool IsExecuting { get; set; }

        public abstract Task ExecuteAsync(object parameter);

        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return !IsExecuting;
        }

        public async void Execute(object parameter)
        {
            IsExecuting = true;

            await ExecuteAsync(parameter);

            IsExecuting = false;
        }
    }
}