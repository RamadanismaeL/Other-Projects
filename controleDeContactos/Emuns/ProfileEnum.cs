using System.ComponentModel;

namespace controleDeContactos.Emuns
{
    public enum ProfileEnum
    {
        [Description("Administrator User")]
        Admin = 1,
        [Description("Pattern User")]
        Pattern = 2
    }
}