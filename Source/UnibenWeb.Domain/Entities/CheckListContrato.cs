using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnibenWeb.Domain.Entities
{
    [Table("CheckListContratos")]
    public class CheckListContrato
    {
        public CheckListContrato()
        {
            
        }
        [Key]
        public int CheckListContratoId { get; set; }
        public string CheckItem { get; set; }
        public bool Checked { get; set; }

    }
}