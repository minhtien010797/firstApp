using System.ComponentModel.DataAnnotations.Schema;

namespace firstApp.Entities
{
    public interface IEntityBase
    {
        int Id { get; set; }
    }
    public class EntityBase : IEntityBase
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}