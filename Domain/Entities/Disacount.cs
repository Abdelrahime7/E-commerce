using Domain.Interface;


namespace Domain.Entities
{
    public class Disacount :IEntity
    {
         public int Id {  get; set; }
        public string Type { get; set; }
        public decimal  Percentag { get; set; }
        public bool IsDeleted { get ; set; }
    }
}
