using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async Task<bool> Validarformulario()

        {

            if (String.IsNullOrWhiteSpace(txtNombre.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo del nombre es obligatorio.", "OK");
                return false;
            }
            //Valida que solo se integren letras
            else if (!txtNombre.Text.ToCharArray().All(Char.IsLetter))
            {
                await this.DisplayAlert("Advertencia", "Tu información contiene números, favor corregir.", "OK");
                return false;
            }
            else
            {
                string caractEspecial = @"/*-+.!@#$%^&*(+_)(|\?><";
                bool resultado = Regex.IsMatch(txtNombre.Text, caractEspecial, RegexOptions.IgnoreCase);
                if (!resultado)
                {
                    await this.DisplayAlert("Advertencia", "No se aceptan caracteres especiales, intente de nuevo.", "OK");
                }

            }
            bool isEmail = Regex.IsMatch(txtEmail.Text, @"#$%^&*()_+<>?/|\;'][{}", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
                await this.DisplayAlert("Advertencia", "el formato de correo electronico es incorrecto, reviselo e intente de nuevo.", "OK");
                return false;
            }
            else if (txtTelefono.Text.Length != 10)
            {
                await this.DisplayAlert("Advertencia", "Faltan Dijitos, favor de ingresar su numero a 10 digitos.", "OK");
                return false;
            }
            else
            {
                if (txtTelefono.Text.ToCharArray().All(Char.IsDigit))
                {
                    await this.DisplayAlert("Advertencia", "El formato del celular es incorrecto, solo se aceptan numeros.", "OK");
                    return false;
                }
            }

            if (String.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo del celular s obligatorio.", "OK");
                return false;
            }

            async void Continuar(object sender, EventArgs e)
            {
                if (await Validarformulario())
                {
                    await DisplayAlert("Exito", "Todos tus campos cumplieron las validaciones.", "OK");
                }
            }
        }

    }
}
