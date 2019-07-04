using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FuelConsumption2.Views.Controls
{
    public partial class CustomEntry : ContentView
    {
        public CustomEntry()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty TextValueProperty = BindableProperty.Create(
            propertyName: nameof(TextValue),
            returnType: typeof(string),
            declaringType: typeof(CustomEntry),
            defaultValue: string.Empty,
            propertyChanged: (bindable, oldValue, newValue) => ((CustomEntry)bindable).MainEntry.Text = (string)newValue,
            defaultBindingMode: BindingMode.TwoWay
        );

        public string TextValue
        {
            get { return (string)GetValue(TextValueProperty); }
            set
            {
                SetValue(TextValueProperty, value);
            }
        }

        void Handle_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == Entry.TextProperty.PropertyName)
                TextValue = ((Entry)sender).Text;
        }
    }
}
