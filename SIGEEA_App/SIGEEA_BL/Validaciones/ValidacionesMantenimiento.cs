using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace SIGEEA_BL.Validaciones
{
    /// <summary>
    /// Esta clase se encarga de validar la información que ingresa el usuario,
    /// esto con el fin de controlar los tipos de datos que vayan a ser ingre-
    /// sados a la BD. Para llevar a cabo estas validaciones se deben conside-
    /// rar todas las posibles variaciones o tipos de datos que se admiten. 
    /// Cada TextBox de las distintas pantallas poseen una propiedad por defec-
    /// to, la misma será utilizada como "etiqueta" para determinar el tipo de 
    /// validación a la cual deberá ser sometida. A continuación se mostrará el
    /// diccionario de los valores posibles que puede poseer un TextBox:
    ///     1.  0 = Cadena de caracteres que posean solamente letras (CAMPO REQUERIDO)
    ///     2.  1 = Cadena de caracteres que posean solamente número (CAMPO REQUERIDO)
    ///     3.  2 = Cadena que cumpla con formato de email (CAMPO REQUERIDO)
    ///     4.  3 = Cadena de caracteres que posean solamente letras (CAMPO OPCIONAL)
    ///     5.  4 = Cadena de caracteres que posean solamente números (CAMPO OPCIONAL)
    ///     6.  5 = Cadena de caracteres que cumpla con formato de email (CAMPO OPCIONAL)
    /// </summary>
    public class ValidacionesMantenimiento
    {
        public bool Validar(string pValor, int pTag)
        {
            switch (pTag)
            {
                case 0:
                    if (Regex.IsMatch(pValor, @"^[A-Za-zÑñáéíóúÁÉÍÓÚ]+$") == true) return true;
                    else return false;
                case 1:
                    if (Regex.IsMatch(pValor, @"^[0-9]+$") == true) return true;
                    else return false;
                case 2:
                    if (VerificaCorreo(pValor) == true) return true;
                    else return false;
                case 3:
                    if (Regex.IsMatch(pValor, @"^[A-Za-zÑñáéíóúÁÉÍÓÚ]+$") == true || pValor.Length >= 0) return true;
                    else return false;
                case 4:
                    if (Regex.IsMatch(pValor, @"^[0-9]+$") == true || pValor.Length >= 0) return true;
                    else return false;
                case 5:
                    if (VerificaCorreo(pValor) == true || pValor.Length >= 0) return true;
                    else return false;
                default:
                    return true;
            }
        }


        #region Correo
        bool invalido = false;

        private bool VerificaCorreo(string pCorreo)
        {
            invalido = false;
            if (String.IsNullOrEmpty(pCorreo))
                return false;

            // La clase IdnMapping se encarga de convertir el nombre del dominio en Unicode.
            try
            {
                pCorreo = Regex.Replace(pCorreo, @"(@)(.+)$", this.GeneraDominio,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalido)
                return false;

            // Retorna true si el formato es válido. 
            try
            {
                return Regex.IsMatch(pCorreo,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private string GeneraDominio(Match pValor)
        {
            IdnMapping idn = new IdnMapping(); // IdnMapping soporta el uso de caracteres no ASCII para los nombres de dominio de Internet

            string nombreDominio = pValor.Groups[2].Value;
            try
            {
                nombreDominio = idn.GetAscii(nombreDominio);
            }
            catch (ArgumentException)
            {
                invalido = true;
            }
            return pValor.Groups[1].Value + nombreDominio;
        }
        #endregion
    }
}
