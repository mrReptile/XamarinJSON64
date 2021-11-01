using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Text.Json;

namespace JSON64.ViewModel
{
    public class BaseViewModel<T> : INotifyPropertyChanged

    {

        public T Model { get; set; }

        public BaseViewModel(T model)
        {
            Model = model;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public T EncriptorDecriptData(bool isEncript = true)
        {
            Type myType = Model.GetType();
            var newModel = Activator.CreateInstance(myType);

            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach(PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(Model);

                if (propValue != null && propValue.GetType() == typeof(string))
                {
                    if (isEncript)
                        prop.SetValue(newModel, Helper.Bae64Encryptor.Encriptar(propValue.ToString()));
                    
                    else
                        prop.SetValue(newModel, Helper.Bae64Encryptor.Decriptar(propValue.ToString()));
                }
            }

            return (T)newModel;
        }

        public string ModelToJson(T model) {
            return JsonSerializer.Serialize(model);
        }
    }
}
