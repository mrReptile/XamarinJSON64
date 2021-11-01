using JSON64.Model;
using JSON64.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JSON64.ViewModel
{
    public class RegisterViewModel : BaseViewModel<Usuario>
    {

        private Command _registerCommand;
        private string _jsonResult;
        private UsuarioService usuarioService;

        public RegisterViewModel(Usuario model = null) : base(model)
        {
            if(model == null)
            {
                Model = new Usuario();
            }
            usuarioService = new UsuarioService();
        }

        public string Username
        { 
            get => Model.Username;
            set {
                if (string.Equals(value, Model.Username)) return;
                Model.Username = value;
                OnPropertyChanged();
            } 
        }

        public string Password
        {
            get => Model.Password;
            set
            {
                if (string.Equals(value, Model.Password)) return;
                Model.Password = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => Model.Name;
            set
            {
                if (string.Equals(value, Model.Name)) return;
                Model.Name = value;
                OnPropertyChanged();
            }
        }

        public string AP1
        {
            get => Model.Ap1;
            set
            {
                if (string.Equals(value, Model.Ap1)) return;
                Model.Ap1 = value;
                OnPropertyChanged();
            }
        }

        public string AP2
        {
            get => Model.Ap2;
            set
            {
                if (string.Equals(value, Model.Ap2)) return;
                Model.Ap2 = value;
                OnPropertyChanged();
            }
        }

        public Command RegisterCommand { get => _registerCommand ?? 
                (_registerCommand = new Command(RegisterAction)); 
        }


        public string JsonResult
        {
            get => _jsonResult;
            set
            {
                if (string.Equals(_jsonResult, value)) return;
                _jsonResult = value;
                OnPropertyChanged();
            }
        }


        private async void RegisterAction()
        {
            Usuario newObject = EncriptorDecriptData(true);
            //JsonResult = ModelToJson(newObject);
            //JsonResult = usuarioService?.RegisterAsync(newObject).ToString();
            JsonResult = await usuarioService?.RegisterAsync(newObject);
        }
    }
}
