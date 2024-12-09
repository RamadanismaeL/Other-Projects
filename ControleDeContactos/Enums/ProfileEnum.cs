using System.ComponentModel;

namespace ControleDeContactos.Enums
{
/*
*@author Ramadan ismaeL
*/
    public enum ProfileEnum
    {
        [Description("Administrator User")]
        Admin = 1,
        [Description("Pattern User")]
        Pattern = 2
    }
}