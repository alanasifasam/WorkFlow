namespace WorkFlow.Vacation.Core.Entities
{
    public class CollaboratorEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<VacationRequestEntity> VacationRequests { get; set; } = new List<VacationRequestEntity>();
    }
}
